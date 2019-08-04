using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class RewardSystem : MonoBehaviour
{
    public Action<RewardData> OnRewardAcquired;
    public static RewardSystem Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void RewardAcquired(RewardData p_reward)
    {
        Debug.Log("Acquire reward : " + p_reward.Reward + "  " + p_reward.Hat);
        OnRewardAcquired?.Invoke(p_reward);
    }
}