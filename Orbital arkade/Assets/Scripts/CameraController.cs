using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    Transform t;
    public Transform target;
    Vector3 oldPosition;
    public float speed;
    float startY;
    public float yOverSpeedMult;
    Global gl;
	// Use this for initialization
	void Start () {
        t = transform;
        startY = t.position.y;
        gl = GameObject.FindGameObjectWithTag("global").GetComponent<Global>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 v = target.position - t.position;
        float d;
        v.y = 0;
        d = v.magnitude;
        t.position += v * speed * gl.dt;
        v = t.position;
        v = (new Vector3(v.x, startY + d * yOverSpeedMult, v.z));
        t.position = v;
	}
}
