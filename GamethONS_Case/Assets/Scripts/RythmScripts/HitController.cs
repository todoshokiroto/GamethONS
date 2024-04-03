using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitController : MonoBehaviour
{
    private SpriteRenderer sr;
    [SerializeField] private Color32 pressedColor = new Color32(200, 200, 200, 255);
    [SerializeField] private Color32 unpressedColor = new Color32(255, 255, 255, 255);
    [SerializeField] public KeyCode keyToPress = KeyCode.Z; 
    [SerializeField] public KeyCode keyToPress2 = KeyCode.X; 

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToPress)||Input.GetKeyDown(keyToPress2))
            sr.color = pressedColor;
        else if(Input.GetKeyUp(keyToPress)||Input.GetKeyUp(keyToPress2))
            sr.color = unpressedColor;
    }
}
