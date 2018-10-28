using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrusterLightController : MonoBehaviour {

    public spacecraftController scc;
    Global gl;
    Light l;
    public float flickeringFactor;
    public float maxIntancity;
    public float fadeSpeed;
    public float fadeInSpeed;
    float curentIntencity;

    // Use this for initialization
    void Start () {
        l = GetComponent<Light>(); 
        gl = GameObject.FindWithTag("global").GetComponent<Global>();
	}
	
	// Update is called once per frame
	void Update () {
        if (l != null)
        {
            if (scc.throtle && scc.curentFuel > 0)
            {
                l.enabled = true;
                if (curentIntencity < maxIntancity)
                {
                    curentIntencity += (maxIntancity - curentIntencity) * fadeInSpeed * gl.dt;
                }
            }
            else
            {
                curentIntencity -= curentIntencity * fadeSpeed * gl.dt;
                if (curentIntencity < 0.01)
                {
                    l.enabled = false;
                }
            }
            l.intensity = curentIntencity + Random.Range(-flickeringFactor * curentIntencity, flickeringFactor * curentIntencity);
        }
    }
}
