using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class RewardInteractable : Interactable
{
    [SerializeField] private RewardData m_reward;

    public override void Interact()
    {
        RewardSystem.Instance.RewardAcquired(m_reward);
    }
}