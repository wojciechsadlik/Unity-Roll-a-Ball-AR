using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollABallSimulation
{
    public class RespawnBombSimulation : MonoBehaviour
    {
        [SerializeField]
        private RandomBombSpawnerSimulation m_Spawner;

        private void OnDisable()
        {
            if (m_Spawner != null)
                m_Spawner.SpawnBomb(gameObject);
        }
    }

}
