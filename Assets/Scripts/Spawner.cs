using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public enum ESpawnType
{
    STAR = 0,

}

public class Spawner : MonoBehaviour
{
    [SerializeField] private ESpawnType SpawnType;
    [SerializeField] private PlanetObjectController Prefab;

    [Tooltip("Collider in which it'll spawn")]
    [SerializeField] private Collider2D SpawnCollider;

    private Vector2 m_minPosition;
    private Vector2 m_maxPosition;

    private void Start()
    {
        m_minPosition = SpawnCollider.bounds.min;
        m_maxPosition = SpawnCollider.bounds.max;

        Debug.DrawLine(m_minPosition, m_maxPosition, Color.red, 5f);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        Vector2? position = GetRandomPosition();
        if (position != null)
        {
            PlanetObjectController rotateAround = Instantiate(Prefab, (Vector2) position, Quaternion.identity);
        }
    }

    public Vector2? GetRandomPosition()
    {
        Vector2 m_randomPosition = Vector2.zero;

        bool validPointFound = false;
        int numberOfTries = 0;
        while (!validPointFound && numberOfTries != 50)
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