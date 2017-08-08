using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    public float timeBetweenAttacks = 0.5f;
    public int cactusDamage = 5;

    PlayerHealth playerHealth;
    float timer;

    bool cactusInRange;

    private void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
        timer = 0f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Cactus"))
        {
            cactusInRange = true;
            Debug.Log("Collision Enter");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cactus"))
        {
            cactusInRange = false;
            Debug.Log("Collision Exit");
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && cactusInRange && playerHealth.currentHealth > 0)
        {
            GetAttackedByCactus();
            Debug.Log("Took damage");
        }
    }

    private void GetAttackedByCactus()
    {
        timer = 0f;
        if (playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(cactusDamage);
        }
    }
}
