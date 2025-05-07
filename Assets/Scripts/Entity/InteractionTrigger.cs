using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTrigger : MonoBehaviour
{
    public GameObject interactionPopup;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactionPopup.SetActive(true);
            Debug.Log("��ȣ�ۿ� ������ ������ �����߽��ϴ�!");
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactionPopup.SetActive(false);
        }
    }

}