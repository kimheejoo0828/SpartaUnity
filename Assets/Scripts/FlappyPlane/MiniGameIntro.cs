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
        instructionUI.SetActive(true); // ���� ���� ������
        player.enabled = false; // ���� ���� ����
        Time.timeScale = 0f;
    }

    void Update()
    {
        if (!isStarted && Input.GetMouseButtonDown(0)) //���콺 ���� Ŭ���� ���ӽ���
        {
            instructionUI.SetActive(false); // ���� �����
            player.enabled = true; // ���� ���� ����
            Time.timeScale = 1f;
            isStarted = true;
        }
    }
}
