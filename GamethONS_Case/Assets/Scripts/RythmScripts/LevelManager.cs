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
    
    public static LevelManager Instance;
    public string filePath;
    public static MidiFile midiFile;
    public static double timeSinceStarted = 0;

    void Start()
    {
        Instance = this;
        // if (Application.streamingAssetsPath.StartsWith("http://") || Application.streamingAssetsPath.StartsWith("https://"))
        //     ReadFromWebsite();
        // else
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

    // private IEnumerator ReadFromWebsite(string fileLocation)
    // {
    //     using (UnityWebRequest www = UnityWebRequest.Get(Application.streamingAssetsPath + "/" + filePath))
    //     {
    //         yield return www.SendWebRequest();
    //     }

    // }

    // Update is called once per frame
    void Update()
    {
        if(Beatscroller.hasStarted)
            timeSinceStarted += Time.deltaTime;
    }
}