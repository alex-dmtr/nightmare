using UnityEngine;

public class PickupManager : MonoBehaviour
{

    public PlayerHealth playerHealth;
    public Transform[] pickupLocations;
    public GameObject[] pickupPrefabs;
    public float timeBetweenSpawns = 5f;

    void Start()
    {

        InvokeRepeating("Spawn", timeBetweenSpawns, timeBetweenSpawns);

    }

    void Spawn()
    {
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        int spawnPointIndex = Random.Range(0, pickupLocations.Length);
        int pickupIndex = Random.Range(0, pickupPrefabs.Length);

        Instantiate(pickupPrefabs[pickupIndex], pickupLocations[spawnPointIndex].position, pickupLocations[spawnPointIndex].rotation);

    }
}
