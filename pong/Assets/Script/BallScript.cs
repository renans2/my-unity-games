using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] private float minYForce;
    [SerializeField] private float maxYForce;
    [SerializeField] private float startingXSpeed;
    [SerializeField] private float xSpeedMultiplier;
    private Rigidbody2D rb;
    private float xSpeed;
    private GameManagerScript gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        xSpeed = startingXSpeed;
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManagerScript>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(xSpeed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject obj = collision.gameObject;

        if (obj.CompareTag("Paddle"))
        {
            xSpeed *= -xSpeedMultiplier;
            float randomYForce = Random.Range(minYForce, maxYForce);
            rb.AddForce(new Vector2(0, randomYForce), ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject sideBoundary = collision.gameObject;

        if (sideBoundary.CompareTag("LeftBoundary"))
        {
            gameManager.P2Scores();
            xSpeed = -startingXSpeed;
            rb.velocity = Vector2.zero;
        }
        else
        {
            gameManager.P1Scores();
            xSpeed = startingXSpeed;
            rb.velocity = Vector2.zero;
        }
    }
}
