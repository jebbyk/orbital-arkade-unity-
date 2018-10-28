using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLightController : MonoBehaviour {

    Global gl;
    Light l;
    public float flickeringFactor;
    public float fadeSpeed;
    public float curentIntencity;
    public float maxIntencity;

    // Use this for initialization
    void Start () {
        l = GetComponent<Light>();
        gl = GameObject.FindWithTag("global").GetComponent<Global>();
    }
	
	// Update is called once per frame
	void Update () {
        if (l != null)
        {
            curentIntencity -= curentIntencity * fadeSpeed * gl.dt;
            if (curentIntencity < 0.01)
            {
                l.enabled = false;
            }
            else { l.enabled = true; }
            l.intensity = curentIntencity + Random.Range(-flickeringFactor * curentIntencity, flickeringFactor * curentIntencity);
        }
    }
}
