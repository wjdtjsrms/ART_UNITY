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

        // �ʿ��� �̺�Ʈ�ڵ鷯�� �߰��Ѵ�.
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
    #region �̱��� ����
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

    public void SetCount() // ������ ���� üũ
    {
        count -= 1;

        if (count <= 0)
        {
            isClean = true;
        }
    }

    public void WorldChange() // ����ü���� �̺�Ʈ�� ȣ���ϴ� �Լ�
    {
        ParkChangeEvent?.Invoke();
    }
    public void TimeEventPlay() // �ð踦 �� ������ ����� �Լ�
    {
        if (isClean) // �����⸦ �� ġ������
        {
            MBCGoodEvent?.Invoke();
        }
        else // �����⸦ �� �� ġ������
        {
            MBCBadEvent?.Invoke();
        }
    }

    private void SetMBC_Change()
    {

        // mbcData.Clock.gameObject.SetActive(false); ���� ����

        if (isClean) // �����⸦ �� ġ������
        {
            bgm.clip = mbcAsset.MbcGoodBGM;
            bgm.Play();
            mbcAsset.WorldRenderer.material = mbcAsset.MbcGoodMat;
        }
        else // �����⸦ �� �� ġ������
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


    private void SetWorldChange() // ���� -> MBC �̵� �� �ʿ��� ó��
    {
        Isworld_1 = false; // ���� world_2 �̴�.
        LeftTrashText.gameObject.SetActive(false);// ui �����

        parkAsset.RightRay.gameObject.SetActive(false); // ������ ���� �����
        parkAsset.TrashBin.gameObject.SetActive(false); // �������� �����
        parkAsset.Portal.gameObject.SetActive(false); // ��Ż ���̰� �ϱ�
        mbcAsset.Clock.gameObject.SetActive(true); // �ð� ���̰� �ϱ�
    }

    public void RestartGame() // �׽�Ʈ�� �� �ٽ� �ҷ�����
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