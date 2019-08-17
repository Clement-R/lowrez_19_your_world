using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ConfigurationManager : MonoBehaviour
{
    public static ConfigurationManager Instance;

    public Transform Planet
    {
        get
        {
            return m_planet;
        }
    }
    public float RotSpeed
    {
        get
        {
            return m_rotSpeed;
        }
    }

    public Collider2D StarCollider
    {
        get
        {
            return m_starCollider;
        }
    }

    [SerializeField] private Transform m_planet;
    [SerializeField] private float m_rotSpeed;
    [SerializeField] private Collider2D m_starCollider;

    private void Awake()
    {
        Instance = this;
    }
}