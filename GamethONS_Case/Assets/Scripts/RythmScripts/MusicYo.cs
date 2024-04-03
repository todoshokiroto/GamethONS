using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicYo : MonoBehaviour
{
    public AudioSource music;
    public bool startPlaying;
    public Beatscroller beatScroller;
    public static MusicYo instance;
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
