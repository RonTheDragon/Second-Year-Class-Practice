using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour , IMediator
{
    public MediatorPractice mediator { get; set; }
    public float MaxHp;
    public float Hp;
    public bool Parking;
    public bool Alive;

    // Start is called before the first frame update
    void Start()
    {
        MaxHp = Random.Range(10, 15);
        Hp = MaxHp;
        Alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Hp < 0 && gameObject.activeSelf==true)
        {
            Alive = false;
            Debug.Log($"{transform.name} was destroyed in the storm");
            Alert();
            gameObject.SetActive(false);
        }
        if (Alive && Parking && Hp < MaxHp)
        {
            Hp += Time.deltaTime*0.5f; //repair plane
        }

        if (!Parking)
        {
            transform.Rotate(0, 0, 30 * Time.deltaTime);            
        }
    }
    void Alert()
    {
        Debug.Log($"{transform.name} Destruction made everyone aware of the storm");
        mediator.AlertEveryone();
    }
    public void Park()
    {              
        Debug.Log($"{transform.name} Has Landed Safely");
        Parking = true;       
    }
    public void Fly()
    {
        Debug.Log($"{transform.name} Took off");
        Parking = false;
    }
}
