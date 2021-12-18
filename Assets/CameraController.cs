using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CurrentLocation currentLocation;
    Camera TheCamera;
    // Start is called before the first frame update
    void Start()
    {
        currentLocation = new CurrentLocation(new StartPosition());
        TheCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { // if left button pressed...
            Ray ray = TheCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Intractable ClickedObject = hit.collider.gameObject.GetComponent<Intractable>();
                if (ClickedObject != null)
                {
                    ClickedObject.Use();
                }
            }
        }
    }

    public void PressRight()
    {
        currentLocation.PressedRight();
    }
    public void PressLeft()
    {
        currentLocation.PressedLeft();
    }
    public void PressForward()
    {
        currentLocation.PressedForward();
    }
}

public class CurrentLocation
{
    private Location location;

    public CurrentLocation(Location MoveTo)
    {
        location = MoveTo;
    }

    public void PressedRight()
    {
        location.TurnRight(this);
    }

    public void PressedLeft()
    {
        location.TurnLeft(this);
    }

    public void PressedForward()
    {
        location.GoForward(this);
    }

    public Location Current
    {
        get { return location; }
        set { location = value; }
    }
}


public abstract class Location
{
    public abstract void TurnRight(CurrentLocation location);

    public abstract void TurnLeft(CurrentLocation location);

    public abstract void GoForward(CurrentLocation location);
}

public class StartPosition : Location
{
    public StartPosition()
    {
        Debug.Log("Standing in Start Looking Forward");
        Camera.main.transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

    public override void TurnRight(CurrentLocation location)
    {
        CameraController.currentLocation.Current = new StartRight();
    }

    public override void TurnLeft(CurrentLocation location)
    {
        CameraController.currentLocation.Current = new StartLeft();
    }

    public override void GoForward(CurrentLocation location)
    {
        if (MapManagement.FirstDoorOpen)
        {
            CameraController.currentLocation.Current = new Exit();
        }
        else
        {
            Debug.Log("There is a Locked Door In The Way");
        }
    }
}
public class StartRight : Location
{
    public StartRight()
    {
        Debug.Log("Standing in Start Looking Right");
        Camera.main.transform.localRotation = Quaternion.Euler(0, 90, 0);
    }

    public override void TurnRight(CurrentLocation location)
    {
        CameraController.currentLocation.Current = new StartBack();
    }

    public override void TurnLeft(CurrentLocation location)
    {
        CameraController.currentLocation.Current = new StartPosition();
    }

    public override void GoForward(CurrentLocation location)
    {
        Debug.Log("There is a Wall in the Way");
    }
}
public class StartLeft : Location
{
    public StartLeft()
    {
        Debug.Log("Standing in Start Looking Left");
        Camera.main.transform.localRotation = Quaternion.Euler(0, -90, 0);
    }

    public override void TurnRight(CurrentLocation location)
    {
        CameraController.currentLocation.Current = new StartPosition();
    }

    public override void TurnLeft(CurrentLocation location)
    {
        CameraController.currentLocation.Current = new StartBack();
    }

    public override void GoForward(CurrentLocation location)
    {
        Debug.Log("There is a Wall in the Way");
    }
}
public class StartBack : Location
{
    public StartBack()
    {
        Debug.Log("Standing in Start Looking at the back");
        Camera.main.transform.localRotation = Quaternion.Euler(0, 180, 0);
    }

    public override void TurnRight(CurrentLocation location)
    {
        CameraController.currentLocation.Current = new StartLeft();
    }

    public override void TurnLeft(CurrentLocation location)
    {
        CameraController.currentLocation.Current = new StartRight();
    }

    public override void GoForward(CurrentLocation location)
    {
        Debug.Log("There is a Cabinet in the Way");
    }
}
public class Exit : Location
{
    public Exit()
    {
        Debug.Log("You Escaped!");
        Camera.main.transform.position += Camera.main.transform.forward * 6;
    }

    public override void TurnRight(CurrentLocation location)
    {
        Debug.Log("You Already Escaped!");
    }

    public override void TurnLeft(CurrentLocation location)
    {
        Debug.Log("You Already Escaped!");
    }

    public override void GoForward(CurrentLocation location)
    {
        Debug.Log("You Already Escaped!");
    }
}

