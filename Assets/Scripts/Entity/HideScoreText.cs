using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideScoreText : MonoBehaviour
{
    public float delay = 2f;

    void Start()
    {
        // 2ÃÊ ÈÄ ÅØ½ºÆ® ¼û±è
        Invoke(nameof(HideTexts), delay);
    }

    void HideTexts()
    {
        if (UiManager.Instance != null)
        {
            if (UiManager.Instance.scoreText != null)
                UiManager.Instance.scoreText.gameObject.SetActive(false);

            if (UiManager.Instance.bestscoreText != null)
                UiManager.Instance.bestscoreText.gameObject.SetActive(false);

            if (UiManager.Instance.bestText != null)
                UiManager.Instance.bestText.gameObject.SetActive(false);
        }
    }
}
