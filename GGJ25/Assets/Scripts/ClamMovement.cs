using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class ClamMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float upStrength = 20f;
    public float horizontalStrength = 3f;
    public SpriteRenderer clamSprite;

    public BubbleMovement bubbleMovementScript;
    public ClamMovement clamMovementScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        clamMovementScript.enabled = false;
        GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (clamMovementScript.enabled == true)
        {
            rb.gravityScale = 3f;
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = Vector2.up * upStrength;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.linearVelocity = Vector2.left * horizontalStrength;
            clamSprite.flipX = true;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.linearVelocity = Vector2.right * horizontalStrength;
            clamSprite.flipX = false;
        }
    }
       private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "Pop" && other.gameObject.layer == 6)
            {
            // Add in a "pop" animation
                Object.FindFirstObjectByType<AudioManager>().Play("BubblePop");
                Destroy(gameObject);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
}
