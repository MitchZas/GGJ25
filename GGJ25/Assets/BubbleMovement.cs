using UnityEngine;

public class BubbleMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float downStrength = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.linearVelocity = Vector2.down * downStrength; 
        }
    }
}
