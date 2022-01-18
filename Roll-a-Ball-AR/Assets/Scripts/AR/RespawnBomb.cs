using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollABallAR
{
    public class RespawnBomb : MonoBehaviour
    {
        [SerializeField]
        private RandomBombSpawner m_Spawner;

        private void OnDisable()
        {
            if (m_Spawner != null)
                m_Spawner.SpawnBomb(gameObject);
        }
    }

}
