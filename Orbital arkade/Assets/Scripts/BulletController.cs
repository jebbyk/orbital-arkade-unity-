using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public GameObject explosion;
    public float health;
    Global gl;
    Transform t;
    public GameObject trail;
	// Use this for initialization
	void Start () {
        gl = GameObject.FindGameObjectWithTag("global").GetComponent<Global>();
        t = transform;
    }
	
	// Update is called once per frame
	void Update () {
        health -= gl.dt;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag != t.tag)
        {
            if (trail != null)
            {
                trail.transform.parent = null;
                trail.GetComponent<trailDeleter>().delete = true;
            }
            if (explosion != null)
            {
                Instantiate(explosion, t.position, t.rotation);
            }
            Destroy(gameObject);
        }
    }
}
