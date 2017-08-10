using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public float restartDelay = 5f;

    Animator anim;
    float restartTimer;
    public static bool isOver;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            Debug.Log("Dead frate");
            anim.SetTrigger("GameOver");
            restartTimer += Time.deltaTime;
            isOver = true;
            if(restartTimer >= restartDelay)
            {
                //Application.LoadLevel(Application.loadedLevel);
            }
        }
    }
}
