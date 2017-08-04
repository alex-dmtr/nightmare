using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class PlayerPickup : MonoBehaviour {

    public PostProcessingProfile defaultProfile;
    public PostProcessingProfile energyProfile;
    public PostProcessingBehaviour ppBehaviour;

    public PlayerMovement playerMovement;
    public PlayerShooting playerShooting;

    public float energyDrink_TimeRemaining = 0f;

    void OnTriggerEnter(Collider other) {

        if(other.gameObject.tag == "EnergyDrink") {
            Debug.Log("Drank energy drink");
            StartCoroutine(ConsumeEnergyDrink());
        }
    }


    IEnumerator ConsumeEnergyDrink () {
        energyDrink_TimeRemaining += 5.0f;

        ppBehaviour.profile = energyProfile;
        playerShooting.damagePerShot = 30;
        playerShooting.timeBetweenBullets = 0.05f;
        playerMovement.speed = 10f;

        //add effect

        while(energyDrink_TimeRemaining > 0) {
            energyDrink_TimeRemaining -= Time.deltaTime;
            yield return null;
        }

        ppBehaviour.profile = defaultProfile;
        playerShooting.damagePerShot = 20;
        playerShooting.timeBetweenBullets = 0.15f;
        playerMovement.speed = 6f;

        //remove effect
    }
}
