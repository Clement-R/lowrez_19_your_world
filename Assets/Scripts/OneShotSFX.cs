using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShotSFX : MonoBehaviour
{
    [SerializeField] private AudioSource m_audioSource;

    public void Setup(AudioClip p_clip)
    {
        m_audioSource.clip = p_clip;
        m_audioSource.Play();
        Destroy(gameObject, m_audioSource.clip.length + 0.1f);
    }
}
