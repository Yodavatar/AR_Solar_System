using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Button playButton; // 🔥 Référence au bouton "Jouer"

    void Start()
    {
        playButton.onClick.AddListener(StartGame); // 🔥 Assigne la fonction au clic
    }

    void StartGame()
    {
        SceneManager.LoadScene("AR"); // 🔥 Charge la scène du QCM (remplace par le bon nom)
    }
}
