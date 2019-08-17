using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public enum EReward
{
    HAT = 0,
    ITEM = 1
}

public enum EHat
{
    WIZARD = 0,
    BIRD = 1,
    CAT = 2
}

[System.Serializable]
public struct RewardData
{
    public EReward Reward;
    public EHat Hat;
    public MusicManager.ETrack Track;
    public Item Item;
}

public class Interactable : MonoBehaviour
{
    public virtual void Interact()
    {

    }
}