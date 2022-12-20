using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FastForward : MonoBehaviour
{
    private Button button;
    private Image arrowImg;

    private enum playSpeeds { normal, x2};

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
        if(speed == playSpeeds.normal)
        {
            Time.timeScale = 1.0f;
            arrowImg.sprite = speedImages[0];
            speed = playSpeeds.x2;
        }
        else if(speed == playSpeeds.x2)
        {
            Time.timeScale = 2.0f;
            arrowImg.sprite = speedImages[1];
            speed = playSpeeds.normal;
        }
    }
}
