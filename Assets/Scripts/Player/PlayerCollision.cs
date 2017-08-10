using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    public Animator chestAnimator;
    public Text eToOpen;
    public int reqScore = 200;
    public Animator anim;
    public Text GameOverText;
    public Text ScoreText;
    
    private PlayerHealth playerHealth;
    private bool isInRange;


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
            GameOverText.text = "You win!";
            ScoreText.text = "Final score: " + ScoreManager.score;
            GameOverManager.isOver = true;
            chestAnimator.SetTrigger("Activate");
            anim.SetTrigger("GameOver");
        }
    }

}