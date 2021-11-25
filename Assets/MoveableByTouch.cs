using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableByTouch : MonoBehaviour
{
    Camera TheCamera;
    // Start is called before the first frame update
    void Start()
    {
        TheCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {            
            foreach(Touch t in Input.touches)
            {
                Ray ray = TheCamera.ScreenPointToRay(t.position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                   // if (hit.transform.gameObject == gameObject)
                    {
                        hit.transform.position = new Vector3(hit.point.x, hit.transform.position.y, hit.point.z);
                    }
                    
                }
            }     
        }     
    }
}
