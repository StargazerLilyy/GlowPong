using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float racketSpeed;

    public BallMovement ball;

    private bool isAI;
    private Rigidbody2D paddle;
    private Vector2 racketDirection;
    private Vector2 forwardDirection;

    // Start is called before the first frame update
    void Start()
    {
        paddle = GetComponent<Rigidbody2D>();

        isAI = GlobalSettings.singlePlayer;
        if (isAI)
        {
            forwardDirection = Vector2.left;
            racketSpeed = 4;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float inputY = Input.GetAxisRaw("Vertical2");
        float towardsDirection;

        if (!PauseMenu.isPaused)
        {
            racketDirection = new Vector2(0, inputY).normalized;

            if (isAI)
            {
                if (IsIncoming() && ReadyToMove() && AdjustmentNeeded())
                {
                    if (paddle.position.y > ball.transform.position.y)
                    {
                        towardsDirection = -1;
                    }
                    else { towardsDirection = 1; }
                    racketDirection = new Vector2(0, towardsDirection).normalized;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        paddle.velocity = racketDirection * racketSpeed;
    }

    private bool IsIncoming()
    {
        float dotP = Vector2.Dot(ball.getVelocity(), forwardDirection);
        return dotP < 0f;
    }

    private bool ReadyToMove()
    {
        return ball.transform.position.x > -3;
    }

    private bool AdjustmentNeeded()
    {
        return Math.Abs(paddle.position.y - ball.transform.position.y) > .2;
    }
}
