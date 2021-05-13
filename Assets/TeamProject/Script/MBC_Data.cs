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
    private MeshRenderer mbcWorldRenderer; // ���͸����� �ٲٱ� ���� ������ �޽÷�����

    #region ������Ƽ
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
    public MeshRenderer WorldRenderer
    {
        get
        {
            return mbcWorldRenderer;
        }
    }
    #endregion
}
