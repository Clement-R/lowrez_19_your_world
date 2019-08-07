using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlanetObjectController : MonoBehaviour
{
    private float m_rotSpeed = 0.1f;
    private Transform m_around;

    private void Start()
    {
        transform.parent = null;
        Setup(ConfigurationManager.Instance.Planet, ConfigurationManager.Instance.RotSpeed);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
            transform.RotateAround(m_around.transform.position, Vector3.forward, m_rotSpeed);
        else if (Input.GetKey(KeyCode.A))
            transform.RotateAround(m_around.transform.position, Vector3.forward, -m_rotSpeed);
    }

    private void Setup(Transform p_transform, float p_speed)
    {
        m_around = p_transform;
        m_rotSpeed = p_speed;
    }
}