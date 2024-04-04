using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MusicYo : MonoBehaviour
{
    [SerializeField] public AudioSource music;
    public bool startPlaying;
    public Beatscroller beatScroller;
    [SerializeField] private float startDelay = 4f;
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


    public IEnumerator PlayMusic(){
        yield return new WaitForSeconds(startDelay);
        instance.music.Play();
    }


    public void NoteHit(){
        Debug.Log("Hell YEAH");
    }

    public void NoteMiss(){
        Debug.Log("O MAYY GAAA");
    }
}
