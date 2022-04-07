//Author: Craig Zeki
//Student ID: zek21003166

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct EM_WeighableParametersStruct
{
    public float mass;
}

public class EM_WeighableParameters : ScriptableObject
{
    public EM_WeighableParametersStruct weighableParametersStruct;
}
