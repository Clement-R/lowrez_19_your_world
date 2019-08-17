using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    public enum ETrack
    {
        DRUM = 0,
        KOTO = 1,
        BASS = 2
    }

    [SerializeField] private AudioSource m_drumTrack;
    [SerializeField] private AudioSource m_kotoTrack;
    [SerializeField] private AudioSource m_bassTrack;

    private AudioSource m_lastTrack = null;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        MuteAll();
    }

    private void MuteAll()
    {
        m_bassTrack.volume = 0;
        m_kotoTrack.volume = 0;
        m_drumTrack.volume = 0;
    }

    public void UnlockTrack(ETrack p_track)
    {
        if (m_lastTrack != null)
            m_lastTrack.volume = 0;

        switch (p_track)
        {
            case ETrack.BASS:
                m_lastTrack = m_bassTrack;
                m_bassTrack.volume = 1;
                break;

            case ETrack.DRUM:
                m_lastTrack = m_drumTrack;
                m_drumTrack.volume = 0.25f;
                break;

            case ETrack.KOTO:
                m_lastTrack = m_kotoTrack;
                m_kotoTrack.volume = 1;
                break;
        }
    }
}