using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beatscroller : MonoBehaviour
{
    public float  beatTempo = 60f;
    public static bool hasStarted = false;
    private float startDelay;

    void Start()
    {
        beatTempo  = beatTempo * 4 / 60f;
        startDelay = LaneObject.spawnX/beatTempo;
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted)
        {
            if(Input.anyKeyDown){
                FindObjectOfType<MusicYo>().Invoke("PlayMusic", startDelay);
                hasStarted = true;
            }
        }
        else 
        {
            transform.position -= new Vector3(beatTempo*Time.deltaTime, 0f, 0f);
        }
    }
}
