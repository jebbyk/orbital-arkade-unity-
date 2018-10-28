using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBarController : MonoBehaviour {

    public spacecraftController scc;
    float maxShield;
    float curentShield;
    public float smoothSpeed;
    float maxScale;
    float curScale;
    Transform t;
    Global gl;
	// Use this for initialization
	void Start () {
        maxShield = scc.maxShield;
        t = transform;
        maxScale = t.localScale.x;
        gl = GameObject.FindWithTag("global").GetComponent<Global>();
	}
	
	// Update is called once per frame
	void Update () {
        curentShield = scc.curentShield;
        curScale += ((curentShield / maxShield * maxScale) - curScale)*gl.dt*smoothSpeed;
        if (curScale < 0)
        {
            curScale = 0;
        }
        Vector3 v = new Vector3(curScale,t.localScale.y,t.localScale.z);
      
        t.localScale = v;
	}
}
