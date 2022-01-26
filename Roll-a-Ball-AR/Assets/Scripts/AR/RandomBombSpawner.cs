using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


namespace RollABallAR
{
    [RequireComponent(typeof(ARRaycastManager))]
    public class RandomBombSpawner : MonoBehaviour
    {
        void Awake()
        {
            m_RaycastManager = GetComponent<ARRaycastManager>();
        }

        public void SpawnBomb(GameObject go)
        {
            StartCoroutine(SpawnBombCoroutine(go));
        }

        private IEnumerator SpawnBombCoroutine(GameObject go)
        {
            yield return null;

            while (!TrySpawnBomb(go))
            {
                yield return new WaitForSeconds(0.30f);
            }
        }
      
        private bool TrySpawnBomb(GameObject go)
        {
            Vector2 randomPos = new Vector2(Random.Range(0.0f, Screen.width), Random.Range(0.0f, Screen.height));

            if (m_RaycastManager.Raycast(randomPos, s_Hits, TrackableType.PlaneWithinPolygon))
            {
                if (s_Hits[0].trackable.gameObject.tag == "Floor")
                {
                    var hitPose = s_Hits[0].pose;
                    hitPose.position += Vector3.up * 0.06f;

                    go.transform.position = hitPose.position;
                    go.transform.rotation = hitPose.rotation;

                    go.SetActive(true);

                    return true;
                }
            }

            return false;
        }

        static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

        ARRaycastManager m_RaycastManager;
    }
}


