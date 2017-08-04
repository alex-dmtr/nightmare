using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
    public LevelContainer levelContainer;
    private int level;
    public float minSpawnTime = 1f;

    void Start()
    {
        level = levelContainer.GetLevel();
        InvokeRepeating("Spawn", spawnTime, spawnTime);
   
    }
    
    void Spawn ()
    {
        if(playerHealth.currentHealth <= 0f)
        {
            return;
        }
        if(level < levelContainer.GetLevel() && spawnTime > minSpawnTime)
        {
            level = levelContainer.GetLevel();
            CancelInvoke("Spawn");
            spawnTime = spawnTime - (spawnTime * 25 / 100);
            InvokeRepeating("Spawn", spawnTime, spawnTime);
        }else {
            int spawnPointIndex = Random.Range (0, spawnPoints.Length);

            Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        }
        
    }
}
