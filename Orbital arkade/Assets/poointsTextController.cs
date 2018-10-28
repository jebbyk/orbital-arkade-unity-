using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poointsTextController : MonoBehaviour {

    Global gl;
    TextMesh tm;

	// Use this for initialization
	void Start () {
        gl = GameObject.FindWithTag("global").GetComponent<Global>();
        tm = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
        tm.text = gl.points.ToString();
	}
}
