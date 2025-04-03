using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Comet
public class Comet
{
    private float orbital_period_in_terrestrial_periode; // in days
    private float rotation_period_in_itself; // in days
    private float distance_from_sun; // in million km
    private float diameter; // in thousand km
    
    //Constructor
    public Comet(float orbital_period_in_terrestrial_periode, float rotation_period_in_itself, float distance_from_sun, float diameter)
    {
        this.orbital_period_in_terrestrial_periode = orbital_period_in_terrestrial_periode;
        this.rotation_period_in_itself = rotation_period_in_itself;
        this.distance_from_sun = distance_from_sun;
        this.diameter = diameter;
    }

    //Spawn Planets
    public void SpawnPlanet()
    {
        /*
        // Implement planet spawning logic here
        for (int i = 0; i < EnemyNumber; i++)
        {
            float x = camTransform.position.x + Random.Range(-SpawnRange, SpawnRange);
            float y = camTransform.position.y + Random.Range(-SpawnRange, SpawnRange);
            float z = camTransform.position.z + Random.Range(-SpawnRange, SpawnRange);
            Vector3 spawnPos = new Vector3(x, y, z);
            Instantiate(EnemyPrefab, spawnPos, Quaternion.identity);
        }
        */
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update alse move the planet of the solar system
    public void Update()
    {
        
    }
}
