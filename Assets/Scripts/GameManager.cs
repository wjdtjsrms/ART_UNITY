using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource bgm;

    #region 공원에서 사용하는 에셋
    [SerializeField]
    private GameObject trashBin; // 쓰레기통
    [SerializeField]
    private GameObject portal; // 포탈
    [SerializeField]
    private GameObject clock; // 시계
    [SerializeField]
    private GameObject rightRay; // 오른속 레이
    #endregion

    public GameObject playerGameObject; 
    public Text LeftTrashText;

    private GameObject[] LeftTrash;
    private int count;

    private static GameManager instance;

    public event Action ParkChangeEvent;
    public event Action MBCBadEvent;
    public event Action MBCGoodEvent;

    private bool isClean = false;
    public  bool Isworld_1 { get; private set; }
     
    #region 인스턴스 구현
    private void Awake()
    {
        if(instance == null)
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


    void Start()
    {
        // Trash Tag 가 달린 쓰레기 오브젝트을 전부 찾는다.
        LeftTrash = GameObject.FindGameObjectsWithTag("Trash");
        count = LeftTrash.Length;
        ParkChangeEvent += () => Invoke("SetWorldChange", 2f); // 월드 변경 이벤트
        MBCBadEvent += MBC_CommonDo;
        MBCGoodEvent += MBC_CommonDo;
        Isworld_1 = true;
    }

    void Update()
    {
         LeftTrashText.text = "Left Trash : " + (int)count;
    }

    public void SetCount() // 쓰레기 갯수 체크
    {
        count -= 1;

        if(count <= 0)
        {
            isClean = true;          
        }
    }

    public void WorldChange() // 월드체인지 이벤트를 호출하는 함수
    {
        ParkChangeEvent?.Invoke();
    }
    public void TimeEventPlay() // 시계를 돌리고 나오는 이벤트
    {
        if(isClean) // 쓰레기를 다 치웠을때
        {
            MBCGoodEvent?.Invoke();
        }
        else // 쓰레기를 다 못 치웠을때
        {
            MBCBadEvent?.Invoke();
        }
    }

    private void MBC_CommonDo()
    {
       // clock.gameObject.SetActive(false);
    }

    private void SetWorldChange() // 월드 체인지 이벤트 내용 구성
    {
        LeftTrashText.gameObject.SetActive(false);// ui 숨기기
        rightRay.gameObject.SetActive(false);
        trashBin.gameObject.SetActive(false); // 쓰레기통 숨기기
        portal.gameObject.SetActive(false); // 포탈 보이게 하기
        clock.gameObject.SetActive(true); // 시계 보이게 하기
        Isworld_1 = false;
        bgm.Play(); // 브금 실행
    }

    public void RestartGame() // 테스트용 씬 다시 불러오기
    {
        SceneManager.LoadScene("SampleScene");
    }
}
