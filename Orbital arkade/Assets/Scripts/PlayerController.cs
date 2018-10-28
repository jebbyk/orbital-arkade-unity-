using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    
    Global gl;
    Transform st;
    spacecraftController scc;

	// Use this for initialization
	void Start () {
        gl = GameObject.FindGameObjectWithTag("global").GetComponent<Global>();
        st = GameObject.FindWithTag("scope").transform;
        scc = GetComponent<spacecraftController>();
    }

    // Update is called once per frame
    void Update() {
        transform.LookAt(st);
        if (Input.GetAxis("Vertical") > 0.5)
        {
            scc.throtle = true;
        }
        else
        {
            scc.throtle = false;
        }
        
        if (Input.GetAxis("Vertical") < -0.5)
        {
            scc.throtleBack = true;
        }
        else
        {
            scc.throtleBack = false;
        }

        if (Input.GetAxis("Horizontal") > 0.5)
        {
            scc.throtleRight = true;
        }
        else
        {
            scc.throtleRight = false;
        }

        if (Input.GetAxis("Horizontal") <-0.5)
        {
            scc.throtleLeft = true;
        }
        else
        {
            scc.throtleLeft = false;
        }


        if (Input.GetMouseButton(0))
        {
            scc.isShooting = true;
        }
        else
        {
            scc.isShooting = false;
        }
        
	}
}
