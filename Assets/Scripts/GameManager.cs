using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject gameOverText;
    public GameObject playerGameObject;
    public Text LeftTrashText;
    public bool isGameOver;

    private GameObject[] LeftTrash;
    private int count;
    private bool isClean = false;

    public AudioSource bgm;
    public AudioClip Park_Bad_Audio;
    public AudioClip Park_Good_Audio;

    public GameObject world;
    public Material Park_Bad_Mat;
    public Material Park_Good_Mat;

    private MeshRenderer worldMat;
    private static GameManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;

            //씬 전환이 되더라도 파괴되지 않게 한다.
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //만약 씬 이동이 되었는데 그 씬에도 Hierarchy에 GameMgr이 존재할 수도 있다.
            //그럴 경우엔 이전 씬에서 사용하던 인스턴스를 계속 사용해주는 경우가 많은 것 같다.
            //그래서 이미 전역변수인 instance에 인스턴스가 존재한다면 자신(새로운 씬의 GameMgr)을 삭제해준다.
            Destroy(this.gameObject);
        }
    }

    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                return null;
            }
            else
            {
                return instance;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Trash Tag 가 달린 쓰레기 오브젝트을 전부 찾는다.
        LeftTrash = GameObject.FindGameObjectsWithTag("Trash");
        count = LeftTrash.Length;
        worldMat = world.GetComponent<MeshRenderer>();
        Debug.Log(worldMat);
        isGameOver = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameOver)
        {
            LeftTrashText.text = "Left Trash : " + (int)count;
        }     
    }

    public void SetCount()
    {
        count -= 1;
        if(count <= 0)
        {
            isClean = true;
            SetChange();
        }
    }
    private void SetChange()
    {
        bgm.clip = Park_Good_Audio;
        bgm.Play();
        worldMat.material = Park_Good_Mat;
    }
    public void GetScored(int value)
    {
        //
    }
    public void EndGame()
    {
        isGameOver = true;
        gameOverText.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
