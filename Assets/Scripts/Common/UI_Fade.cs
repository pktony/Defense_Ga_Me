using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class UI_Fade : MonoBehaviour
{
    private Image image;
    private CanvasGroup group;

    private void Awake()
    {
        image = GetComponent<Image>();
        group = GetComponent<CanvasGroup>();
    }

    public void ShowImage(float fadeTime = 1f)
    {
        StartCoroutine(AdjustAlpha(true, fadeTime));
    }

    public void HideImage(float fadeTime = 1f)
    {
        StartCoroutine(AdjustAlpha(false, fadeTime));
    }

    private IEnumerator AdjustAlpha(bool isShow, float fadeTime)
    {
        float deltaTime = Time.deltaTime / fadeTime;
        if (isShow)
        {
            while (group.alpha < 1f)
            {
                group.alpha += deltaTime;
                yield return null;
            }
            group.alpha = 1f;
            group.interactable = true;
            group.blocksRaycasts = true;
        }
        else
        {
            while (group.alpha > 0f)
            {
                group.alpha -= deltaTime;
                yield return null;
            }
            group.alpha = 0f;
            group.interactable = false;
            group.blocksRaycasts = false;
        }
    }
}
