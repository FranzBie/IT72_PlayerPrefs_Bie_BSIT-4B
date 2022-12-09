using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed;
    public Animator animator;
    bool m_Right = false;
    bool m_Left = false;

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
        
    }

    private void FixedUpdate()
    {
        touchMove();
    }

    void touchMove()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (touchPos.x < 0)
            {
                //move left
                bool m_Left = true;
                rb.velocity = Vector2.left * moveSpeed;
                if (m_Left == true)
                {
                    animator.SetBool("moveLeft", true);

                }
            }
            else
            {
                bool m_Right = true;
                //move right
                rb.velocity = Vector2.right * moveSpeed;
                if (m_Right == true)
                {
                    animator.SetBool("moveRight", true);
                }
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
