using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_Pickup : MonoBehaviour
{
    private PenaltySystem _penaltySystem;

    private void Awake()
    {
        _penaltySystem = FindObjectOfType<PenaltySystem>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "Player") return;

        _penaltySystem.OnHPPickup();

        Destroy(gameObject);
    }
}
