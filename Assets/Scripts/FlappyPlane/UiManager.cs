using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class UiManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;
    public TextMeshProUGUI bestscoreText;
    public TextMeshProUGUI bestText;

    public static UiManager Instance;
    int bestScore = 0;
    public int bestscore { get; private set; }
    private const string BestScoreKey = "BestScore";

    public void Start()
    {
        if (restartText == null)
        {
            Debug.LogError("restart text is null");
        }

        if (scoreText == null)
        {
            Debug.LogError("scoreText is null");
            return;
        }

        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            Invoke(nameof(HideScoreUI), 2f);
        }

        restartText.gameObject.SetActive(false);

        bestScore = PlayerPrefs.GetInt(BestScoreKey, 0);
    }

    void HideScoreUI()
    {
        if (scoreText != null)
            scoreText.gameObject.SetActive(false);
        if (bestscoreText != null)
            bestscoreText.gameObject.SetActive(false);
    }

    public void SetRestart()
    {
        restartText.gameObject.SetActive(true);
    }

    public void UpdateScore(int score)
    {

        scoreText.text = score.ToString();
        if(bestscore < score)
        {
            bestscore = score;
            bestscoreText.text = bestscore.ToString();

            PlayerPrefs.SetInt(BestScoreKey, bestscore);
        }
    }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // 중복이면 제거
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // 씬이 넘어가도유지
    }
}
