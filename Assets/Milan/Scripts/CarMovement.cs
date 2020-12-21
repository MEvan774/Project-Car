using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    /*
    Link video met setup: https://www.youtube.com/watch?v=kvTuYziy_QE

    de 'Car' object moet een rigidbody hebben met een Mass van 2000. anders jumpt die

    frictie van de wielen kunnen aangepast worden via de wheel colliders

     */
    public float motorForce, steerAngle, brakeForce;
    //car speed, stuur max hoek, remkracht

    public WheelCollider frontRight, frontLeft, backRight, backLeft;
    // wiel colliders

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxis("Vertical") * motorForce;
        float h = Input.GetAxis("Horizontal") * steerAngle;

        //voor wielen
        frontRight.steerAngle = h;
        frontLeft.steerAngle = h;

        //achter wielen
        backRight.motorTorque = v;
        backLeft.motorTorque = v;

        //Remmen
        if (Input.GetKey(KeyCode.Space))
        {
            backRight.brakeTorque = brakeForce;
            backLeft.brakeTorque = brakeForce;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            backRight.brakeTorque = 0;
            backLeft.brakeTorque = 0;
        }

        //Gas loslaten
        if(Input.GetAxis("Vertical") == 0)
        {
            backRight.brakeTorque = brakeForce;
            backLeft.brakeTorque = brakeForce;
        }
        else
        {
            backRight.brakeTorque = 0;
            backLeft.brakeTorque = 0;
        }

    }
}
