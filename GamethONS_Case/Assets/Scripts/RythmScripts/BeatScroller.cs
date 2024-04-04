using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beatscroller : MonoBehaviour
{
    public float  beatTempo = 60;
    public bool hasStarted;
    public AudioSource music;
    void Start()
    {
        beatTempo = beatTempo * 4 / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted)
        {
            if(Input.anyKeyDown)
                hasStarted = true;
                music.Play();
        }
        else 
        {
            transform.position -= new Vector3(beatTempo*Time.deltaTime, 0f, 0f);
        }
    }
}
