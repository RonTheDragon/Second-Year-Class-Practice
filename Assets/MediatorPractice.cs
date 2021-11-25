using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IMediator
{
    MediatorPractice mediator { get; set; }
}

public class MediatorPractice : MonoBehaviour
{
    Planet planet;
    Building[] buildings;
    Plane[] planes;


    // Start is called before the first frame update
    void Start()
    {
        planet = GetComponent<Planet>();
        buildings = GetChildsComponents<Building>(transform.GetChild(0).gameObject);
        planes = GetChildsComponents<Plane>(transform.GetChild(1).gameObject);

        planet.mediator = this;
        SetMediator(ref buildings);
        SetMediator(ref planes);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    T[] GetChildsComponents<T>(GameObject ObjectsParent)
    {
        T[] ListOfComponents = new T[ObjectsParent.transform.childCount];
        for (int i = 0; i < ObjectsParent.transform.childCount; i++)
        {
            ListOfComponents[i] = ObjectsParent.transform.GetChild(i).GetComponent<T>();
        }
        return ListOfComponents;
    }
    void SetMediator<T>(ref T[] t) where T: IMediator
    {
        foreach (T i in t)
        {
            i.mediator = this;
        }
    }

    public bool CheckingWeater()
    {
        return planet.Storm;
    }
    public void DamageFlyingPlanes()
    {
        foreach(Plane p in planes)
        {
            if (!p.Parking)
            p.Hp -= Time.deltaTime;
        }
    }
    public void PlanesWork()
    {
        int countPlanes = 0;
        int countFlyingPlanes = 0;
        foreach (Plane p in planes)
        {
            if (p.Alive)
            {
                countPlanes++;
                if (!p.Parking) countFlyingPlanes++;
            }
        }
        if (countPlanes == 0) { Debug.Log("GAME OVER!"); Destroy(planet.gameObject); }
        else
        {
            planet.Currency += Time.deltaTime * countFlyingPlanes;
        }
    }
    public void AlertEveryone()
    {
        foreach(Building b in buildings)
        {
            b.CurrentThinkItsStorm = true;
        }
        foreach (Plane p in planes)
        {
            if (p.Alive)
            p.Park();
        }
    }
    public void CalmEveryone()
    {
        foreach (Building b in buildings)
        {
            b.CurrentThinkItsStorm = false;
        }
        foreach (Plane p in planes)
        {
            if (p.Alive)
            p.Fly();
        }
    }
    public void EarnMoney(int money)
    {
        planet.Currency += money;
        
    }

}
