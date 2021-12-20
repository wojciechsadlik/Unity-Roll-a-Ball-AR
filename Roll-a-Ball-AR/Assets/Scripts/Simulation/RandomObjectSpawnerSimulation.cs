using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollABallSimulation
{
    public class RandomObjectSpawnerSimulation : MonoBehaviour
    {
        public void SpawnObject(GameObject go)
        {
            StartCoroutine(SpawnObjectCoroutine(go));
        }

        private IEnumerator SpawnObjectCoroutine(GameObject go)
        {
            yield return null;

            while (!TrySpawnObject(go))
            {
                yield return new WaitForSeconds(0.25f);
            }
        }

        private bool TrySpawnObject(GameObject go)
        {
            Vector2 randomPos = new Vector2(Random.Range(0.0f, Screen.width), Random.Range(0.0f, Screen.height));
            Ray ray = Camera.main.ScreenPointToRay(randomPos);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject.tag == "Floor")
                {
                    Pose hitPose = new Pose(hit.point, gameObject.transform.rotation);
                    hitPose.position += Vector3.up * 0.08f;

                    go.transform.position = hitPose.position;
                    go.transform.rotation = hitPose.rotation;

                    go.SetActive(true);

                    return true;
                }
            }

            return false;
        }
    }
}


