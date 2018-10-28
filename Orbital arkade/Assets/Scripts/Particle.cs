using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour {

    Global global;
    Rigidbody rb;
	// Use this for initialization
	void Start () {
        global = GameObject.FindWithTag("global").GetComponent<Global>();
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		foreach(Rigidbody arb in global.AllBodyes)
        {
            if (arb != null)
            {
                Vector3 v = arb.position - rb.position;
                v = ((arb.mass * rb.mass) / (Mathf.Pow(v.magnitude, global.globalPower))) * v.normalized * global.g * global.dt;
                rb.AddForce(v);
            }
           
        }
	}
}
