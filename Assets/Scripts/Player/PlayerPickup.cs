using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.UI;

public class PlayerPickup : MonoBehaviour
{
    public PostProcessingProfile defaultProfile;
    public PostProcessingProfile energyProfile;
    public PostProcessingBehaviour ppBehaviour;

    public PlayerMovement playerMovement;
    public PlayerShooting playerShooting;

    public float[] remainingTime = {0f};
    public Image[] effectImage;
    public Text[] effectText;
    public RectTransform[] effectParent;

    private const int EnergyDrinkEffectIndex = 0;

    private int effects = 0;

    void Awake()
    {
        //new WaitForSeconds(1);
        foreach (var rectTransform in effectParent)
            rectTransform.localScale = new Vector3(0, 0, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnergyDrink"))
        {
            Debug.Log("Drank energy drink");
            Destroy(other.gameObject);
            if (remainingTime[EnergyDrinkEffectIndex] <= 0f)
                StartCoroutine(ConsumeEnergyDrink());
            else remainingTime[EnergyDrinkEffectIndex] += 15.0f;
        }
    }


    private IEnumerator ConsumeEnergyDrink()
    {
        if (remainingTime[EnergyDrinkEffectIndex] <= 0f)
            effects++;
        remainingTime[EnergyDrinkEffectIndex] += 15.0f;

        effectParent[EnergyDrinkEffectIndex].localScale = new Vector3(1, 1, 1);
        effectParent[EnergyDrinkEffectIndex].position.Set(0, -60 * (effects - 1), 0);

        ppBehaviour.profile = energyProfile;
        playerShooting.damagePerShot = 30;
        playerShooting.timeBetweenBullets = 0.05f;
        playerMovement.speed = 10f;

        //add effect

        while (remainingTime[EnergyDrinkEffectIndex] > 0)
        {
            float delta = Time.deltaTime;

            remainingTime[EnergyDrinkEffectIndex] -= delta;
            effectText[EnergyDrinkEffectIndex].text = remainingTime[EnergyDrinkEffectIndex].ToString("0.##") + "s";
            Debug.Log("Delta: " + delta);

            yield return null;
        }

        //remove effect
        ppBehaviour.profile = defaultProfile;
        playerShooting.damagePerShot = 20;
        playerShooting.timeBetweenBullets = 0.15f;
        playerMovement.speed = 6f;
        effectParent[EnergyDrinkEffectIndex].localScale = new Vector3(0, 0, 0);
        effects--;
    }
}