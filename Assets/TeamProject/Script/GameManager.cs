using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public partial class GameManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource bgm; 
    [SerializeField]
    private Park_Data parkAsset; // �������� ����ϴ� ����
    [SerializeField]
    private MBC_Data mbcAsset; // MBC���� ����ϴ� ����

    public GameObject playerGameObject; // �÷��̾� ��ü
    public Text LeftTrashText; // ���� ������ �ؽ�Ʈ

    private GameObject[] LeftTrash; // ������ ��ü���� �����ϴ� ����
    private int count; // ���� ������ ������ ī��Ʈ �ϴ� ����

    public event Action ParkChangeEvent; // ���� -> MBC �̵� �߻� �̺�Ʈ
    public event Action MBCBadEvent; // �����⸦ ��ġ���� ���ϰ� �ð踦 �������� ����� �̺�Ʈ
    public event Action MBCGoodEvent; // �����⸦ ��ġ��� �ð踦 �������� ����� �̺�Ʈ

    private bool isClean = false; // �����⸦ �� ġ������ ��Ÿ���� ����
    private static GameManager instance; // �̱��� ����

    // MBC ������ �̵��� �����ϰ� �ϱ� ���� �Ҹ���
    // MovementProvider ���� ����Ѵ�.
    public bool Isworld_1 { get; private set; }
}

