using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollABallSimulation
{
    public class RandomBombSpawnerSimulation : MonoBehaviour
    {
        public void SpawnBomb(GameObject go)
        {
            StartCoroutine(SpawnBombCoroutine(go));
        }

        private IEnumerator SpawnBombCoroutine(GameObject go)
        {
            yield return null;

            while (!TrySpawnBomb(go))
            {
                yield return new WaitForSeconds(0.35f);
            }
        }
      

        private bool TrySpawnBomb(GameObject go)
        {
            Vector2 randomPos = new Vector2(Random.Range(0.0f, Screen.width), Random.Range(0.0f, Screen.height));
            Ray ray = Camera.main.ScreenPointToRay(randomPos);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject.tag == "Floor")
                {
                    Pose hitPose = new Pose(hit.point, gameObject.transform.rotation);
                    hitPose.position += Vector3.up * 0.06f;

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


