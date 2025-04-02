using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Planet Manager
public class SystemManager
{
    public Dictionary<string, Planet> planets;
    public Sun sun;
    List<Planet> allplanet = new List<Planet>();
    List<Comet> allcomet = new List<Comet>();
    int days_passed = 1; // in days

    // Constructor
    public SystemManager()
    {
        planets = new Dictionary<string, Planet>();
        planets.Add("mercure", new Planet(87.97f, 58.65f, 57.9f, 4.879f,"mercure"));
        planets.Add("venus", new Planet(224.7f, 243.0f, 108.2f, 12.104f,"venus"));
        planets.Add("earth", new Planet(365.24f, 1.0f, 149.6f, 12.742f,"earth"));
        planets.Add("mars", new Planet(686.98f, 1.03f, 227.9f, 6.779f,"mars"));
        planets.Add("jupiter", new Planet(4333.0f, 0.41f, 778.3f, 139.82f,"jupiter"));
        planets.Add("saturne", new Planet(10759.0f, 0.45f, 1430.0f, 116.46f,"saturne"));
        planets.Add("uranus", new Planet(30687.0f, 0.72f, 2871.0f, 50.724f,"uranus"));
        planets.Add("neptune", new Planet(60190f, 0.67f, 4497f, 49.244f,"neptune"));
        this.sun = new Sun(0, 0, 1392f);
    }

    // Spawn Planets
    public void SpawnPlanets()
    {
        //Debug.Log("Spawn Planets");
        foreach (KeyValuePair<string, Planet> element in planets)
        {
            //Debug.Log("Planet: " + element.Key);
            allplanet.Add(element.Value);
            element.Value.SpawnPlanet();
        }
    }

    // Spawn Sun
    public void SpawnSun()
    {
        sun.SpawnSun();
    }

    // Start is called before the first frame update
    public void Start()
    {
        SpawnPlanets();
        SpawnSun();
    }

    //Update the system
    public void UpdateSystem()
    {
        foreach(Planet planet in allplanet)
        {
            planet.Update(this.days_passed);
        }
        foreach(Comet comet in allcomet)
        {
            comet.Update();
        }
        sun.Update();
    }
}
