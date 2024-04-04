using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NoteObject : MonoBehaviour
{
    public bool hittable = false;
    private HitController hit;

    void Start()
    {
        hit = FindObjectOfType<HitController>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Vector3 beatPosition = transform.position;
        Vector3 hitPosition  = hit.transform.position;
        float distanceDifference = Mathf.Abs(hitPosition.x - beatPosition.x);
        if(distanceDifference <= 2)
            hittable = true;
        else
            hittable = false;
        */
        if(hittable && (Input.GetKeyDown(hit.keyToPress) || Input.GetKeyDown(hit.keyToPress2)))
        {
            gameObject.SetActive(false);
            //MusicYo.instance.NoteHit();
            Debug.Log("Sim");
        }
        
    }
    void OnTriggerEnter2D(Collider2D other) {
        hittable = true;
    }
    void OnTriggerExit2D(Collider2D other) {
        hittable = false;
        Debug.Log("Errou");
    }
}
