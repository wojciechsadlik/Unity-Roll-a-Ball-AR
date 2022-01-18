using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollABallAR
{
    public class RandomBomb : MonoBehaviour
    {
        [SerializeField]
        GameObject m_PlacedPrefab;

        public GameObject placedPrefab
        {
            get { return m_PlacedPrefab; }
            set { m_PlacedPrefab = value; }
        }

        [SerializeField]
        private RandomBombSpawner m_RandomBombSpawner;

        public void Spawn()
        {
            m_RandomBombSpawner.SpawnBomb(placedPrefab);
        }
    }
}

