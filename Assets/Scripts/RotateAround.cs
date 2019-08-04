using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class RotateAround : MonoBehaviour
{
    [SerializeField] private float m_rotSpeed = 0.1f;
    [SerializeField] private Transform m_around;

    private void Awake()
    {
        transform.parent = null;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
            transform.RotateAround(m_around.transform.position, Vector3.forward, m_rotSpeed);
        else if (Input.GetKey(KeyCode.A))
            transform.RotateAround(m_around.transform.position, Vector3.forward, -m_rotSpeed);

        // transform.Rotate(Vector3.forward, m_rotSpeed);
        // transform.RotateAround(m_around.transform.position, Vector3.forward, m_rotSpeed)
    }

    public void Setup(Transform p_transform, float p_speed)
    {
        m_around = p_transform;
        m_rotSpeed = p_speed;
    }
}