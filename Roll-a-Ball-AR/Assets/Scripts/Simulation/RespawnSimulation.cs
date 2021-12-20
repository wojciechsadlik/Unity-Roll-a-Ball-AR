using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollABallSimulation
{
    public class RespawnSimulation : MonoBehaviour
    {
        [SerializeField]
        private RandomObjectSpawnerSimulation m_Spawner;

        private void OnDisable()
        {
            if (m_Spawner != null)
                m_Spawner.SpawnObject(gameObject);
        }
    }

}
