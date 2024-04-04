using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitController : MonoBehaviour
{
    [SerializeField] private Color32 pressedColor = new Color32(200, 200, 200, 255);
    [SerializeField] private Color32 unpressedColor = new Color32(255, 255, 255, 255);
    [SerializeField] public KeyCode keyToPress  = KeyCode.Z; 
    [SerializeField] public KeyCode keyToPress2 = KeyCode.X; 

    private BeatObject[] beats;
    private SpriteRenderer spriteRenderer;


    void Start()
    {   beats = FindObjectsOfType<BeatObject>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {

        if(Input.GetKeyDown(keyToPress)||Input.GetKeyDown(keyToPress2))
            spriteRenderer.color = pressedColor;
        else if(Input.GetKeyUp(keyToPress)||Input.GetKeyUp(keyToPress2))
            spriteRenderer.color = unpressedColor;
    }
    /*
    Vector3 CompareArray(){
        Vector3 lastPosition;
        foreach(beat in beats){
            float actualDiference = Mathf.Abs(transform.position.x - beatPosition.x)
            if(position > lastPosition)
            lastPosition = position;
        }
        return lastPosition;
    }
    */
}
