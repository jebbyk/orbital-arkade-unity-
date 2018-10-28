using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {

    public GameObject asteroidPrefab;
    public float rate;
    float time;
    Global gl;
    Vector3 v;
    public float distMax;
    public float distMin;
    public float velMax;
    public float velMin;
    public float angVelRand;
    Transform t;

	// Use this for initialization
	void Start () {
        gl = GameObject.FindWithTag("global").GetComponent<Global>();
        t = transform;
	}
	
	// Update is called once per frame
	void Update () {
        time += gl.dt * rate;
        if(time >= 1)
        {
            time = 0;
            GameObject c = Instantiate(asteroidPrefab, t.position, t.rotation)as GameObject;
            Vector3 v =  new Vector3(0,Random.Range(-180, 180),0);
            c.transform.eulerAngles = v;
            v = c.transform.forward.normalized * Random.Range(distMin, distMax);
            c.transform.position += v;
            v = new Vector3(0,90, 0);
            c.transform.eulerAngles += v;
            Rigidbody rb = c.GetComponent<Rigidbody>();
            rb.AddForce(c.transform.forward.normalized * Random.RandomRange(velMin, velMax) * rb.mass);
            rb.AddRelativeTorque(new Vector3(0,Random.Range(-angVelRand / 2, angVelRand / 2),0));
        }
	}
}
