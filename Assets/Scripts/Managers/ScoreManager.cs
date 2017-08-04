using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    public LevelContainer levelContainer;

    Text text;


    void Awake ()
    {
        text = GetComponent <Text> ();
        score = 0;
    }


    void Update ()
    {
        int lvl = levelContainer.GetLevel();
        text.text = "Level: " + lvl + " Score: " + score;
        if(score >= 100 * lvl)
        {
            levelContainer.IncrementLevel();
        }
    }
}
