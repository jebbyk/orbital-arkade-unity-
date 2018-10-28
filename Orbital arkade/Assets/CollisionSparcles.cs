using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSparcles : MonoBehaviour {

    public GameObject sparclesPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 p = collision.contacts[0].point;
        GameObject c = Instantiate(sparclesPrefab, p, collision.transform.rotation) as GameObject;
        c.GetComponent<ParticleSystem>().startSize = collision.impulse.magnitude;
    }
}
