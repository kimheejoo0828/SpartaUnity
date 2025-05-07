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
            Debug.Log("F Ű�� �̴ϰ��� ����");
            SceneManager.LoadScene(minigameSceneName);
        }

        if (Input.GetKeyDown(KeyCode.Escape))  //Esc ��ư������ MainScene���� ����
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
            Debug.Log("���ο� �ְ� ����: " + score);
        }
        else
        {
            Debug.Log("���� �ְ� ���� ����: " + bestScore);
        }
    }
    */
}
