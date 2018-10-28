using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    ParticleSystem ps;
    float time;
    Global gl;


	// Use this for initialization
	void Start () {
        ps = GetComponent<ParticleSystem>();
        gl = GameObject.FindWithTag("global").GetComponent<Global>();
        time = ps.main.duration * 0.8f;
    }
	
	// Update is called once per frame
	void Update () {
        time -= gl.dt;
        if(time <= 0)
        {
            Destroy(gameObject);
        }
	}
}
