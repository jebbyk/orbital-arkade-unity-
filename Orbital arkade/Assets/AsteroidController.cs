using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour {

    public GameObject explosionPrefab;
    Global gl;
    public float health;
    string ct;

	// Use this for initialization
	void Start () {
        gl = GameObject.FindWithTag("global").GetComponent<Global>();
	}
	
	// Update is called once per frame
	void Update () {

        if(health <= 0)
        {
            if(ct == "bullet" || ct == "Player")
            {
                gl.points += 10;
            }
            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, transform.position, transform.rotation);
            }
            gl.AllBodyes.Remove(GetComponent<Rigidbody>());
            Destroy(gameObject);
        }
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        ct = collision.transform.tag;
        health -= collision.impulse.magnitude;
    }
}
