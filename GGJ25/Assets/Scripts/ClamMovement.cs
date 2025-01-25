using UnityEngine;

public class ClamMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float upStrength = 5f;
    public float horizontalStrength = 3f;

    public BubbleMovement bubbleMovementScript;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bubbleMovementScript.enabled = false;
        GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = Vector2.up * upStrength;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.linearVelocity = Vector2.left * horizontalStrength;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.linearVelocity = Vector2.right * horizontalStrength;
        }
    }
}
