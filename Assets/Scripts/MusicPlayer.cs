using System;
using UnityEngine;
public class MusicPlayer : MonoBehaviour
{
    public AudioSource musicSource;

    public static MusicPlayer Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void restart()
    {
        musicSource.Stop();
        Invoke(nameof(start), 0.5f);
    }

    private void start()
    {
        musicSource.Play();
    }
}