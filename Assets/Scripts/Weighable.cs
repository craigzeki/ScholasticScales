using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weighable : MassAggregator
{
    [SerializeField] private WeighableParametersStruct weighableParametersStruct;
    private WeighableParameters weighableParameters;
    private MassAggregator massAggregator = null;
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
