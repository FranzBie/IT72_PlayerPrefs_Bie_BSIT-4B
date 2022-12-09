using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public static GameManager instance;

    int score;

    public Text scoreText;
    public GameObject gameStartUI;
    public GameObject playButton;


    Rigidbody2D rb;
    public float bounceForce;
    public float sipa = 0.5f;


    bool gameStarted;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            if(gameStartUI.active.Equals(false))
            {
                gameStartUI.SetActive(false);
                startBounce();
                gameStarted = true;
                GameManager.instance.play();
            }
        }

        //back
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Playground");
        }
    }

    void startBounce()
    {
        //random bounce
        Vector2 randomDirection = new Vector2(Random.Range(-1, 1), 1);

        rb.AddForce(randomDirection * bounceForce,ForceMode2D.Impulse);
        rb.gravityScale = sipa;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "FallCheck")
        {
            GameManager.instance.restart();
        }
        else if (collision.gameObject.tag == "Paddle")
        {
            GameManager.instance.scoreUp();

            Vector2 randomDirection = new Vector2(Random.Range(-1, 1), 1);     
            rb.AddForce(randomDirection * 4, ForceMode2D.Impulse);
        }
    }
}
