using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Application Manager
public class ApplicationManager : MonoBehaviour
{
    private SystemManager systemManager;
    private float timeElapsed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        systemManager = new SystemManager();
        systemManager.Start(); // Start the system manager
        Debug.Log("Start Game");
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime; // Accumulez le temps écoulé
        systemManager.UpdateSystem(timeElapsed); // Mettez à jour le système avec le temps écoulé
    }
}
