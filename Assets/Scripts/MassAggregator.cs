using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MassAggregator : MonoBehaviour
{
    private UnityAction<string> addMassEventListener;
    private UnityAction<string> removeMassEventListener;
    protected float aggregatedMass = 0.0f;

    private void Awake()
    {
        addMassEventListener = new UnityAction<string>(AddMass);
        removeMassEventListener = new UnityAction<string>(RemoveMass);
    }

    private void OnEnable()
    {
        EventManager.StartListening("AddMass", addMassEventListener);
        EventManager.StartListening("RemoveMass", removeMassEventListener);
    }

    private void OnDisable()
    {
        EventManager.StopListening("AddMass", addMassEventListener);
        EventManager.StopListening("RemoveMass", removeMassEventListener);
    }

    private void AddMass(string jsonVars)
    {
        WeighableParameters weighableParameters = ScriptableObject.CreateInstance<WeighableParameters>();
        JsonUtility.FromJsonOverwrite(jsonVars, weighableParameters);
        aggregatedMass += weighableParameters.weighableParametersStruct.mass;

    }

    private void RemoveMass(string jsonVars)
    {
        WeighableParameters weighableParameters = ScriptableObject.CreateInstance<WeighableParameters>();
        JsonUtility.FromJsonOverwrite(jsonVars, weighableParameters);
        aggregatedMass -= weighableParameters.weighableParametersStruct.mass;
        if (aggregatedMass < 0) aggregatedMass = 0;

    }
}
