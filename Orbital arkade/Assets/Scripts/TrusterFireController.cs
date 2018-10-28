using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrusterFireController : MonoBehaviour {

    public spacecraftController scc;
    public bool forward;
    public bool backward;
    public bool right;
    public bool left;
    ParticleSystem ps;

	// Use this for initialization
	void Start () {
        ps = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        if (scc.curentFuel > 0)
        {
            if (forward)
            {
                if (scc.throtle)
                {
                    ps.enableEmission = true;
                }
                else
                {
                    ps.enableEmission = false;
                }
            }
            if (backward)
            {
                if (scc.throtleBack)
                {
                    ps.enableEmission = true;
                }
                else
                {
                    ps.enableEmission = false;
                }
            }

            if (right)
            {
                if (scc.throtleRight)
                {
                    ps.enableEmission = true;
                }
                else
                {
                    ps.enableEmission = false;
                }
            }
            if (left)
            {
                if (scc.throtleLeft)
                {
                    ps.enableEmission = true;
                }
                else
                {
                    ps.enableEmission = false;
                }
            }
        }
        else
        {
            ps.enableEmission = false;
        }
    }
}
