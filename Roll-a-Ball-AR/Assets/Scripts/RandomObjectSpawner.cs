using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class RandomObjectSpawner : MonoBehaviour
{
    void Awake()
    {
        m_RaycastManager = GetComponent<ARRaycastManager>();
    }

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

        if (m_RaycastManager.Raycast(randomPos, s_Hits, TrackableType.PlaneWithinPolygon))
        {
            if (s_Hits[0].trackable.gameObject.tag == "Floor")
            {
                var hitPose = s_Hits[0].pose;
                hitPose.position += Vector3.up * 0.08f;

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
