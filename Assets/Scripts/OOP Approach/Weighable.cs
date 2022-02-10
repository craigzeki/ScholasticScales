using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Weighable : MonoBehaviour
{
    [SerializeField] private float myMass;
    private Rigidbody myRB;

    [SerializeField] private GameObject myScales = null;
    private GameObject collidingWeighable = null;

    public float MyMass { get => myMass; }
    public GameObject MyScales { get => myScales;}

    private bool scalesChanged = false;
    private int numOfCollisions = 0;

    private void Awake()
    {
        myRB = GetComponent<Rigidbody>();
        Debug.Assert(myRB != null, "Weighable:Awake:Assert myRB cannot be null");
        myMass = myRB.mass;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(scalesChanged)
        {
            
            if(myScales != null)
            {
                Debug.Log(this.gameObject.name.ToString() + ": Scales Changed: " + myScales.name.ToString());
                //myScales.GetComponent<CentraliseWeight>().addMass(myMass);
            }
            else { Debug.Log(this.gameObject.name.ToString() + "Scales Null"); }
            
            scalesChanged = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        numOfCollisions++;
        myRB.mass = 0;

        switch (collision.gameObject.tag)
        {
            case "Scales":
                myScales = collision.gameObject;
                myScales.GetComponent<CentraliseWeight>().addMass(myMass);
                scalesChanged = true;
                break;

            case "WeighableObject":
                collidingWeighable = collision.gameObject;
                if (myScales == null)
                {
                    myScales = collision.gameObject.GetComponent<Weighable>().MyScales;
                    if (myScales != null)
                    {
                        myScales.GetComponent<CentraliseWeight>().addMass(myMass);
                        scalesChanged = true;
                    }

                }
                break;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        
        /*
        //if touching something, check if that something is connected to the scales, if yes, add this objects weight to the scales also
 

        switch(collision.gameObject.tag)
        {
            case "Scales":
                myScales = collision.gameObject;
                scalesChanged = true;
                break;

            case "WeighableObject":
                collidingWeighable = collision.gameObject;
                if (myScales == null)
                {
                    myScales = collision.gameObject.GetComponent<Weighable>().MyScales;
                    if(myScales != null) { scalesChanged = true; }

                }
                break;
        }*/
    }

    private void OnCollisionExit(Collision collision)
    {
        
        if((--numOfCollisions == 0) || (collision.gameObject.tag == "Scales"))
        {
            myRB.mass = MyMass;
            if(myScales != null)
            {
                myScales.GetComponent<CentraliseWeight>().removeMass(myMass);
                myScales = null;
                scalesChanged = true;
            }
            
        }

        
    }
}
