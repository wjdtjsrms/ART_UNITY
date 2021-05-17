using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    private Button startButton;
    [SerializeField]
    private Button howToButton;
    [SerializeField]
    private Button nextButton;
    [SerializeField]
    private GameObject howToUI;

    [SerializeField]
    private GameObject[] howto;
    private int index = 0;

    [SerializeField]
    private Sprite closeImage;
    [SerializeField]
    private Sprite nextImage;


    public Button StartButton
    {
        get
        {
            return startButton;
        }
    }
    public Button HowToButton
    {
        get
        {
            return howToButton;
        }
    }

    private void Awake()
    {       
        nextButton.onClick.AddListener(() => NextHow());
    }
    private void NextHow()
    {
        index++;

        if (index  == 1)
        {            
            howto[index-1].gameObject.SetActive(false);
            howto[index].gameObject.SetActive(true);
        }
        else if(index == 2)
        {
            howto[index - 1].gameObject.SetActive(false);
            howto[index].gameObject.SetActive(true);
            nextButton.image.sprite = closeImage;
            // 이미지 바꾸기
        }
        else if (index == 3)
        {
            howto[0].gameObject.SetActive(true);
            howto[2].gameObject.SetActive(false);
            howToUI.gameObject.SetActive(false);
            startButton.gameObject.SetActive(true);
            howToButton.gameObject.SetActive(true);
            nextButton.image.sprite = nextImage;
            index = 0;
        }

    }
}
