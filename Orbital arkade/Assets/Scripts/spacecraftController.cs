using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spacecraftController : MonoBehaviour {
    
    public float maneuverTrustersPower;
    public float maxShield;
    public float maxHull;
    public float maxFuel;
    [HideInInspector]
    public float curentShield, curentFuel, curentHull;
    public float generatorPower;
    [HideInInspector]
    public bool throtle, throtleBack, throtleRight, throtleLeft, isShooting;
    public float trusterPower;
    Rigidbody rb;
    public List<Weapon> weaponsList = new List<Weapon>();
    Global gl;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        gl = GameObject.FindWithTag("global").GetComponent<Global>();
        curentFuel = maxFuel;
        curentShield = maxShield;
        curentHull = maxHull;

	}
	
	// Update is called once per frame
	void Update () {
        if(curentShield < maxShield)
        {
            curentShield += generatorPower * gl.dt;
            if(curentShield > maxShield)
            {
                curentShield = maxShield;
            }
        }
        
        if (curentFuel > 0)
        {
            if (throtle)
            {
                rb.AddRelativeForce(new Vector3(0, 0, trusterPower));
                curentFuel -= trusterPower * gl.dt;
            }
            if (throtleBack)
            {
                rb.AddRelativeForce(new Vector3(0, 0, -trusterPower / 3));
                curentFuel -= trusterPower * gl.dt / 3;
            }
            if (throtleRight)
            {
                rb.AddRelativeForce(new Vector3(trusterPower / 3, 0, 0));
                curentFuel -= trusterPower * gl.dt / 3;
            }
            if (throtleLeft)
            {
                rb.AddRelativeForce(new Vector3(-trusterPower / 3, 0, 0));
                curentFuel -= trusterPower * gl.dt / 3;
            }
        }
        
        if (isShooting)
        {
            foreach(Weapon w in weaponsList)
            {
                w.isShooting = true;
            }
        }
        else
        {
            foreach (Weapon w in weaponsList)
            {
                w.isShooting = false;
            }
        }
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<Rigidbody>() != null)
        {
            curentHull -= collision.impulse.magnitude / curentShield;
            curentShield -= collision.impulse.magnitude;
        }
        if(collision.transform.tag == "planet")
        {
           // Destroy(gameObject);
        }

       
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "bonus")
        {
            //if(!collision.transform.GetComponent<BonusController>().delete)
            collision.transform.GetComponent<BonusController>().delete = true;
            collision.transform.GetComponent<BonusController>().scc = this;
        }
    }

}
