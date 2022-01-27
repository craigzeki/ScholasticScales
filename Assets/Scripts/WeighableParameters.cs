using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct WeighableParametersStruct
{
    public float mass;
}

public class WeighableParameters : ScriptableObject
{
    public WeighableParametersStruct weighableParametersStruct;
}
