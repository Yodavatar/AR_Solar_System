using System.Collections.Generic;
using UnityEngine;

//Manage Song
public class ManageSong : MonoBehaviour
{
    public string songsFolderPath = "Songs";
    private List<AudioClip> songs;
    private AudioSource audioSource;
    private List<AudioClip> shuffledSongs;
    private int currentSongIndex = -1;

    // Initialisation du composant AudioSource et chargement des musiques
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        LoadSongs();
        ShuffleSongs();
    }

    // Chargement des musiques depuis le dossier spécifié
    void LoadSongs()
    {
        songs = new List<AudioClip>();
        AudioClip[] loadedSongs = Resources.LoadAll<AudioClip>(songsFolderPath);
        songs.AddRange(loadedSongs);
    }

    // Mélange aléatoire des musiques pour la lecture
    void ShuffleSongs()
    {
        shuffledSongs = new List<AudioClip>(songs);
        for (int i = 0; i < shuffledSongs.Count; i++)
        {
            AudioClip temp = shuffledSongs[i];
            int randomIndex = Random.Range(i, shuffledSongs.Count);
            shuffledSongs[i] = shuffledSongs[randomIndex];
            shuffledSongs[randomIndex] = temp;
        }
    }

    // Lecture d'une musique aléatoire
    public void PlaySong()
    {
        if (shuffledSongs.Count == 0) return;

        currentSongIndex = (currentSongIndex + 1) % shuffledSongs.Count;
        audioSource.clip = shuffledSongs[currentSongIndex];
        audioSource.Play();
    }

    // Arrêt de la musique en cours
    public void StopSong()
    {
        audioSource.Stop();
    }

    // Mise en pause de la musique en cours
    public void PauseSong()
    {
        audioSource.Pause();
    }

    // Réglage du volume de la musique
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
