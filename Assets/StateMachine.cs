using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{ 
    public static CurrentAnimation PlayerAnim;
    // Start is called before the first frame update
    void Start()
    {
        PlayerAnim = new CurrentAnimation(new Standing());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            PlayerAnim.PressDown();
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            PlayerAnim.ReleaseDown();
        }
        if (Input.GetKey(KeyCode.B))
        {
            PlayerAnim.PressB();
        }
    }
}

public class CurrentAnimation
{
    private Animation _animation;

    public CurrentAnimation(Animation animation)
    {
        _animation = animation;
    }

    public void PressDown()
    {
        _animation.PressDown(this);
    }

    public void ReleaseDown()
    {
        _animation.ReleaseDown(this);
    }

    public void PressB()
    {
        _animation.PressB(this);
    }

    public Animation Current
    {
        get { return _animation; }
        set { _animation = value; }
    }
}


public abstract class Animation
{
    public abstract void PressDown(CurrentAnimation animation);

    public abstract void ReleaseDown(CurrentAnimation animation);

    public abstract void PressB(CurrentAnimation animation);
}

public class Standing : Animation
{
    public Standing()
    {
        Debug.Log("Standing");
    }

    public override void PressB(CurrentAnimation animation)
    {
        StateMachine.PlayerAnim.Current = new Jumping();
    }

    public override void PressDown(CurrentAnimation animation)
    {
        StateMachine.PlayerAnim.Current = new Ducking();
    }

    public override void ReleaseDown(CurrentAnimation animation)
    {
        //throw new System.NotImplementedException();
    }
}
public class Ducking : Animation
{
    public Ducking()
    {
        Debug.Log("Ducking");
    }

    public override void PressB(CurrentAnimation animation)
    {
        //throw new System.NotImplementedException();
    }

    public override void PressDown(CurrentAnimation animation)
    {
        //throw new System.NotImplementedException();
    }

    public override void ReleaseDown(CurrentAnimation animation)
    {
        StateMachine.PlayerAnim.Current = new Standing();
    }
}
public class Jumping : Animation
{
    public Jumping()
    {
        Debug.Log("Jumping");
    }

    public override void PressB(CurrentAnimation animation)
    {
        //throw new System.NotImplementedException();
    }

    public override void PressDown(CurrentAnimation animation)
    {
        StateMachine.PlayerAnim.Current = new Diving();
    }

    public override void ReleaseDown(CurrentAnimation animation)
    {
        //throw new System.NotImplementedException();
    }
}
public class Diving : Animation
{
    public Diving()
    {
        Debug.Log("Diving");
    }

    public override void PressB(CurrentAnimation animation)
    {
        //throw new System.NotImplementedException();
    }

    public override void PressDown(CurrentAnimation animation)
    {
        //throw new System.NotImplementedException();
    }

    public override void ReleaseDown(CurrentAnimation animation)
    {
        StateMachine.PlayerAnim.Current = new Standing();
    }
}
