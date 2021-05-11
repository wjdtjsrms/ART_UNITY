using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region ���,���͸���
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

    private MeshRenderer parkMat; // �Ž� �������� ���͸���
    #endregion

    public GameObject playerGameObject;
    public Text LeftTrashText;

    private GameObject[] LeftTrash;
    private int count;

    private static GameManager instance;

    #region �ν��Ͻ� ����
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
        // Trash Tag �� �޸� ������ ������Ʈ�� ���� ã�´�.
        LeftTrash = GameObject.FindGameObjectsWithTag("Trash");
        count = LeftTrash.Length;
        parkMat = world.GetComponent<MeshRenderer>(); // 360_Park �޽� ������ �����´�
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
            SetChange();
        }
    }
    private void SetChange()
    {
        bgm.clip = Park_Good_Audio;
        bgm.Play();
        parkMat.material = Park_Good_Mat;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
