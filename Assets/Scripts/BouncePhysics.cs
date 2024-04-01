using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePhysics : MonoBehaviour
{
    public GameObject hitSFX;
    public BallMovement ballMovement;
    public ScoreManager scoreManager;

    private void Bounce(Collision2D collision)
    {
        Vector3 ballPosition = transform.position;
        Vector3 racketPosition = collision.transform.position;
        float racketHeight = collision.collider.bounds.size.y;

        float positionX;
        if (collision.gameObject.name == "Player 1")
        {
            positionX = 1;
        }
        else { positionX = -1; }

        float positionY = (ballPosition.y - racketPosition.y) / racketHeight;

        ballMovement.IncreaseHitCounter();
        ballMovement.MoveBall(new Vector2(positionX, positionY));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player1" || collision.gameObject.name == "Player2")
        {
            Bounce(collision);
        }

        else if (collision.gameObject.name == "RightBorder")
        {
            Player1Scored();
        }

        else if (collision.gameObject.name == "LeftBorder")
        {
            Player2Scored();
        }

        Instantiate(hitSFX, transform.position, transform.rotation);
    }

    private void Player1Scored()
    {
        scoreManager.Player1Scored();
        ballMovement.servePlayer1 = false;
        StartCoroutine(ballMovement.Launch());
    }

    private void Player2Scored()
    {
        scoreManager.Player2Scored();
        ballMovement.servePlayer1 = true;
        StartCoroutine(ballMovement.Launch());
    }
}
