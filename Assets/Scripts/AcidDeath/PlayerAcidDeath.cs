using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using playerMovement;

public class PlayerAcidDeath : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] HealthController healthController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {            
            Debug.Log("Player Died in Acid");
            playerController.AcidDeath();
        }
    }
}
