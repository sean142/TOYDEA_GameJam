using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    public CanvasGroup fadeCanvasGroup;
    public float restartTimer;
    IEnumerator InstallFadeOutScene()
    {
        float currentTime = 0f;
        while (currentTime < restartTimer)
        {
            currentTime += Time.deltaTime;
            fadeCanvasGroup.alpha = 0 + (currentTime / restartTimer);
            yield return null;
        }
        fadeCanvasGroup.alpha = 1;
        StartCoroutine(InstallFadeInScene());
    }
    IEnumerator InstallFadeInScene()
    {
        float currentTime = restartTimer;
        while (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            fadeCanvasGroup.alpha = currentTime / restartTimer;
            yield return null;
        }
        fadeCanvasGroup.alpha = 0;
        this.gameObject.SetActive(false);
    }
}
