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
            MusicManager.Instance.UnlockTrack(p_reward.Track);
            m_hatManager.ChangeHat(p_reward.Hat);
        }
        else if (p_reward.Reward == EReward.ITEM)
        {
            var go = Instantiate(p_reward.Item);
            HandsController.Instance.GrabNewItem(go);
        }
    }
}