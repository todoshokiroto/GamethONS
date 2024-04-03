using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jump_height = 3; // altura do pulo em unity units
    [SerializeField] private float jump_speed = 5;
    // private bool is_jumping = false;
    // private float jump_button_press_time = 0f;
    // private float jump_button_pess_window = 1000f;
    private Rigidbody2D rb;
    private bool is_grounded = true;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag.ToLower() == "ground")
            is_grounded = true;
    }

    private void OnCollisionExit2D(Collision2D other){
        if(other.gameObject.tag.ToLower() == "ground")
            is_grounded = false;
    }


    // Update is called once per frame
    void Update()
    {
        if(!is_grounded)
            jump_speed += Physics2D.gravity.y * rb.gravityScale * Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Z))
            jump_speed = Mathf.Sqrt(jump_height * (Physics2D.gravity.y * rb.gravityScale) * -2);
        transform.position += new Vector3(0, jump_speed, 0) * Time.deltaTime;


        // if (Input.GetKeyDown(KeyCode.Z) && !is_jumping) // Pula
        // {
        //     float jump_force = Mathf.Sqrt(jump_height * (Physics2D.gravity.y * rb.gravityScale) * -1) * rb.mass;
        //     rb.AddForce(Vector2.up * jump_force, ForceMode2D.Impulse);
        //     is_jumping = true;
        //     jump_button_press_time = 0;
        // }

        // if(is_jumping)
        // {
        //     jump_button_press_time += Time.deltaTime;
        //     if(Input.GetKeyUp(KeyCode.Z) && jump_button_press_time < jump_button_pess_window)
        //     {
        //         rb.gravityScale = 
        //     }
        //     if(rb.velocity.y < 0)
        //     {
        //         is_jumping = false;
        //     }
        // }
    }
}
