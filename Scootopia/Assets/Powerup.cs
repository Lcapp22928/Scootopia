using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ScooterMovement scooterMovement = other.GetComponent<ScooterMovement>();

        if (scooterMovement != null)
        {
            ApplySpeedBoost(scooterMovement);
            gameObject.SetActive(false);
        }
    }

    private void ApplySpeedBoost(ScooterMovement scooterMovement)
    {
        scooterMovement.ApplySpeedBoost();
    }
}