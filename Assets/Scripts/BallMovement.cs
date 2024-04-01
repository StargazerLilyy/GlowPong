using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float startingSpeed;
    public float extraSpeed;
    public float maxExtraSpeed;

    public bool servePlayer1 = true;

    private int hitCounter = 0;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(Launch());
    }

    private void ServeBall()
    {
        rb.velocity = new Vector2(0, 0);
        transform.position = new Vector2(0, 0);
    }

    public IEnumerator Launch()
    {
        ServeBall();
        hitCounter = 0;
        yield return new WaitForSeconds(1);

        if (servePlayer1)
        {
            MoveBall(new Vector2(-1, 0));
        }
        else
        {
            MoveBall(new Vector2(1, 0));
        }
    }

    public void MoveBall(Vector2 direction)
    {
        direction = direction.normalized;

        //float randFactor = Random.Range(90, 110);
        // float ballSpeed = randFactor * (startingSpeed + hitCounter * extraSpeed) / 100;
        float ballSpeed = (startingSpeed + hitCounter * extraSpeed);


        rb.velocity = direction * ballSpeed;
    }

    public void IncreaseHitCounter()
    {
        if (hitCounter * extraSpeed < maxExtraSpeed)
        {
            hitCounter++;
        }
    }
}
