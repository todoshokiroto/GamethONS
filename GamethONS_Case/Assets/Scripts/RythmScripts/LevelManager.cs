using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using System.IO;
using UnityEngine.Networking;
using System;

public class LevelManager : MonoBehaviour
{
    
    private float startDelay;                               // in seconds
    public static LevelManager Instance;
    public string filePath;
    public static MidiFile midiFile;
    public static double timeSinceStarted = 0;              // in seconds
    public static bool hasLevelStarted = false;
    public static float Bpm = 60f;

    void Start()
    {
        Instance = this;
        // beatTempo = midiFile.GetTempoMap().GetTempoAtTime(???); // <-- para tentar fazer no futuro futuro
        startDelay = LaneObject.spawnX / (Bpm * 4 / 60f);
        midiFile = ReadFromMidiFileDisc();
    }


    private MidiFile ReadFromMidiFileDisc()
    {
        return MidiFile.Read(Application.dataPath + "/" + filePath);
    }


    public static Melanchall.DryWetMidi.Interaction.Note[] GetDataFromMidi()
    {
        midiFile = FindObjectOfType<LevelManager>().ReadFromMidiFileDisc();
        var notes = midiFile.GetNotes();
        var array = new Melanchall.DryWetMidi.Interaction.Note[notes.Count];
        notes.CopyTo(array, 0);
        return array;
    }


    void Update()
    {
        if(hasLevelStarted)
            timeSinceStarted += Time.deltaTime;

            
        if(!hasLevelStarted)
        {
            if(Input.anyKeyDown){
                FindObjectOfType<SoundManager>().Invoke("PlayMusic", startDelay);
                hasLevelStarted = true;
            }
        }
    }
}