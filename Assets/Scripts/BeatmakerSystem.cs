using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class BeatmakerSystem : MonoBehaviour
{
    [SerializeField] private int m_bpm = 120;
    [SerializeField] private int m_tempo = 4;
    [SerializeField] private Image m_bpmImg;

    private float m_next = 0f;
    private int m_previousBPM = 0;
    private int m_index = 1;
    private float m_time = 0f;

    private void Update()
    {
        if (m_previousBPM != m_bpm)
        {
            UpdateBPM();
            m_previousBPM = m_bpm;
        }

        m_time += Time.unscaledDeltaTime;

        if (Time.unscaledTime > m_next)
        {
            m_next = Time.unscaledTime + (BeatForBPM() / 1000f);
            m_index++;
            if (m_index > 4)
            {
                m_time = 0f;
                m_index = 1;
            }

            UpdateUI();
        }

    }

    private int BeatForBPM()
    {
        return 60000 / m_bpm;
    }

    private float TimeForBarInSeconds()
    {
        return (BeatForBPM() * 4f) / 1000f;
    }

    private void UpdateBPM()
    {
        m_time = 0f;
        m_next = Time.unscaledTime + (BeatForBPM() / 1000f);
        m_index = 1;
        UpdateUI();
    }

    private void UpdateUI()
    {
        m_bpmImg.fillAmount = m_time / TimeForBarInSeconds();
    }
}