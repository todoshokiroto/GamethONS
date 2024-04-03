using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NoteObject : MonoBehaviour
{
    public bool hittable = false;
    private HitController hit;
    private MusicYo musicPlayer;
    public int id = 0;
    void Start()
    {
        hit = FindObjectOfType<HitController>();
        musicPlayer = FindObjectOfType<MusicYo>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Vector3 beatPosition = transform.position;
        Vector3 hitPosition  = hit.transform.position;
        float distanceDifference = Mathf.Abs(hitPosition.x - beatPosition.x);
        if(distanceDifference <= 2)
            hittable = true;
        else
            hittable = false;
        */
        if(hittable && (Input.GetKeyDown(hit.keyToPress) || Input.GetKeyDown(hit.keyToPress2)))
        {
            gameObject.SetActive(false);
            //musicPlayer.NoteHit();
            musicPlayer.NoteHit();
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        hittable = true;
        //id+=1;
        Debug.Log(id);
    }
    void OnTriggerExit2D(Collider2D other) {
        hittable = false;
        musicPlayer.NoteMiss();
    }
}
