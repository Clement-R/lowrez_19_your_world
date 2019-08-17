using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class FireworksStick : Item
{
    [SerializeField] private Transform m_spawnPosition;
    [SerializeField] private GameObject[] m_prefabs;
    [SerializeField] private AudioClip[] m_useSounds;
    [SerializeField] private AudioClip[] m_explosionSounds;

    private Dictionary<string, List<GameObject>> m_pools = new Dictionary<string, List<GameObject>>();

    public override void Use()
    {
        var go = m_prefabs[Random.Range(0, m_prefabs.Length)];

        Instantiate(
            go,
            m_spawnPosition.position,
            go.transform.rotation,
            null
        );

        SFXManager.Instance.PlaySound(m_useSounds[Random.Range(0, m_useSounds.Length)]);
        StartCoroutine(_PlayExplosionSound());
    }

    private IEnumerator _PlayExplosionSound()
    {
        yield return new WaitForSeconds(2.5f);
        SFXManager.Instance.PlaySound(m_explosionSounds[Random.Range(0, m_explosionSounds.Length)]);
    }
}