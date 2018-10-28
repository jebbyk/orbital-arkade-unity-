using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Global : MonoBehaviour
{

    public List<Rigidbody> AllBodyes = new List<Rigidbody>();
    public float g = 6.67408f;
    public int globalPower;
    public int targetFPS;
    public float dt;
    public int points;

    public void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        //Application.targetFrameRate = targetFPS;
    }
    public void Update()
    {
        dt = Time.deltaTime;
    }
}
