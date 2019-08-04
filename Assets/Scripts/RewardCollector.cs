using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class RewardCollector : MonoBehaviour
{
    [SerializeField] private HatManager m_hatManager;

    private void Start()
    {
        RewardSystem.Instance.OnRewardAcquired += GetReward;
    }

    private void GetReward(RewardData p_reward)
    {
        if (p_reward.Reward == EReward.HAT)
        {
            m_hatManager.ChangeHat(p_reward.Hat);
        }
    }
}