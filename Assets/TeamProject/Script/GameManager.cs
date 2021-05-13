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
    private Park_Data parkAsset; // 공원에서 사용하는 에셋
    [SerializeField]
    private MBC_Data mbcAsset; // MBC에서 사용하는 에셋

    public GameObject playerGameObject; // 플레이어 객체
    public Text LeftTrashText; // 남은 쓰래기 텍스트

    private GameObject[] LeftTrash; // 쓰래기 객체들을 참조하는 변수
    private int count; // 남은 쓰래기 갯수를 카운트 하는 변수

    public event Action ParkChangeEvent; // 공원 -> MBC 이동 발생 이벤트
    public event Action MBCBadEvent; // 쓰레기를 다치우지 못하고 시계를 돌렸을때 생기는 이벤트
    public event Action MBCGoodEvent; // 쓰레기를 다치우고 시계를 돌렸을때 생기는 이벤트

    private bool isClean = false; // 쓰레기를 다 치웠는지 나타내는 변수
    private static GameManager instance; // 싱글톤 변수

    // MBC 에서만 이동이 가능하게 하기 위한 불리언
    // MovementProvider 에서 사용한다.
    public bool Isworld_1 { get; private set; }
}

