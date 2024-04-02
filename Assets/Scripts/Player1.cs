using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public float racketSpeed;

    private Rigidbody2D rb;
    private Vector2 racketDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            float inputY = Input.GetAxisRaw("Vertical");

            racketDirection = new Vector2(0, inputY).normalized;
        }

    }

    private void FixedUpdate()
    {
        rb.velocity = racketDirection * racketSpeed;
    }
}
