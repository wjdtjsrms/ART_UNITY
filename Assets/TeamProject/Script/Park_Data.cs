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
    #endregion
}
