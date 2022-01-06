using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentraliseWeight : MonoBehaviour
{
    [SerializeField] Transform centreSpot;

    private void OnTriggerEnter(Collider other)
    {
        //other.transform.position = centreSpot.position;
        //other.attachedRigidbody.isKinematic = true;
    }
}
