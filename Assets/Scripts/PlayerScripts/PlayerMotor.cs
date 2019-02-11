using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMotor : MonoBehaviour
{
    public SpriteRenderer sprite;
    [Range(1,10)]
    public float jumpVelocity;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    private float isPressed;
    private float jumpTimer = 0;
    private bool grounded = false;

    [SerializeField]
    private Camera cam;

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void GroundedOrNot(bool ground)
    {
        grounded = ground;
    }

    public void Move(float Xmov)
    {
        if (Xmov > 0)
            sprite.flipX = false;
        else if (Xmov < 0)
            sprite.flipX = true;

        if ((Xmov > 0.5f && rb2d.velocity.x < 0) || (Xmov < -0.5f && rb2d.velocity.x > 0))
            Xmov *= 2;
        Vector2 _V2Movement = new Vector2(Xmov,0);
        rb2d.AddForce(_V2Movement);
    }

    public void Jump(float _isPressed)
    {
        isPressed = _isPressed;
        if (jumpTimer > 0)
        {
            jumpTimer -= Time.deltaTime;
        }

        if(isPressed == 1 && grounded && jumpTimer<0.1)
        {
            rb2d.velocity += Vector2.up * jumpVelocity;
            jumpTimer = 0.2f;

        }
    }  
    
    void Update()
    {
        if (rb2d.velocity.y < 0)
        {
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb2d.velocity.y > 0 && isPressed != 1f)
        {
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}
