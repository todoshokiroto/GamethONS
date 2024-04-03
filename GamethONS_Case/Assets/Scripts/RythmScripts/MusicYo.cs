using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicYo : MonoBehaviour
{
    public AudioSource music;
    public bool startPlaying;
    public Beatscroller beatScroller;
    public static MusicYo instance;

    private float noteTime;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        // if(!startPlaying){
        //     if(Input.anyKeyDown){
        //         startPlaying = true;
        //         beatScroller.hasStarted = true;
        //         music.Play();
        //     }
        // }
    }

    public static double GetAudioTime(){
        // return (double) instance.music.timeSamples / instance.music.clip.frequency;
        return instance.music.time;
    }


    public void PlayMusic(){
        instance.music.Play();
    }


    public void NoteHit(){
        Debug.Log("Hell YEAH");
    }

    public void NoteMiss(){
        Debug.Log("O MAYY GAAA");
    }
}
