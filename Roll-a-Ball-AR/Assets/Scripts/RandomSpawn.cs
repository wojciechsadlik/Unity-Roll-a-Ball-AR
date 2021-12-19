using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject m_PlacedPrefab;

    public GameObject placedPrefab
    {
        get { return m_PlacedPrefab; }
        set { m_PlacedPrefab = value; }
    }

    [SerializeField]
    private RandomObjectSpawner m_RandomSpawner;

    public void Spawn()
    {
        m_RandomSpawner.SpawnObject(placedPrefab);
    }
}
