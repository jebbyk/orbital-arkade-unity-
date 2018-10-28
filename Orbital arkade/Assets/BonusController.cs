using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusController : MonoBehaviour {

    Animation a;
    public bool delete = false, i = false, e = false;
    public spacecraftController scc;
    public float destroingSpeed;
        float time;
    Global gl;
    public GameObject particlePrefab;
    public float lifeTime;

	// Use this for initialization
	void Start () {
        gl = GameObject.FindWithTag("global").GetComponent<Global>();
        a = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {

        lifeTime -= gl.dt;
        if(lifeTime <= 0)
        {
            delete = true;
        }

        if(i)
        {
            time += gl.dt * destroingSpeed;
            if(time > 0.2 && !e)
            {
                e = !e;
                Instantiate(particlePrefab, transform.position, transform.rotation);
            }
            if(time > 1)
            {
                Destroy(transform.parent.gameObject);
            }
        }

        if(delete && !i)
        {
            i = !i;
            a.Play("BonusOut");
            if (scc != null)
            {
                scc.curentFuel = scc.maxFuel;
            }
        }
	}
}
