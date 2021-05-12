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

    #region �������� ����ϴ� ����
    [SerializeField]
    private GameObject trashBin; // ��������
    [SerializeField]
    private GameObject portal; // ��Ż
    [SerializeField]
    private GameObject clock; // �ð�
    [SerializeField]
    private GameObject rightRay; // ������ ����
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
        ParkChangeEvent += () => Invoke("SetWorldChange", 2f); // ���� ���� �̺�Ʈ
        MBCBadEvent += MBC_CommonDo;
        MBCGoodEvent += MBC_CommonDo;
        Isworld_1 = true;
    }

    void Update()
    {
         LeftTrashText.text = "Left Trash : " + (int)count;
    }

    public void SetCount() // ������ ���� üũ
    {
        count -= 1;

        if(count <= 0)
        {
            isClean = true;          
        }
    }

    public void WorldChange() // ����ü���� �̺�Ʈ�� ȣ���ϴ� �Լ�
    {
        ParkChangeEvent?.Invoke();
    }
    public void TimeEventPlay() // �ð踦 ������ ������ �̺�Ʈ
    {
        if(isClean) // �����⸦ �� ġ������
        {
            MBCGoodEvent?.Invoke();
        }
        else // �����⸦ �� �� ġ������
        {
            MBCBadEvent?.Invoke();
        }
    }

    private void MBC_CommonDo()
    {
       // clock.gameObject.SetActive(false);
    }

    private void SetWorldChange() // ���� ü���� �̺�Ʈ ���� ����
    {
        LeftTrashText.gameObject.SetActive(false);// ui �����
        rightRay.gameObject.SetActive(false);
        trashBin.gameObject.SetActive(false); // �������� �����
        portal.gameObject.SetActive(false); // ��Ż ���̰� �ϱ�
        clock.gameObject.SetActive(true); // �ð� ���̰� �ϱ�
        Isworld_1 = false;
        bgm.Play(); // ��� ����
    }

    public void RestartGame() // �׽�Ʈ�� �� �ٽ� �ҷ�����
    {
        SceneManager.LoadScene("SampleScene");
    }
}
