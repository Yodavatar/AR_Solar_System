using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Concentrated Mode
public class ConcentratedMode
{
    private List<string> liste;
    private GameObject concentratedlight;
    private Sun sunobject;
    private Planet planetobject;
    public string name;

    //Get Sun
    public void ActivatebySun(Sun sun)
    {
        this.name = sun.name;
        this.sunobject = sun;
        foreach (string element in liste)
        {
            if (element != this.name)
            {
                GameObject.Find(element).SetActive(false);
            }
        }
    }

    //Get Planet
    public void ActivatebyPlanet(Planet planet)
    {
        this.name = planet.name;
        this.planetobject = planet;
        concentratedlight = GameObject.Find("concentratedlight");
        concentratedlight.SetActive(true);
        foreach (string element in liste)
        {
            if (element != this.name)
            {
                GameObject.Find(element).SetActive(false);
            }
        }
    }
    

    //Desactivate the concentrated mode
    public void Desactivate()
    {
        if (name == "sun")
        {
            
        }
        else
        {
            concentratedlight.SetActive(false);
        }
        foreach (string element in liste)
        {
            if (element != this.name)
            {
                GameObject.Find(element).SetActive(true);
            }
        }
    }

    // Start is called before the first frame update
    public void Start()
    {
        liste = new List<string>();
        liste.Add("sun");
        liste.Add("mercury");
        liste.Add("venus");
        liste.Add("earth");
        liste.Add("mars");
        liste.Add("jupiter");
        liste.Add("saturn");
        liste.Add("uranus");
        liste.Add("neptune");
    }

    // Update the concentrated mode
    public void UpdateSystem(float timeElapsed)
    {
        if (name == "sun")
        {
            sunobject.Move(timeElapsed);
        }
        else
        {
            planetobject.Move(timeElapsed);
        }
    }
}
