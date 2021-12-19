using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField]
    private RandomObjectSpawner m_Spawner;

    private void OnDisable()
    {            
        if (m_Spawner != null)
            m_Spawner.SpawnObject(gameObject);
    }
}
