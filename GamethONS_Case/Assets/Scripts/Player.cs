using System;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 10;
    [SerializeField] private float jumpSpeed = 7;

    private Rigidbody2D rb;
    private bool isGrounded;
    private float moveVelocity;

    public int vidaMax = 10;
    public int vidaAtual;

    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        vidaAtual = vidaMax;
    }

    private void Update()
    {
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Z))
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
        
        float hDirection = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(hDirection * walkSpeed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        isGrounded = false;
    }

    public void AplicaDano(int dano)
    {
        vidaAtual -= dano;
        Debug.Log("Chegamo aqui" + dano);   
        if( vidaAtual <= 0)
        {
            Destroy(gameObject);
        }
    }
}
