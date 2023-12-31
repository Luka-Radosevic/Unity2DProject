using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 30f;
    [SerializeField] Vector2 launchDirection = new Vector2(1,4);
    [SerializeField] GameObject ballPrefab;

    Rigidbody2D rb2D;
    Vector3 ballOffset;
    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Ball ball = GetComponentInChildren<Ball>();
        ballOffset = ball.transform.position - transform.position;
    }

    void Update()
    {
        rb2D.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, 0);

        if(transform.childCount > 0 && Input.GetButtonDown("Jump"))
        {
            Ball ball = GetComponentInChildren<Ball>();
            ball.Launch(launchDirection);
        }
    }

    public void BallReset()
    {
        Ball ball = Instantiate(ballPrefab).GetComponent<Ball>();
        ball.transform.parent = transform;
        ball.transform.position = transform.position + ballOffset;
    }
}
