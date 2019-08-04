using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float m_rotSpeed = 0.1f;

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
            transform.Rotate(Vector3.forward, m_rotSpeed);
        else if (Input.GetKey(KeyCode.A))
            transform.Rotate(Vector3.forward, -m_rotSpeed);
    }
}