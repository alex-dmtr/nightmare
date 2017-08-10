using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    public LevelContainer levelContainer;
    
    private AssetBundle myLoadedAssetBundle;
    private string[] scenePaths;

    Text text;


    private void Awake ()
    {
        text = GetComponent <Text> ();
        if (!PlayerPrefs.HasKey("Player Score") || SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0))
        {
            score = 0;
            PlayerPrefs.SetInt("Player Score", score);
            PlayerPrefs.Save();
        }
        else
            score = PlayerPrefs.GetInt("Player Score");

    }

    private void Update ()
    {
        int lvl = levelContainer.GetLevel();
        if(!GameOverManager.isOver) 
            text.text = "Score: " + score;
        if(score >= 100 * lvl)
        {
            levelContainer.IncrementLevel();
        }
        
        if (score >= 50 && SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0))
        {
            PlayerPrefs.SetInt("Player Score", score);
            PlayerPrefs.Save();
            SceneManager.LoadScene(1);
        }
        else if (score >= 100 && SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1))
        {
            PlayerPrefs.SetInt("Player Score", score);
            PlayerPrefs.Save();
            SceneManager.LoadScene(2);
        }
    }
}
