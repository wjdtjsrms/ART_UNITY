using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    #region 브금,머터리얼
    [SerializeField]
    private AudioSource bgm;
    [SerializeField]
    private AudioClip Park_Bad_Audio;
    [SerializeField]
    private AudioClip Park_Good_Audio;

    [SerializeField]
    private GameObject world;
    [SerializeField]
    private Material Park_Bad_Mat;
    [SerializeField]
    private Material Park_Good_Mat;

    [SerializeField]
    private GameObject trashBin;
    [SerializeField]
    private GameObject portal;

private MeshRenderer parkMat; // 매시 렌더러의 머터리얼
    #endregion

    public GameObject playerGameObject;
    public Text LeftTrashText;

    private GameObject[] LeftTrash;
    private int count;

    private static GameManager instance;
    public event Action parkChangeEvent;

     

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
        parkMat = world.GetComponent<MeshRenderer>(); // 360_Park 메시 렌더를 가져온다
        parkChangeEvent += () => Invoke("SetChange",2f); // 월드 변경 이벤트
    }

    void Update()
    {
         LeftTrashText.text = "Left Trash : " + (int)count;
    }

    public void SetCount()
    {
        count -= 1;

        if(count <= 0)
        {
            parkChangeEvent?.Invoke();
        }
    }
    private void SetChange()
    {
        LeftTrashText.gameObject.SetActive(false);// ui 숨기기
        trashBin.gameObject.SetActive(false); // 쓰레기통 숨기기
        //portal.gameObject.SetActive(true); // 포탈 보이게 하기
        bgm.clip = Park_Good_Audio; //브금 변경
        bgm.Play(); // 브금 실행
        parkMat.material = Park_Good_Mat; // 월드 1 머터리얼 변경 
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
