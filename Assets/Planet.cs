using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Planet : MonoBehaviour , IMediator
{
    public MediatorPractice mediator { get; set; }
    public bool Storm;
    float switchWeatherCooldown;
    public ParticleSystem particle;
    public float Currency;
    public Text money;

    // Start is called before the first frame update
    void Start()
    {
        Storm = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (switchWeatherCooldown <= 0)
        {
            switchWeatherCooldown = Random.Range(5, 20);
            Storm = !Storm;
        }
        else
        {
            switchWeatherCooldown -= Time.deltaTime;
        }

        if (Storm)
        {
            mediator.DamageFlyingPlanes();
            particle.Emit(1);
        }
        else
        {
            mediator.PlanesWork();
        }

        money.text = $"Money: {(int)Currency}$";
    }
}
