﻿using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public enum ESpawnType
{
    STAR = 0,

}

public class Spawner : MonoBehaviour
{
    [SerializeField] private ESpawnType SpawnType;
    [SerializeField] private RotateAround Prefab;

    [Tooltip("Collider in which it'll spawn")]
    [SerializeField] private Collider2D SpawnCollider;

    private Vector2 m_minPosition;
    private Vector2 m_maxPosition;

    private void Start()
    {
        m_minPosition = SpawnCollider.transform.position - SpawnCollider.bounds.extents;
        m_maxPosition = SpawnCollider.transform.position + SpawnCollider.bounds.extents;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        Vector2? position = GetRandomPosition();
        if (position != null)
        {
            RotateAround rotateAround = Instantiate(Prefab, (Vector2) position, Quaternion.identity);
            rotateAround.Setup(GameObject.FindGameObjectWithTag("Planet").transform, 0.5f);
        }
    }

    public Vector2? GetRandomPosition()
    {
        Vector2 m_randomPosition = Vector2.zero;

        bool validPointFound = false;
        int numberOfTries = 0;
        while (!validPointFound || numberOfTries != 50)
        {
            // Get a random position in collider bounds
            m_randomPosition.x = Random.Range(m_minPosition.x, m_maxPosition.x);
            m_randomPosition.y = Random.Range(m_minPosition.y, m_maxPosition.y);

            // Check if point in collider
            if (SpawnCollider.OverlapPoint(m_randomPosition))
                validPointFound = true;

            numberOfTries++;
        }

        if (validPointFound)
            return m_randomPosition;
        else
            return null;
    }
}