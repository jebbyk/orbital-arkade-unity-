using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitPredictor : MonoBehaviour {

    public GameObject dotPrefab;
    public int dotsCount;
    public float predictionTime;
    float simDt;
    Global gl;
    List<GameObject> dots = new List<GameObject>();
    Rigidbody rb;
    Transform t;
    Vector3 prevPos, prevVel, curPos, curVel;
    public float mult;
    public float smoothSpeed;

	// Use this for initialization
	void Start () {
        gl = GameObject.FindWithTag("global").GetComponent<Global>();
        t = transform;
        rb = GetComponent<Rigidbody>();

        for(int i = dotsCount; i > 0; i--)
        {
            GameObject c = Instantiate(dotPrefab) as GameObject;
            dots.Add(c);
        }

        predictionTime /= 60;

    }
	
	// Update is called once per frame
	void Update () {
        simDt = predictionTime / dotsCount;
        prevPos = curPos;
        prevVel = curVel;
        curPos = t.position;
        curVel = rb.velocity;

        for(int i = 0; i < dotsCount; i++)
        {
            foreach (Rigidbody arb in gl.AllBodyes)
            {
                if (arb != rb && arb != null)
                {
                    Vector3 v = arb.position -curPos;
                    v = ((arb.mass )/ (Mathf.Pow(v.magnitude, gl.globalPower))) * v.normalized * gl.g * simDt;
                    v.y = 0;
                    curVel += v; 
                }
            }
            curPos += curVel * simDt * mult;
            dots[i].transform.position += (curPos - dots[i].transform.position) * gl.dt * smoothSpeed;
        }

		
	}
}
