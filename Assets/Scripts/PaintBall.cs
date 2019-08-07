using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PaintBall : MonoBehaviour
{
    [SerializeField] private List<Color> m_colors;
    [SerializeField] private SpriteRenderer m_paintDecal = null;
    [SerializeField] private ParticleSystem m_paintFX = null;
    [SerializeField] private float m_minTimeToLive = 0f;
    [SerializeField] private float m_maxTimeToLive = 0.5f;

    private Color m_color;

    private void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        m_color = m_colors[Random.Range(0, m_colors.Count)];
        sr.color = m_color;
    }

    private void OnCollisionEnter2D(Collision2D p_collision)
    {
        Invoke("Death", Random.Range(m_minTimeToLive, m_maxTimeToLive));
    }

    private void OnTriggerEnter2D(Collider2D p_collider)
    {
        Invoke("Death", Random.Range(m_minTimeToLive, m_maxTimeToLive));
    }

    private void Death()
    {
        SpriteRenderer decal = Instantiate(m_paintDecal, transform.position, Quaternion.identity);
        decal.color = m_color;
        PlanetObjectController rot = (PlanetObjectController) decal.gameObject.AddComponent(typeof(PlanetObjectController));

        // Spawn FX and change color
        ParticleSystem particles = Instantiate(m_paintFX, transform.position, m_paintFX.transform.rotation);
        ParticleSystem.MainModule main = particles.main;
        main.startColor = m_color;
        particles.Play();

        //TODO: Play sound

        Destroy(gameObject);
    }
}