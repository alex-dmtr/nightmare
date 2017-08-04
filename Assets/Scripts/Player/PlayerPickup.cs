using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.UI;

public class PlayerPickup : MonoBehaviour {

    public PostProcessingProfile defaultProfile;
    public PostProcessingProfile energyProfile;
    public PostProcessingBehaviour ppBehaviour;

    public PlayerMovement playerMovement;
    public PlayerShooting playerShooting;

    public float[] remainingTime = { 0f };
    public Image[] effectImage;
    public Text[] effectText;
    public RectTransform[] effectParent;

    private int energyDrinkEffectIndex = 0;

    private int effects = 0;

    void Awake()
    {
        //new WaitForSeconds(1);
        foreach (RectTransform transform in effectParent)
            transform.localScale = new Vector3(0,0,0);
    }

    void OnTriggerEnter(Collider other) {

        if(other.gameObject.tag == "EnergyDrink") {
            Debug.Log("Drank energy drink");
            Destroy(other.gameObject);
            if (remainingTime[energyDrinkEffectIndex] <= 0f)
                StartCoroutine(ConsumeEnergyDrink());
            else remainingTime[energyDrinkEffectIndex] += 15.0f;
        }
    }


    IEnumerator ConsumeEnergyDrink () {
        if (remainingTime[energyDrinkEffectIndex] <= 0f)
            effects++;
        remainingTime[energyDrinkEffectIndex] += 15.0f;

        effectParent[energyDrinkEffectIndex].localScale = new Vector3(1, 1, 1);
        effectParent[energyDrinkEffectIndex].position.Set(0, -60 * (effects - 1), 0);

        ppBehaviour.profile = energyProfile;
        playerShooting.damagePerShot = 30;
        playerShooting.timeBetweenBullets = 0.05f;
        playerMovement.speed = 10f;
        
        //add effect

        while(remainingTime[energyDrinkEffectIndex] > 0) {
            float delta = Time.deltaTime;

            remainingTime[energyDrinkEffectIndex] -= delta;
            effectText[energyDrinkEffectIndex].text = remainingTime[energyDrinkEffectIndex].ToString("0.##") + "s";
            Debug.Log("Delta: " + delta);


            yield return null;

        }

        //remove effect
        ppBehaviour.profile = defaultProfile;
        playerShooting.damagePerShot = 20;
        playerShooting.timeBetweenBullets = 0.15f;
        playerMovement.speed = 6f;
        effectParent[energyDrinkEffectIndex].localScale = new Vector3(0, 0, 0);
        effects--;

    }
}
