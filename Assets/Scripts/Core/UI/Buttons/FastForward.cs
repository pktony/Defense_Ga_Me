using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FastForward : MonoBehaviour
{
    private Button button;
    private Image arrowImg;

    private enum playSpeeds { normal, x2, x4, x8, x16};

    private playSpeeds speed = playSpeeds.normal;

    [SerializeField]
    private Sprite[] speedImages;

    private void Awake()
    {
        button = GetComponent<Button>();
        arrowImg = transform.GetChild(0).GetComponent<Image>();

        button.onClick.AddListener(ChangeGameSpeed);
    }

    private void ChangeGameSpeed()
    {
        speed++;
        speed = (playSpeeds)((int)speed % Enum.GetValues(typeof(playSpeeds)).Length);
        arrowImg.sprite = speedImages[(int)speed];


        switch(speed)
        {
            case playSpeeds.normal:
                Time.timeScale = 1.0f;
                break;
            case playSpeeds.x2:
                Time.timeScale = 2.0f;
                break;
            case playSpeeds.x4:
                Time.timeScale = 4.0f;
                break;
            case playSpeeds.x8:
                Time.timeScale = 8.0f;
                break;
            case playSpeeds.x16:
                Time.timeScale = 16.0f;
                break;
        }
    }
}
