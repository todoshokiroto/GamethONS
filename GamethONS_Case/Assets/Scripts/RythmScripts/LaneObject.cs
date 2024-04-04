using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using System.IO;
using UnityEngine.Networking;
using System;
using System.Linq;
// using Melanchall.DryWetMidi.MusicTheory;

public class LaneObject : MonoBehaviour
{
    public List<double> timeStamps = new List<double>(); // em segundos
    
    public float noteSpeed;
    public int spawnIndex = 0;
    public static float spawnX = 8;
    // private Dictionary<string, float> spawnPosition = new Dictionary<string, float>(); 

    public GameObject notePrefab;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 beatToHitDistance = new Vector3(spawnX, 0f, 0f);
        // spawnPosition.Add("x", hit.transform.position.x + beatToHitDistance);
        // spawnPosition.Add("y", hit.transform.position.y);
        transform.position = FindObjectOfType<HitController>().transform.position + beatToHitDistance;

        noteSpeed = beatToHitDistance.x / FindAnyObjectByType<Beatscroller>().beatTempo;
        SetTimeStamps(LevelManager.GetDataFromMidi());
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnIndex < timeStamps.Count){
            if(LevelManager.timeSinceStarted >= timeStamps[spawnIndex])
            {
                Instantiate(notePrefab, transform.position, new Quaternion(0,0,0,0),  transform);
                spawnIndex++;
            }
        }
    }


    public void SetTimeStamps(Melanchall.DryWetMidi.Interaction.Note[] notes)
    {
        foreach(var note in notes)
        {
            var metricTimeSpan = TimeConverter.ConvertTo<MetricTimeSpan>(note.Time, LevelManager.midiFile.GetTempoMap());
            timeStamps.Add((double)metricTimeSpan.Minutes * 60f + metricTimeSpan.Seconds + (double)metricTimeSpan.Milliseconds / 1000f);
        }
    }

}
