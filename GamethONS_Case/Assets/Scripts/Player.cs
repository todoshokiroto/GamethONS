using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    
    private void Update()
    {
        Vector2 direction = Vector2.zero;

        if (Input.GetKey(KeyCode.LeftArrow))
            direction = Vector2.left;
        else if (Input.GetKey(KeyCode.RightArrow))
            direction = Vector2.right;
        if (Input.GetKeyDown(KeyCode.Z)) // Pula
        {
        }

        transform.position += (Vector3)direction * (Time.deltaTime * speed);
    }
}
