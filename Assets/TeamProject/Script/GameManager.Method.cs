using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;


public partial class GameManager : MonoBehaviour
{


    void Start()
    {
        
        Isworld_1 = true;

        // 필요한 이벤트핸들러를 추가한다.
        ParkChangeEvent += () => Invoke("SetWorldChange", 2f);

        MBCBadEvent += SetMBC_Change;
        MBCBadEvent += MBC_Bad_END;

        MBCGoodEvent += SetMBC_Change;
        MBCGoodEvent += MBC_Good_END;

        buttonManager?.StartButton.onClick.AddListener(() => Invoke("LoadParkAsset",2f));
        buttonManager?.HowToButton.onClick.AddListener(() => SetUI());


    }



    void Update()
    {
        LeftTrashText.text = "Left Trash : " + (int)count;
    }

}

public partial class GameManager : MonoBehaviour
{
    #region 싱글톤 구현
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            else
            {
                return instance;
            }
        }
    }
    #endregion

    public void SetCount() // 쓰레기 갯수 체크
    {
        count -= 1;

        if (count <= 0)
        {
            isClean = true;
        }
    }

    public void WorldChange() // 월드체인지 이벤트를 호출하는 함수
    {
        ParkChangeEvent?.Invoke();
    }
    public void TimeEventPlay() // 시계를 다 돌리면 실행될 함수
    {
        if (isClean) // 쓰레기를 다 치웠을때
        {
            MBCGoodEvent?.Invoke();
        }
        else // 쓰레기를 다 못 치웠을때
        {
            MBCBadEvent?.Invoke();
        }
    }

    private void SetMBC_Change()
    {

        // mbcData.Clock.gameObject.SetActive(false); 버그 있음

        if (isClean) // 쓰레기를 다 치웠을때
        {
            bgm.clip = mbcAsset.MbcGoodBGM;
            bgm.Play();
            mbcAsset.WorldRenderer.material = mbcAsset.MbcGoodMat;
        }
        else // 쓰레기를 다 못 치웠을때
        {
            bgm.clip = mbcAsset.MbcBadBgm;
            bgm.Play();
            mbcAsset.WorldRenderer.material = mbcAsset.MbcBadMat;
        }
    }

    private void MBC_Good_END()
    {
        mbcAsset.Blossom.gameObject.SetActive(true);
        mbcAsset.EndingMent.gameObject.SetActive(true);
    }

    private void MBC_Bad_END()
    {
        mbcAsset.EndingMent.gameObject.SetActive(true);
    }


    private void SetWorldChange() // 공원 -> MBC 이동 시 필요한 처리
    {
        Isworld_1 = false; // 이제 world_2 이다.
        LeftTrashText.gameObject.SetActive(false);// ui 숨기기

        parkAsset.RightRay.gameObject.SetActive(false); // 오른손 레이 숨기기
        parkAsset.TrashBin.gameObject.SetActive(false); // 쓰레기통 숨기기
        parkAsset.Portal.gameObject.SetActive(false); // 포탈 보이게 하기
        mbcAsset.Clock.gameObject.SetActive(true); // 시계 보이게 하기
    }

    public void RestartGame() // 테스트용 씬 다시 불러오기
    {
        SceneManager.LoadScene("SampleScene");
    }
    private void LoadParkAsset()
    {
        bgm.clip = parkAsset.ParkBGM;
        bgm.Play();
        parkAsset.gameObject.SetActive(true);
        startWorld.gameObject.SetActive(false);
        buttonManager.gameObject.SetActive(false);
        parkAsset.Portal.gameObject.SetActive(true);
    }
    void SetUI()
    {
        if (howToUI.gameObject.activeSelf)
        {
            howToUI.gameObject.SetActive(false);
            buttonManager.StartButton.gameObject.SetActive(true);
            buttonManager.HowToButton.gameObject.SetActive(true);

        }
        else
        {
            howToUI.gameObject.SetActive(true);
            buttonManager.StartButton.gameObject.SetActive(false);
            buttonManager.HowToButton.gameObject.SetActive(false);
        }
    }
}