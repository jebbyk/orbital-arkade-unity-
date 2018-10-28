using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trailDeleter : MonoBehaviour {


    public bool delete = false;
    public float time;
    Global gl;

	// Use this for initialization
	void Start () {
        gl = GameObject.FindGameObjectWithTag("global").GetComponent<Global>();
    }
	
	// Update is called once per frame
	void Update () {
		if(delete)
        {
           
            time -= gl.dt;
               if(time <= 0)
            {
                Destroy(gameObject);
            }
        }
	}
}
