using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour , IMediator
{
    public MediatorPractice mediator { get; set; }
    float actionCooldown;
    public bool CurrentThinkItsStorm;

    // Start is called before the first frame update
    void Start()
    {
        actionCooldown = Random.Range(2, 10);
    }

    // Update is called once per frame
    void Update()
    {
        if (actionCooldown <= 0)
        {
            actionCooldown = Random.Range(2, 10);
            RandomAction(Random.Range(0, 5));
        }
        else
        {
            actionCooldown -= Time.deltaTime;
        }
    }

    void RandomAction(int mission)
    {
        switch (mission)
        {
            case 0: CheckWeather(); break;
            default: Work(); break;
        }
    }

    void Work()
    {
        int money = Random.Range(1, 5);
        Debug.Log($"{transform.name}'s worked and earned {money}$");
        mediator.EarnMoney(money);
    }
    void CheckWeather()
    {
        Debug.Log($"{transform.name}'s Worker Checked The Weather");
        if (mediator.CheckingWeater()) // if Storm
        {
            if (!CurrentThinkItsStorm) // didnt know about the storm            
                Alert();
            
            
        }
        else
        {
            if (CurrentThinkItsStorm) // didnt know it was clear            
                Calm();
            
            
        }
    }
    void Alert()
    {
        Debug.Log($"{transform.name}'s Worker Discovered a Storm!");
        mediator.AlertEveryone();
    }
    void Calm()
    {
        Debug.Log($"{transform.name}'s Worker Discovered the Storm is over!");
        mediator.CalmEveryone();
    }

}
