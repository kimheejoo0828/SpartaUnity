using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameIntro : MonoBehaviour
{
    public GameObject instructionUI;
    public Player player;

    private bool isStarted = false;

    void Start()
    {
        instructionUI.SetActive(true); // 설명 먼저 보여줌
        player.enabled = false; // 게임 조작 막기
        Time.timeScale = 0f;
    }

    void Update()
    {
        if (!isStarted && Input.GetMouseButtonDown(0)) //마우스 왼쪽 클릭시 게임시작
        {
            instructionUI.SetActive(false); // 설명 숨기기
            player.enabled = true; // 게임 조작 시작
            Time.timeScale = 1f;
            isStarted = true;
        }
    }
}
