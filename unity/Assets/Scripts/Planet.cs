using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Planet
public class Planet
{
    public float space_size = 0.05f; // in million km
    public float space_scale = 0.01f; // in million km
    private float orbital_period_in_terrestrial_periode; // in days
    private float rotation_period_in_itself; // in days
    private float distance_from_sun; // in million km
    private float diameter; // in thousand km
    public string name; // name of the planet
    private GameObject planetobject; // in km
    private float rotationAngle; // Angle of rotation around its own axis
    public float Distance => distance_from_sun;
    public float Period => orbital_period_in_terrestrial_periode;

    // Constructor of the planet
    public Planet(float orbital_period_in_terrestrial_periode, float rotation_period_in_itself, float distance_from_sun, float diameter, string name)
    {
        this.orbital_period_in_terrestrial_periode = orbital_period_in_terrestrial_periode;
        this.rotation_period_in_itself = 100f;
        this.distance_from_sun = distance_from_sun;
        this.diameter = diameter;
        this.name = name;
        this.rotationAngle = 0f;
    }

    //Spawn Planets
    public void SpawnPlanet()
    {
        this.planetobject = GameObject.Find(this.name);
        if (this.planetobject != null)
        {
            this.planetobject.transform.localScale = new Vector3(1 + diameter * space_scale, 1 + diameter * space_scale, 1 + diameter * space_scale); // in thousand km
        }
        else
        {
            Debug.LogError("GameObject for planet " + name + " not found.");
        }
    }

    //Calculate the position of the planet in the solar system
    public (float X, float Y) CalculatePosition(float time)
    {
        float angle = 2 * Mathf.PI * (time / Period);
        float x = Distance * Mathf.Cos(angle);
        float y = Distance * Mathf.Sin(angle);
        return (x, y);
    }

    //Move the planet based on the elapsed days
    public void Move(float timeElapsed)
    {
        var (x, y) = CalculatePosition(timeElapsed);
        if (planetobject != null)
        {
            planetobject.transform.position = new Vector3(x * space_size, 0, y * space_size);
            rotationAngle = (2 * Mathf.PI * timeElapsed) / rotation_period_in_itself;
            planetobject.transform.rotation = Quaternion.Euler(0, rotationAngle * Mathf.Rad2Deg, 0);
        }
    }
}
