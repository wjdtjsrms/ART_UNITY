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

            //�� ��ȯ�� �Ǵ��� �ı����� �ʰ� �Ѵ�.
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //���� �� �̵��� �Ǿ��µ� �� ������ Hierarchy�� GameMgr�� ������ ���� �ִ�.
            //�׷� ��쿣 ���� ������ ����ϴ� �ν��Ͻ��� ��� ������ִ� ��찡 ���� �� ����.
            //�׷��� �̹� ���������� instance�� �ν��Ͻ��� �����Ѵٸ� �ڽ�(���ο� ���� GameMgr)�� �������ش�.
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
        // Trash Tag �� �޸� ������ ������Ʈ�� ���� ã�´�.
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
