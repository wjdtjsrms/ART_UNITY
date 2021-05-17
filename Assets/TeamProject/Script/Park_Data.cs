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
    private GameObject rightRay; // 오른속 레이
    [SerializeField]
    private AudioClip parkBGM;

    private GameObject[] LeftTrash;

    #region 프로퍼티
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
            if (LeftTrash.Length != 0) // 다 치우지 못한 쓰래기가 남아있다면 없앤다.
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
