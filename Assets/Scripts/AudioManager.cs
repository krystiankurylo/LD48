using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] Sounds;
    public AudioMixer AudioMixer;
    public AudioMixerGroup group;
    private static bool _mainThemeStarted = false;

    public static AudioManager Instance;

    private AudioManager() { }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach(var s in Sounds)
        {
            s.Source = gameObject.AddComponent<AudioSource>();
            s.Source.clip = s.Clip;
            s.Source.volume = s.Volume;
            s.Source.loop = s.Loop;
            s.Source.outputAudioMixerGroup = group;
            s.Source.playOnAwake = false;
        }
    }

    public void SetVolume(float volume)
    {
        Debug.Log(Mathf.Log10(volume) * 20);
        AudioMixer.SetFloat("MainVolume", Mathf.Log10(volume) * 20);
    }

    void Start()
    {
        if(!_mainThemeStarted)
        {
            Debug.Log("playing main theme");
            Play("MenuTheme");
            _mainThemeStarted = true;
        }

    }

    public void Play(string name)
    {
        var sound = Array.Find(Sounds, s => s.Name == name);
        sound.Source.Play();
    }

    public void Stop(string name)
    {
        var sound = Array.Find(Sounds, s => s.Name == name);
        sound.Source.Stop();
    }
}
