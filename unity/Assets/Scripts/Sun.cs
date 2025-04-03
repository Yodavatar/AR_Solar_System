using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Sun
public class Sun
{
    public float space_size = 0.05f; // in million km
    public float space_scale = 0.01f; // in million km
    private float orbital_period_in_terrestrial_periode; // in days
    private float rotation_period_in_itself; // in days
    private float diameter; // in thousand km
    public string name; // name of the planet
    private GameObject sunobject; // in km
    private float rotationAngle; // Angle of rotation around its own axis
    
    //Constructor
    public Sun(float orbital_period_in_terrestrial_periode, float rotation_period_in_itself, float diameter)
    {
        this.orbital_period_in_terrestrial_periode = orbital_period_in_terrestrial_periode;
        this.rotation_period_in_itself = 100f;
        this.diameter = diameter;
        this.name = "sun";
    }

    //Spawn Sun
    public void SpawnSun()
    {
        this.sunobject = GameObject.Find(name);
        this.sunobject.transform.localScale = new Vector3(2, 2, 2); // in thousand km
    }

    //Start is called before the first frame update
    void Start()
    {
        SpawnSun();
    }

    //Update the movemement of the sun
    public void Move(float timeElapsed)
    {
        rotationAngle = (2 * Mathf.PI * timeElapsed) / rotation_period_in_itself;
        sunobject.transform.rotation = Quaternion.Euler(0, -rotationAngle * Mathf.Rad2Deg, 0);
    }
}
