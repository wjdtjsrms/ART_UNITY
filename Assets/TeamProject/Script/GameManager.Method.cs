using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;


public partial class GameManager : MonoBehaviour
{
    void Start()
    {
        Isworld_1 = true;

        // Trash Tag �� �޸� ������ ������Ʈ�� ���� ã�´�.
        LeftTrash = GameObject.FindGameObjectsWithTag("Trash");
        count = LeftTrash.Length;

        // �ʿ��� �̺�Ʈ�ڵ鷯�� �߰��Ѵ�.
        ParkChangeEvent += () => Invoke("SetWorldChange", 2f);
        MBCBadEvent += SetMBC_Change;
        MBCGoodEvent += SetMBC_Change;
    }

    void Update()
    {
        LeftTrashText.text = "Left Trash : " + (int)count;
    }

}

public partial class GameManager : MonoBehaviour
{
    #region �̱��� ����
    private void Awake()
    {
        if (instance == null)
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

    public void SetCount() // ������ ���� üũ
    {
        count -= 1;

        if (count <= 0)
        {
            isClean = true;
        }
    }

    public void WorldChange() // ����ü���� �̺�Ʈ�� ȣ���ϴ� �Լ�
    {
        ParkChangeEvent?.Invoke();
    }
    public void TimeEventPlay() // �ð踦 �� ������ ����� �Լ�
    {
        if (isClean) // �����⸦ �� ġ������
        {
            MBCGoodEvent?.Invoke();
        }
        else // �����⸦ �� �� ġ������
        {
            MBCBadEvent?.Invoke();
        }
    }

    private void SetMBC_Change()
    {
        // mbcData.Clock.gameObject.SetActive(false); ���� ����

        if (isClean) // �����⸦ �� ġ������
        {
            bgm.clip = mbcAsset.MbcGoodBGM;
            bgm.Play();
            mbcAsset.WorldRenderer.material = mbcAsset.MbcGoodMat;
        }
        else // �����⸦ �� �� ġ������
        {
            bgm.clip = mbcAsset.MbcBadBgm;
            bgm.Play();
            mbcAsset.WorldRenderer.material = mbcAsset.MbcBadMat;
        }
    }

    private void SetWorldChange() // ���� -> MBC �̵� �� �ʿ��� ó��
    {
        if (LeftTrash.Length != 0) // �� ġ���� ���� �����Ⱑ �����ִٸ� ���ش�.
        {
            foreach (GameObject obj in LeftTrash)
            {
                Destroy(obj);
            }
        }

        Isworld_1 = false; // ���� world_2 �̴�.
        LeftTrashText.gameObject.SetActive(false);// ui �����

        parkAsset.RightRay.gameObject.SetActive(false); // ������ ���� �����
        parkAsset.TrashBin.gameObject.SetActive(false); // �������� �����
        parkAsset.Portal.gameObject.SetActive(false); // ��Ż ���̰� �ϱ�
        mbcAsset.Clock.gameObject.SetActive(true); // �ð� ���̰� �ϱ�
    }

    public void RestartGame() // �׽�Ʈ�� �� �ٽ� �ҷ�����
    {
        SceneManager.LoadScene("SampleScene");
    }

}