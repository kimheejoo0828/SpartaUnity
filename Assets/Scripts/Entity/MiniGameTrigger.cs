using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameTrigger : MonoBehaviour
{
    public string minigameSceneName = "FlappyPlaneScene";
    public string mainSceneName = "MainScene";
    public GameObject interactionPopup;
    public TextMeshProUGUI bestscoreText;

    private bool isPlayerInRange = false;

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("F 키로 미니게임 진입");
            SceneManager.LoadScene(minigameSceneName);
        }

        if (Input.GetKeyDown(KeyCode.Escape))  //Esc 버튼눌러도 MainScene으로 복귀
        {
            SceneManager.LoadScene(mainSceneName);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            if (interactionPopup != null)
                interactionPopup.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            if (interactionPopup != null)
                interactionPopup.SetActive(false);
        }
    }
    /*
    void SaveBestScore(int score)
    {
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);
        if (score > bestScore)
        {
            PlayerPrefs.SetInt("BestScore", score);
            Debug.Log("새로운 최고 점수: " + score);
        }
        else
        {
            Debug.Log("현재 최고 점수 유지: " + bestScore);
        }
    }
    */
}
