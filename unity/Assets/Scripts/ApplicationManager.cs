using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Application Manager
public class ApplicationManager: MonoBehaviour
{
    private SystemManager systemManager;

    // Constructor
    public ApplicationManager()
    {
        systemManager = new SystemManager();
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start Game");
        systemManager.Start();
        StartCoroutine(UpdateFunction());
    }

    // Function to be called every 0.5 seconds
    IEnumerator UpdateFunction()
    {
        while (true)
        {
            systemManager.UpdateSystem();
            yield return new WaitForSeconds(0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
