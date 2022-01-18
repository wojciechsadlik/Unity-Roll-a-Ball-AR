using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollABallSimulation
{
    public class RandomBombSimulation : MonoBehaviour
    {
        [SerializeField]
        GameObject m_PlacedPrefab;

        public GameObject placedPrefab
        {
            get { return m_PlacedPrefab; }
            set { m_PlacedPrefab = value; }
        }

        [SerializeField]
        private RandomBombSpawnerSimulation m_RandomBombSpawner;

        public void Spawn()
        {
            m_RandomBombSpawner.SpawnBomb(placedPrefab);
        }
    }
}

