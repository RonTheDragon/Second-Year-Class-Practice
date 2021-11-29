using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneControlled : MonoBehaviour
{
    public enum MovementMode { acceleration,Gyro,rotation}
    public MovementMode mode;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (mode == MovementMode.acceleration)
        transform.Translate(Input.acceleration.x* Speed * Time.deltaTime, -Input.acceleration.z * Speed * Time.deltaTime, 0);
        else if (mode == MovementMode.Gyro)
        transform.Translate(-Input.gyro.rotationRate.z * Speed * Time.deltaTime, -Input.gyro.rotationRate.x * Speed * Time.deltaTime, 0);
        else if (mode == MovementMode.rotation)       
        transform.Rotate(Input.acceleration.x * Speed * Time.deltaTime, 0, -Input.acceleration.z * Speed * Time.deltaTime);


       
    }
}
