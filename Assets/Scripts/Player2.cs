using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class Player2 : MonoBehaviour
{
    public float racketSpeed;

    public BallMovement ball;

    private bool isAI;
    private Rigidbody2D paddle;
    private Vector2 racketDirection;
    private Vector2 forwardDirection;
    private AIDifficulty easy = AIDifficulty.Easy;
    private AIDifficulty medium = AIDifficulty.Medium;
    private AIDifficulty hard = AIDifficulty.Hard;

    // Start is called before the first frame update
    void Start()
    {
        paddle = GetComponent<Rigidbody2D>();

        isAI = GlobalSettings.singlePlayer;
        if (isAI)
        {
            forwardDirection = Vector2.left;

            if (GlobalSettings.singlePlayerDifficulty == easy) { racketSpeed = 3; }
            else { racketSpeed = 4; };

        }
    }

    // Update is called once per frame
    void Update()
    {
        float inputY = Input.GetAxisRaw("Vertical2");
        float towardsDirection;

        if (!PauseMenu.isPaused)
        {

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
                else
                {
                    if (!IsIncoming() && GlobalSettings.singlePlayerDifficulty == hard && NotCentered())
                    {
                        if (paddle.position.y > 0)
                        {
                            towardsDirection = -1;
                        }
                        else { towardsDirection = 1; }
                        racketDirection = new Vector2(0, towardsDirection).normalized;
                    }
                    else
                    {

                        racketDirection = new Vector2(0, 0).normalized;
                    }
                }
            }
            else
            {
                racketDirection = new Vector2(0, inputY).normalized;
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
        if (GlobalSettings.singlePlayerDifficulty == easy) { return true; }
        else if (GlobalSettings.singlePlayerDifficulty == medium) { return ball.transform.position.x > -3; }
        else { return ball.transform.position.x > -2.5; }
    }

    private bool AdjustmentNeeded()
    {
        return Math.Abs(paddle.position.y - ball.transform.position.y) > .2;
    }

    private bool NotCentered()
    {
        return Math.Abs(paddle.position.y) > .2;
    }
}
