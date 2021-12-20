using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollABallSimulation
{
    public class PlaceOnPlaneSimulation : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Instantiates this prefab on a plane at the touch location.")]
        GameObject m_PlacedPrefab;

        /// <summary>
        /// The prefab to instantiate on touch.
        /// </summary>
        public GameObject placedPrefab
        {
            get { return m_PlacedPrefab; }
            set { m_PlacedPrefab = value; }
        }

        /// <summary>
        /// The object instantiated as a result of a successful raycast intersection with a plane.
        /// </summary>
        public GameObject spawnedObject { get; private set; }

        bool TryGetTouchPosition(out Vector2 touchPosition)
        {
            //if (Input.touchCount > 0)
            //{
            //    touchPosition = Input.GetTouch(0).position;
            //    return true;
            //}

            if (Input.GetMouseButton(0))
            {
                touchPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                return true;
            }

            touchPosition = default;
            return false;
        }

        // Update is called once per frame
        void Update()
        {
            if (!TryGetTouchPosition(out Vector2 touchPosition))
                return;

            Ray ray = Camera.main.ScreenPointToRay(touchPosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // Raycast hits are sorted by distance, so the first one
                // will be the closest hit.
                Pose hitPose = new Pose(hit.point, m_PlacedPrefab.transform.rotation);
                hitPose.position += Vector3.up * 0.08f;

                if (spawnedObject == null)
                {
                    spawnedObject = Instantiate(m_PlacedPrefab, hitPose.position, hitPose.rotation);
                    spawnedObject.SetActive(true);
                }
            }
        }
    }
}

