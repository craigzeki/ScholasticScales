using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CentraliseWeightTwo : MonoBehaviour
{
    private float totalMass = 0;
    private Rigidbody myRb;
    [SerializeField] private Collider colliderOne;
    [SerializeField] private GameObject forcePointOne;
    [SerializeField] private Collider colliderTwo;
    [SerializeField] private GameObject forcePointTwo;

    [SerializeField] private float massColliderOne = 0;
    [SerializeField] private float massColliderTwo = 0;

    public void Awake()
    {
        myRb = GetComponent<Rigidbody>();
        Debug.Assert(myRb != false, "CentraliseWeight:Awake myRb cannot be null");
    }
    public void addMass(float mass, Collider collider)
    {
        totalMass += mass;
        if(collider == colliderOne)
        {
            massColliderOne += mass;
        }
        else if(collider == colliderTwo)
        {
            massColliderTwo += mass;
        }

    }

    public void removeMass(float mass, Collider collider)
    {
        totalMass -= mass;
        if (collider == colliderOne)
        {
            massColliderOne -= mass;
        }
        else if (collider == colliderTwo)
        {
            massColliderTwo -= mass;
        }
    }

    private void FixedUpdate()
    {
        Vector3 forceOne = Vector3.down * massColliderOne * Physics.gravity.y;
        Vector3 forceTwo = Vector3.down * massColliderTwo * Physics.gravity.y;

        myRb.AddForceAtPosition(forceOne, forcePointOne.transform.position);
        myRb.AddForceAtPosition(forceTwo, forcePointTwo.transform.position);
    }
}
