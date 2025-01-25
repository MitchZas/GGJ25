using UnityEngine;
using UnityEngine.SceneManagement;

public class BubbleMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float downStrength = 5f;
    public float horizontalStrength = 5f;

    public ClamMovement clamMovementScript;
    public BubbleMovement bubbleMovementScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.tag = "Player";
        GetComponent<Rigidbody2D>();
        clamMovementScript.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = Vector2.down * downStrength;
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Pop")
        {
            // Add in a "pop" animation
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (other.gameObject.tag == "Clam")
        {
            bubbleMovementScript.enabled = false;
            clamMovementScript.enabled = true;
        }
    }
}
