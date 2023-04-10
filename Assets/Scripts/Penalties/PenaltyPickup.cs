using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenaltyPickup : MonoBehaviour
{
    [SerializeField] bool _isGoodPickup = false;

    private PenaltySystem _penaltySystem;

    private void Awake()
    {
        _penaltySystem = FindObjectOfType<PenaltySystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "Player") return;

        if (_isGoodPickup) _penaltySystem.OnReward();
        else _penaltySystem.OnPenalty();

        Destroy(gameObject);
    }
}
