using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBC_Data : MonoBehaviour
{
    [SerializeField]
    private AudioClip mbcBadBGM;
    [SerializeField]
    private AudioClip mbcGoodBGM;
    [SerializeField]
    private Material mbcBadMat;
    [SerializeField]
    private Material mbcGoodMat;
    [SerializeField]
    private GameObject clock;
    [SerializeField]
    private GameObject blossom;

    [SerializeField]
    private MeshRenderer mbcWorldRenderer; // 머터리얼을 바꾸기 위한 월드의 메시렌더러

    #region 프로퍼티
    public AudioClip MbcBadBgm
    {
        get
        {
            return mbcBadBGM;
        }
    }
    public AudioClip MbcGoodBGM
    {
        get
        {
            return mbcGoodBGM;
        }
    }
    public Material MbcBadMat
    {
        get
        {
            return mbcBadMat;
        }
    }
    public Material MbcGoodMat
    {
        get
        {
            return mbcGoodMat;
        }
    }

    public GameObject Clock
    {
        get
        {
            return clock;
        }
    }

    public GameObject Blossom
    {
        get
        {
            return blossom;
        }
    }
    public MeshRenderer WorldRenderer
    {
        get
        {
            return mbcWorldRenderer;
        }
    }
    #endregion
}
