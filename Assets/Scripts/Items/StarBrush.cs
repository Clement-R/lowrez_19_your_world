using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class StarBrush : Item
{
    [SerializeField] private Spawner m_spawner;

    public override void Use()
    {
        m_spawner.Spawn();
    }
}