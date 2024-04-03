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
    public AudioSource audioSource;
    public float songDelay;
    public int inputDelay;

    public string filePath;
    public float noteTime;
    public float noteSpawnY;
    public float noteTapY;
    public float noteDespawnY;

    public static MidiFile midiFile;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        // if (Application.streamingAssetsPath.StartsWith("http://") || Application.streamingAssetsPath.StartsWith("https://"))
        //     ReadFromWebsite();
        // else
        midiFile = ReadFromDisc();
    }


    private MidiFile ReadFromDisc()
    {
        return MidiFile.Read(Application.dataPath + "/" + filePath);
    }

    public static Melanchall.DryWetMidi.Interaction.Note[] GetDataFromMidi()
    {
        midiFile = FindObjectOfType<LevelManager>().ReadFromDisc();
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
        
    }
}