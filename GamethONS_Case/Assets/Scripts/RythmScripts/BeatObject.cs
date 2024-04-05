using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class BeatObject : MonoBehaviour
{
    public float noteSpeed;
    private bool hittable = false;
    private int id = 0;

    private HitController hit;
    private SoundManager musicPlayer;


    void Start()
    {
        noteSpeed = LevelManager.Bpm * 4 / 60f;
        hit = FindObjectOfType<HitController>();
        musicPlayer = FindObjectOfType<SoundManager>();
    }


    void Update()
    {
        
        if(LevelManager.hasLevelStarted)
            MoveBeat(-noteSpeed*Time.deltaTime, 0);
            
        if(hittable && (Input.GetKeyDown(hit.keyToPress) || Input.GetKeyDown(hit.keyToPress2)))
        {
            Destroy(this.gameObject);
            musicPlayer.PlayNoteHitSfx();
        }
    }


    void MoveBeat(float x, float y){
        transform.position += new Vector3(x, y, 0f);
    }


    void OnTriggerEnter2D(Collider2D other) {
        hittable = true;
        //id+=1;
        Debug.Log(id);
    }


    void OnTriggerExit2D(Collider2D other) {
        hittable = false;
        musicPlayer.PlayNoteMissSfx();
    }

}
