using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour {


    Global global;
    Transform t;
    Rigidbody rb;
    public Vector3 startForce;
    public Vector3 startAngularForce;


	// Use this for initialization
	void Start () {
        global = GameObject.FindWithTag("global").GetComponent<Global>();
        t = transform;
        rb = GetComponent<Rigidbody>();
        global.AllBodyes.Add(rb);
        rb.AddForce(startForce*rb.mass);
        rb.AddTorque(startAngularForce);
	}
	

    


	// Update is called once per frame
	void Update () {
        foreach (Rigidbody arb in global.AllBodyes)
        {
            if (arb != null)
            {
                if (arb != rb)
                {
                    Vector3 v = arb.position - t.position;
                    v = ((rb.mass * arb.mass) / (Mathf.Pow(v.magnitude, global.globalPower))) * v.normalized * global.g * global.dt;
                    rb.AddForce(v);
                }
            }
           // else { global.AllBodyes.Remove(arb); }
        }
    }
       
}
