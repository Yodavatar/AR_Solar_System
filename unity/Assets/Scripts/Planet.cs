using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Planet
public class Planet
{
    public float space_size = 0.05f; // in million km
    public float space_scale = 0.01f; // in million km
    private float orbital_period_in_terrestrial_periode; // in days
    private float rotation_period_in_itself; // in days
    private float distance_from_sun; // in million km
    private float diameter; // in thousand km
    private string name; // name of the planet
    private GameObject planetobject; // in km

    // Properties to access the distance and period
    public float Distance => distance_from_sun;
    public float Period => orbital_period_in_terrestrial_periode;

    // Constructor
    public Planet(float orbital_period_in_terrestrial_periode, float rotation_period_in_itself, float distance_from_sun, float diameter, string name)
    {
        this.orbital_period_in_terrestrial_periode = orbital_period_in_terrestrial_periode;
        this.rotation_period_in_itself = rotation_period_in_itself;
        this.distance_from_sun = distance_from_sun;
        this.diameter = diameter;
        this.name = name;
    }

    // Spawn Planets
    public void SpawnPlanet()
    {
        this.planetobject = GameObject.Find(name);
        this.planetobject.transform.position = new Vector3(0, 0, 10 + distance_from_sun * space_size); // in million km
        this.planetobject.transform.localScale = new Vector3(1 + diameter * space_scale, 1 + diameter * space_scale, 1 + diameter * space_scale); // in thousand km
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnPlanet();
    }

    // Calculate the position of the planet in the solar system
    public (float X, float Y) CalculatePosition(float time)
    {
        float angle = 2 * Mathf.PI * (time / Period);
        float x = Distance * Mathf.Cos(angle);
        float y = Distance * Mathf.Sin(angle);
        return (x, y);
    }

    // Move the planet based on the elapsed days
    public void Move(float daysElapsed)
    {
        var (x, y) = CalculatePosition(daysElapsed);
        if (planetobject != null)
        {
            planetobject.transform.position = new Vector3(x * space_size, y * space_size, 10 + distance_from_sun * space_size);
        }
    }

    // Update also moves the planet in the solar system
    public void Update(float daysElapsed)
    {
        Debug.Log("Update" + name);
        Move(daysElapsed);
    }
}
