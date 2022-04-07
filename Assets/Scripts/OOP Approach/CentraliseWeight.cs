//Author: Craig Zeki
//Student ID: zek21003166

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody))]
public class CentraliseWeight : MonoBehaviour
{
    private float totalMass = 0;
    [SerializeField] private Rigidbody myRb;

    public void Awake()
    {
        //myRb = GetComponent<Rigidbody>();
        Debug.Assert(myRb != false, "CentraliseWeight:Awake myRb cannot be null");
    }
    public void addMass(float mass)
    {
        totalMass += mass;
        
    }

    public void removeMass(float mass)
    {
        totalMass -= mass;
    }

    private void Update()
    {
        myRb.mass = totalMass;
    }
}
