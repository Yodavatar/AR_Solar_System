using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance; // Singleton pour garder la musique entre les scènes
    public AudioSource audioSource;
    public AudioClip[] musiques; // 🎵 Tableau contenant 4 musiques

    private int musiqueIndex = 0; // Index de la musique en cours
    private bool isPlaying = true; // État de la musique

    void Awake()
    {
        // Singleton pour éviter les doublons de musique
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioSource = GetComponent<AudioSource>();
        PlayNextMusic(); // Démarrer la première musique
    }

    void Update()
    {
        // Vérifie si la musique est terminée pour passer à la suivante
        if (!audioSource.isPlaying && isPlaying)
        {
            PlayNextMusic();
        }
    }

    public void ToggleMusic()
    {
        if (isPlaying)
        {
            audioSource.Pause();
            isPlaying = false;
        }
        else
        {
            audioSource.Play();
            isPlaying = true;
        }
    }

    void PlayNextMusic()
    {
        if (musiques.Length == 0) return;

        musiqueIndex = (musiqueIndex + 1) % musiques.Length; // Passe à la musique suivante
        audioSource.clip = musiques[musiqueIndex];
        audioSource.Play();
    }
}
