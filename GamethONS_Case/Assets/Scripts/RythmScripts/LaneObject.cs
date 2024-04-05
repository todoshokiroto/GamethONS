using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using System.IO;
using UnityEngine.Networking;
using System;
using System.Linq;
// using Melanchall.DryWetMidi.Interaction.TempoMap;
// using Melanchall.DryWetMidi.MusicTheory;

public class LaneObject : MonoBehaviour
{
    public int spawnIndex = 0;
    public static float spawnX = 8;
    public List<double> timeStamps = new List<double>(); // in seconds

    public GameObject notePrefab;


    void Start()
    {
        Vector3 beatToHitDistance = new Vector3(spawnX, 0f, 0f);
        transform.position = FindObjectOfType<HitController>().transform.position + beatToHitDistance;

        SetTimeStamps(LevelManager.GetDataFromMidi());
    }


    void Update()
    {
        if(spawnIndex < timeStamps.Count){
            if(LevelManager.timeSinceStarted >= timeStamps[spawnIndex])
            {
                if(LevelManager.isEncounterHappening)
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
