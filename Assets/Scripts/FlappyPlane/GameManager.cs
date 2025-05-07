using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;
    UiManager uiManager;
    public string mainSceneName = "MainScene";
    public float returnDelay = 5.0f;  //5√ »ƒ MainScene∑Œ ∫π±Õ
    public static GameManager Instance
    {
        get { return gameManager; }
    }

    public UiManager UiManager
    {
        get { return uiManager; }
    }

    private int currentScore = 0;

    private void Awake()
    {
        gameManager = this;
        uiManager = FindObjectOfType<UiManager>();
    }

    private void Start()
    {
        uiManager.UpdateScore(0);
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        Invoke(nameof(ReturnToMain), returnDelay);
        //uiManager.SetRestart();
    }

    private void ReturnToMain()
    {
        SceneManager.LoadScene(mainSceneName);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int score)
    {
        currentScore += score;
        uiManager.UpdateScore(currentScore);
        Debug.Log("Score: " + currentScore);
    }
}
