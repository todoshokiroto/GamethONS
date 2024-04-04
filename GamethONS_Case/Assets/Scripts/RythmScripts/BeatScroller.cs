using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beatscroller : MonoBehaviour
{
    public float  beatTempo = 60;
    public bool hasStarted = false;

    // void Awake()
    // {
    //     beatTempo = beatTempo * 4 / 60f;
    //     hasStarted = FindFirstObjectByType<MusicYo>().music.isPlaying;

    // }

    void Start()
    {
        beatTempo = beatTempo * 4 / 60f;
        hasStarted = FindFirstObjectByType<MusicYo>().music.isPlaying;
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted)
        {
            if(Input.anyKeyDown){
                StartCoroutine(FindObjectOfType<MusicYo>().PlayMusic());
                hasStarted = true;
            }
        }
        else 
        {
            transform.position -= new Vector3(beatTempo*Time.deltaTime, 0f, 0f);
        }
    }
}
