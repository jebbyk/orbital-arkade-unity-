using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    Global gl;
    public GameObject bulletPrefab;
    public GameObject explosionPrefab;
    public float rate;
    float baseRate;
    public float power;
    float time;
    public float precision;
    public float rateRandom;
    Transform t;
    public bool isShooting;
    public Rigidbody parentRB;
    public WeaponLightController wl;


	// Use this for initialization
	void Start () {
        gl = GameObject.FindGameObjectWithTag("global").GetComponent<Global>();
        t = transform;
        baseRate = rate;
    }
	
	// Update is called once per frame
	void Update () {
        time += gl.dt;
        if (time >= rate && isShooting)
        {
            rate = baseRate + Random.Range(-rateRandom / 2, rateRandom / 2);
            time = 0;
            GameObject c = Instantiate(bulletPrefab, t.position, t.rotation)as GameObject;
            c.transform.eulerAngles += new Vector3(0, Random.Range(-precision, precision), 0);
            c.GetComponent<Rigidbody>().AddForce((c.transform.forward*power));
            c.GetComponent<Rigidbody>().velocity += parentRB.velocity;
            parentRB.AddExplosionForce(Random.Range(0, precision)*c.GetComponent<Rigidbody>().mass*300, t.position, 1);
            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, t.position, t.rotation);
            }
            wl.curentIntencity = wl.maxIntencity;
        }
	}
}
