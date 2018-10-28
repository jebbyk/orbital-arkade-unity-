using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator : MonoBehaviour {

    public Vector3 rotVector;
    Global gl;

	// Use this for initialization
	void Start () {
        gl = GameObject.FindGameObjectWithTag("global").GetComponent<Global>();
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(rotVector*gl.dt);
	}
}
