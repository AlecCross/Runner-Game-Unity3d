using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManger : MonoBehaviour
{
    [SerializeField]
    GameState gameState;

    public Sound[] sounds;
    public static AudioManger instance;
    // Start is called before the first frame update
    //public AudioSource[] allAudioSources;

    public void StopAllAudio()
    {
        foreach (Sound s in sounds)
        {
            s.source.Stop();
        }
    }
    void Awake()
    {
        if (instance == null){
            instance = this;
        }
        else{
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    void Update(){
        if (Input.GetKeyDown(KeyCode.M))
            Mute();
    }

    // Update is called once per frame
    public void Play(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
    public void Mute(){
        foreach (Sound s in sounds){
            s.mute = !s.mute;
            s.source.mute = s.mute;
        }
        gameState.mute = !gameState.mute;
    }
}
