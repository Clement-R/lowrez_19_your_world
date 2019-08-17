using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

[System.Serializable]
public class HatToItem
{
    public EHat Hat;
    public GameObject Item;
}

public class HatManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem m_particles;
    [SerializeField] private List<HatToItem> m_hats;
    [SerializeField] private AudioClip m_interact;

    private GameObject m_current = null;

    public void ChangeHat(EHat p_hat)
    {
        HatToItem hatData = m_hats.FirstOrDefault(h => h.Hat == p_hat);
        if (hatData == null)
            return;

        if (m_current == hatData.Item)
            return;

        if (m_current != null)
        {
            m_current.SetActive(false);
        }

        hatData.Item.SetActive(true);
        m_current = hatData.Item;

        m_particles.Play();

        SFXManager.Instance.PlaySound(m_interact);
    }
}