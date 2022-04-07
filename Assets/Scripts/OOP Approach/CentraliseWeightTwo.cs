//Author: Craig Zeki
//Student ID: zek21003166

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentraliseWeightTwo : MonoBehaviour
{
    [SerializeField] private float totalMass = 0;
    [SerializeField] private Transform myForcePoint;
    [SerializeField] Rigidbody balanceBoardRigidBody;

    public void Awake()
    {
        //myRb = GetComponent<Rigidbody>();
        Debug.Assert(myForcePoint != null, "CentraliseWeight:Awake myForcePoint cannot be null");
        Debug.Assert(balanceBoardRigidBody != null, "CentraliseWeight:Awake balanceBoardRigidBody cannot be null");
    }
    public void addMass(float mass)
    {
        totalMass += mass;
        Debug.Log("Add Mass: " + mass.ToString());

    }

    public void removeMass(float mass)
    {
        totalMass -= mass;
        Debug.Log("Remove Mass: " + mass.ToString());
    }

    private void Update()
    {
   
    }

    private void FixedUpdate()
    {
        Vector3 myForce = Vector3.down * totalMass * Physics.gravity.y * Time.deltaTime;
        

        balanceBoardRigidBody.AddForceAtPosition(myForce, myForcePoint.position);
        
    }
}
