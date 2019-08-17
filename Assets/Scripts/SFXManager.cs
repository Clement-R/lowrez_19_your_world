using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance;

    [SerializeField] private OneShotSFX m_sfxPrefab;

    private void Awake()
    {
        Instance = this;
    }

    public void PlaySound(AudioClip m_clip)
    {
        var sfx = Instantiate(m_sfxPrefab, Vector2.zero, Quaternion.identity);
        sfx.Setup(m_clip);
    }
}
