using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] public AudioSource music;
    public static SoundManager instance;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public static double GetAudioTime(){
        // return (double) instance.music.timeSamples / instance.music.clip.frequency;
        return instance.music.time;
    }


    public void PlayMusic(){
        instance.music.Play();
    }


    public void PlayNoteHitSfx(){
        Debug.Log("Hell YEAH");
    }

    public void PlayNoteMissSfx(){
        Debug.Log("O MAYY GAAA");
    }
}
