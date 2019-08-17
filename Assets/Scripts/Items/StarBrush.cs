using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class StarBrush : Item
{
    [SerializeField] private Spawner m_spawner;
    [SerializeField] private AudioClip m_spawnSound;

    public override void Use()
    {
        m_spawner.Spawn();
        SFXManager.Instance.PlaySound(m_spawnSound);
    }
}