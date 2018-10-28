using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timedSpawner : MonoBehaviour {

    public GameObject prefab;
    public float rate;
    float time;
    public float rateDecreasing;
    Global gl;
    Vector3 v;
    public float distMax;
    public float distMin;
    Transform t;
    public bool randomizeRotation;

    // Use this for initialization
    void Start () {
        gl = GameObject.FindWithTag("global").GetComponent<Global>();
        t = transform;
    }
	
	// Update is called once per frame
	void Update () {

        time += gl.dt * rate;
        if (time >= 1)
        {
            rate *= rateDecreasing;
            time = 0;
            GameObject c = Instantiate(prefab, t.position, t.rotation) as GameObject;
            Vector3 sr = c.transform.eulerAngles;
            Vector3 v = new Vector3(0, Random.Range(-180, 180), 0);
            c.transform.eulerAngles = v;
            v = c.transform.forward.normalized * Random.Range(distMin, distMax);
            c.transform.position += v;
            if (!randomizeRotation)
            {
                c.transform.eulerAngles = sr;
            }
        }

    }
}
