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
        if(!PlayerPrefs.HasKey("Player Score"))
            score = 0;
        else
            score = PlayerPrefs.GetInt("Player Score");
    }

    private void Update ()
    {
        int lvl = levelContainer.GetLevel();
        text.text = "Level: " + lvl + " Score: " + score;
        if(score >= 100 * lvl)
        {
            levelContainer.IncrementLevel();
        }
        
        if (score >= 200 && SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0))
        {
            PlayerPrefs.SetInt("Player Score", score);
            PlayerPrefs.Save();
            SceneManager.LoadSceneAsync(1);
        }
        else if (score >= 300 && SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1))
        {
            PlayerPrefs.SetInt("Player Score", score);
            PlayerPrefs.Save();
            SceneManager.LoadSceneAsync(2);
        }
    }
}
