using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scopeScr : MonoBehaviour {

    Transform t;
    Global gl;
    public float speed;
    Transform ct;
    public Vector2 r;
    public float viewSizeMult;
    float startPosionY;
	// Use this for initialization
	void Start () {
        r = r * viewSizeMult;
        gl = GameObject.FindGameObjectWithTag("global").GetComponent<Global>();
        t = transform;
        ct = GameObject.FindWithTag("camera").transform;
        startPosionY = t.position.y;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 v = new Vector3();
        v.x = Input.GetAxis("MouseX")*speed;
        v.z = Input.GetAxis("MouseY")*speed;
        t.position += v;

        v = t.position;
        if(v.x > ct.position.x + r.x)
        {
            v.x = ct.position.x + r.x;
        }
        if (v.x < ct.position.x - r.x)
        {
            v.x = ct.position.x - r.x;
        }
        if (v.z > ct.position.z + r.y)
        {
            v.z = ct.position.z + r.y;
        }
        if (v.z < ct.position.z - r.y)
        {
            v.z = ct.position.z - r.y;
        }
        v.y = startPosionY;
        t.position = v;
    }
}
