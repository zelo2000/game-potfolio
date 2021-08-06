using Assets.Scripts.Constants;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 8f;
    public float JumpForce = 700f;
    public Transform GroundCheck;
    public LayerMask GroudIdentifier;

    public bool FacingRight { get; private set; } = true;

    private Animator _animator;
    private bool _isGrounded = false;
    private float _groundRagius = 0.2f;

    public float TimeToChangeColorBack { get; set; }

    public void Flip()
    {
        FacingRight = !FacingRight;
        var scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        _isGrounded = Physics2D.OverlapCircle(GroundCheck.position, _groundRagius, GroudIdentifier);
        _animator.SetBool(PlayerJumpAnimation.IsInGround, _isGrounded);

        var rigidbody = GetComponent<Rigidbody2D>();
        _animator.SetFloat(PlayerJumpAnimation.VerticalSpeed, rigidbody.velocity.y);

        var move = Input.GetAxis("Horizontal");
        _animator.SetFloat(PlayerJumpAnimation.HorizontalSpeed, Mathf.Abs(move));
        rigidbody.velocity = new Vector2(move * Speed, rigidbody.velocity.y);

        if (move > 0 && !FacingRight)
        {
            Flip();
        }
        else if (move < 0 && FacingRight)
        {
            Flip();
        }
    }

    void Update()
    {
        if (Time.time > TimeToChangeColorBack)
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }

        if (_isGrounded && Input.GetButtonDown("Jump"))
        {
            _animator.SetBool(PlayerJumpAnimation.IsInGround, false);
            var rigidbody = GetComponent<Rigidbody2D>();
            rigidbody.AddForce(new Vector2(0, JumpForce));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name != "Acid")
        {
            Acid.IsWithPlayer = false;
        }
    }

}
