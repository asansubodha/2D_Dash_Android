using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float MoveSpeed;
    Rigidbody2D rb;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectsWithTag("Audio")[0].GetComponent<AudioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
            if (touchPos.x > 0)
            {
                rb.velocity = Vector2.right * MoveSpeed;
            }
            else
            {
                rb.velocity = Vector2.left * MoveSpeed;
            }
        }
        else
        {
            // Stop the player
            rb.velocity = Vector2.zero;
        }
    } // Update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            SceneManager.LoadScene("Game");
            audioManager.playSFX(audioManager.Death);
        }
    } // OnCollisionEnter2D
}
