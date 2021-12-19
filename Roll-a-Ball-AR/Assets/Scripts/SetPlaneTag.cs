using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class SetPlaneTag : MonoBehaviour
{
    void Start()
    {
        ARPlane arPlane = GetComponent<ARPlane>();

        switch (arPlane.alignment)
        {
            case UnityEngine.XR.ARSubsystems.PlaneAlignment.HorizontalUp:
                gameObject.tag = "Floor";
                break;
            case UnityEngine.XR.ARSubsystems.PlaneAlignment.Vertical:
                gameObject.tag = "Wall";
                break;
        };
    }
}
