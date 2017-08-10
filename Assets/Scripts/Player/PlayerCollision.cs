using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    PlayerHealth playerHealth;
    public Animator chestAnimator;
    public Text eToOpen;
    public int reqScore = 100;
    private bool isInRange = false;


    private void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Chest"))
        {
            eToOpen.rectTransform.localScale = Vector3.one;
            isInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Chest"))
        {
            eToOpen.rectTransform.localScale = Vector3.zero;
            isInRange = false;
        }
    }


    private void Update()
    {
        if (Input.GetKey(KeyCode.E) && ScoreManager.score >= reqScore && isInRange)
        {
            chestAnimator.SetTrigger("Activate");
            ActivateWinGame();
        }
    }

    private void ActivateWinGame()
    {
        throw new System.NotImplementedException();
    }
}