using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public Transform GroundCollider;
    public float speed = 1000f;

    private PlayerMotor motor;
    private bool grounded = false;

    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");

        CheckCollision();
        Move(_xMov);
        Jump(_zMov);
    }

    void CheckCollision()
    {
        grounded = Physics2D.Linecast(transform.position, GroundCollider.position, 1 << LayerMask.NameToLayer("Ground"));
        motor.GroundedOrNot(grounded);
    }

    void Move(float _xMov)
    {
        float sendX = _xMov * speed * Time.deltaTime;
        motor.Move(sendX);
    }

    void Jump(float _zMov)
    {
        motor.Jump(_zMov);
    }
}