using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;
    public TextMeshProUGUI bestscoreText;

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

        restartText.gameObject.SetActive(false);

        bestScore = PlayerPrefs.GetInt(BestScoreKey, 0);
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
