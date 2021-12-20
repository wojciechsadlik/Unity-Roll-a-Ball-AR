using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollABallSimulation
{
    public class RandomSpawnSimulation : MonoBehaviour
    {
        [SerializeField]
        GameObject m_PlacedPrefab;

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
}

