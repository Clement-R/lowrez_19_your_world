using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class FireworksStick : Item
{
    [SerializeField] private Transform m_spawnPosition;
    [SerializeField] private GameObject[] m_prefabs;

    private Dictionary<string, List<GameObject>> m_pools = new Dictionary<string, List<GameObject>>();

    private void Start()
    {
        // foreach (var prefab in m_prefabs)
        // {
        //     List<GameObject> pool = new List<GameObject>();

        //     for (int i = 0; i < 50; i++)
        //     {
        //         var go = Instantiate(prefab, Vector2.zero, Quaternion.identity);
        //         go.SetActive(false);
        //         pool.Add(go);
        //     }

        //     m_pools.Add(prefab.name, pool);
        // }
    }

    public override void Use()
    {
        // string name = m_prefabs[Random.Range(0, m_prefabs.Length)].name;
        // var go = m_pools[name].FirstOrDefault(e => e.activeInHierarchy == false);
        // go.transform.position = m_spawnPosition.position;

        var go = m_prefabs[Random.Range(0, m_prefabs.Length)];

        Instantiate(
            go,
            m_spawnPosition.position,
            go.transform.rotation,
            null
        );
    }
}