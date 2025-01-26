using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using static System.TimeZoneInfo;

public class BubbleMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float downStrength = 5f;
    public float horizontalStrength = 5f;
   
    public ClamMovement clamMovementScript;
    public BubbleMovement bubbleMovementScript;

    public GameObject pearl;
    public SpriteRenderer bubbleRenderer;

    public CinemachineCamera cam;
    public Transform clamTarget;

    public TMP_Text mergeText;
    public TMP_Text swimUpText;
    public TMP_Text swimDownText;
    public TMP_Text arrowText;
    public TMP_Text LeftRightText;

    public AudioSource bubblePopAudio;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.tag = "Player";
        GetComponent<Rigidbody2D>();
        clamMovementScript.enabled = false;
        rb.gravityScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = Vector2.down * downStrength;
            rb.gravityScale = -1f;
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Clam")
        {
            Debug.Log("Collision Detected");
            Destroy(gameObject);
            clamMovementScript.enabled = true;
            bubbleMovementScript.enabled = false;
            cam.Follow = clamTarget;
            mergeText.enabled = false;
            swimUpText.enabled = true;
            swimDownText.enabled = false;
            arrowText.enabled = true;
            LeftRightText.enabled = false;
            pearl.SetActive(true);
        }

        if (other.gameObject.tag == "Pop")
        {
            //Object.FindFirstObjectByType<AudioManager>().Play("BubblePop");
            bubblePopAudio.Play();
            bubbleRenderer.enabled = false;
            StartCoroutine(BubblePop());
        }
    }

    IEnumerator BubblePop()
    {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
