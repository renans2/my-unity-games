using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    [SerializeField] private bool leftSide;
    [SerializeField] private float paddleSpeed;
    private Rigidbody2D rb;
    private bool jumped = false;
    private bool canJump = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (PressedJump() && !jumped && canJump)
        {
            jumped = true;
        }
    }

    private void FixedUpdate()
    {
        if (jumped)
        {
            rb.velocity = Vector2.up * paddleSpeed;
            jumped = false;
        }
    }

    private bool PressedJump()
    {
        return (leftSide && Input.GetKeyDown(KeyCode.Q)) || 
               (!leftSide && Input.GetKeyDown(KeyCode.P));
    }

    public void EnableJumping()
    {
        canJump = true;
    }
    public void DisableJumping()
    {
        canJump = false;
    }
}
