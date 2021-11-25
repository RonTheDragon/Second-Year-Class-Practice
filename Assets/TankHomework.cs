using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHomework : MonoBehaviour
{
    public GameObject Bullet;
    float _movementSpeed = 2;
    float _rotateSpeed = 50;
    float _aimRotateSpeed = 50;
    float rotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        combat();
    }
    void movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = transform.position + transform.forward * _movementSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position = transform.position - transform.forward * _movementSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 1 * _rotateSpeed * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -1* _rotateSpeed *Time.deltaTime, 0);
        }
    }
    void combat()
    {
        if (Input.GetKey(KeyCode.E))
        {
            rotation += _aimRotateSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            rotation -= _aimRotateSpeed * Time.deltaTime;
        }


        Vector3 CannonPos = transform.position + new Vector3(0, 1, 0);
        Quaternion CannonRot = Quaternion.Euler(new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + rotation, transform.localEulerAngles.z));

        if (Input.GetKey(KeyCode.Space))
        {
            Instantiate(Bullet,CannonPos,CannonRot);
        }
    }
    
}
