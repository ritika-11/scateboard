using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputManager))]
public class SkateController : MonoBehaviour
{
    public InputManager im;
    public List<WheelCollider> throttlewheels;
    public List<WheelCollider> steeringwheels;
    public float strengthCoefficient = 20000f;
    public float maxturn = 20f;

    // Start is called before the first frame update
    void Start()
    {
        //im = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        im = GetComponent<InputManager>();

        foreach (WheelCollider wheel in throttlewheels)
        {
            wheel.motorTorque = strengthCoefficient * Time.deltaTime * im.throttle;
        }
        foreach (WheelCollider wheel in steeringwheels)
        {
            wheel.steerAngle = maxturn * im.steer;
        }
    }
}
