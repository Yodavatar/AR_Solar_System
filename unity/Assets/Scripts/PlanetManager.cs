using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Planet Manager
public class PlanetManager : MonoBehaviour
{
    public Dictionary<string, Planet> planets;

    // Constructor
    public PlanetManager()
    {
        planets = new Dictionary<string, Planet>();
        planets.Add("Mercure", new Planet(87.97f, 58.65f, 57.9f));
        planets.Add("Vénus", new Planet(224.7f, 243.0f, 108.2f));
        planets.Add("Terre", new Planet(365.24f, 1.0f, 149.6f));
        planets.Add("Mars", new Planet(686.98f, 1.03f, 227.9f));
        planets.Add("Jupiter", new Planet(4333.0f, 0.41f, 778.3f));
        planets.Add("Saturne", new Planet(10759.0f, 0.45f, 1430.0f));
        planets.Add("Uranus", new Planet(30687.0f, 0.72f, 2871.0f));
        planets.Add("Neptune", new Planet(60190f, 0.67f, 4497f));
    }

    // Spawn Planets
    public void SpawnPlanets()
    {
        // Implement planet spawning logic here
    }

    public void SpawnAsteroid()
    {
        // Implement asteroid spawning logic here
    }

    public void SpawnMoon()
    {
        // Implement moon spawning logic here
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
