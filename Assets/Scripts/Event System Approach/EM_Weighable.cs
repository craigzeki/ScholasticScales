//Author: Craig Zeki
//Student ID: zek21003166

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EM_Weighable : EM_MassAggregator
{
    [SerializeField] private EM_WeighableParametersStruct weighableParametersStruct;
    private EM_WeighableParameters weighableParameters;
    private EM_MassAggregator massAggregator = null;
    private GameObject scaleBucket = null;
    private GameObject otherWeighable = null;

    private void OnTriggerEnter(Collider other)
    {
        switch(other.tag)
        {
            case "ScaleBucket":
                scaleBucket = other.gameObject;
                break;
            case "Weighable":
                otherWeighable = other.gameObject;
                break;

            default:
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.tag)
        {
            case "ScaleBucket":
                scaleBucket = null;
                break;
            case "Weighable":
                otherWeighable = null;
                break;

            default:
                break;
        }
    }

    private void Update()
    {
        if(scaleBucket != null)
        {

        }
        else if(otherWeighable != null)
        {

        }
        else
        {

        }
    }
}
