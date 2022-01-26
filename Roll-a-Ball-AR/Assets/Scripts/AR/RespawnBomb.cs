using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollABallAR
{
    public class RespawnBomb : MonoBehaviour
    {
        [SerializeField]
        private RandomBombSpawner m_RandomBombSpawner;

        private void OnDisable()
        {
            if (m_RandomBombSpawner != null)
                m_RandomBombSpawner.SpawnBomb(gameObject);
        }
    }

}
