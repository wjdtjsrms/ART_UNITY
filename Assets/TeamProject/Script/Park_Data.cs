using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Park_Data : MonoBehaviour
{
    [SerializeField]
    private GameObject trashBin; 
    [SerializeField]
    private GameObject portal; 
    [SerializeField]
    private GameObject rightRay; // ������ ����
    [SerializeField]
    private AudioClip parkBGM;

    private GameObject[] LeftTrash;

    #region ������Ƽ
    public GameObject TrashBin
    {
        get
        {
            return trashBin;
        }
    }
    public GameObject Portal
    {
        get
        {
            return portal;
        }
    }
    public GameObject RightRay
    {
        get
        {
            return rightRay;
        }
    }
    public AudioClip ParkBGM
    {
        get
        {
            return parkBGM;
        }
    }

    private void OnEnable()
    {
        LeftTrash = GameObject.FindGameObjectsWithTag("Trash");
        GameManager.Instance.count = LeftTrash.Length;
        GameManager.Instance.ParkChangeEvent += () =>
        {
            if (LeftTrash.Length != 0) // �� ġ���� ���� �����Ⱑ �����ִٸ� ���ش�.
            {

                foreach (GameObject obj in LeftTrash)
                {
                    Destroy(obj);
                }
            }
        };
    }

    #endregion
}
