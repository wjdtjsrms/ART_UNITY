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
    [SerializeField]
    private GameObject howToUI;

    public ButtonManager buttonManager;

    public GameObject playerGameObject; // �÷��̾� ��ü
    public Text LeftTrashText; // ���� ������ �ؽ�Ʈ

    public  int count; // ���� ������ ������ ī��Ʈ �ϴ� ����, ButtonManager���� �����Ѵ�.

    public event Action ParkChangeEvent; // ���� -> MBC �̵� �߻� �̺�Ʈ
    public event Action MBCBadEvent; // �����⸦ ��ġ���� ���ϰ� �ð踦 �������� ����� �̺�Ʈ
    public event Action MBCGoodEvent; // �����⸦ ��ġ��� �ð踦 �������� ����� �̺�Ʈ

    private bool isClean = false; // �����⸦ �� ġ������ ��Ÿ���� ����
    private static GameManager instance; // �̱��� ����

    

    [SerializeField]
    private GameObject startWorld;

    // MBC ������ �̵��� �����ϰ� �ϱ� ���� �Ҹ���
    // MovementProvider ���� ����Ѵ�.
    public bool Isworld_1 { get; private set; }
}

