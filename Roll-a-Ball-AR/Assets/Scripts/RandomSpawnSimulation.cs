using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnSimulation : MonoBehaviour
{
    [SerializeField]
    GameObject m_PlacedPrefab;

    /// <summary>
    /// The prefab to instantiate on touch.
    /// </summary>
    public GameObject placedPrefab
    {
        get { return m_PlacedPrefab; }
        set { m_PlacedPrefab = value; }
    }

    [SerializeField]
    private RandomObjectSpawnerSimulation m_RandomSpawner;

    public void Spawn()
    {
        m_RandomSpawner.SpawnObject(placedPrefab);
    }
}
