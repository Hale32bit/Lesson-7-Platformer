using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class Personage : MonoBehaviour, IPersonageControl
{
    private Animator _animator;
    private SpriteRenderer _renderer;
    private Rigidbody2D _rigidbody;

    private bool _isGrounded;
    private bool _isIdle = true;
    private float _lastJumpTime;

    private const float HorizontalSpeed = 2f;
    private const float JumpImpulseSpeed = 7f;
    private const float MinJumpPeriod = 1f;
    private const float MinInclineCos = 0.9f;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        UpdateAnimator();

        HorizontalGroundStoping();
    }

    private void HorizontalGroundStoping()
    {
        if (_isGrounded && _isIdle)
            _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
        _isIdle = true;
    }

    private void UpdateAnimator()
    {
        _animator.SetFloat("Speed", Mathf.Abs(_rigidbody.velocity.x));
        _animator.SetBool("Grounded", _isGrounded);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        UpdateGrounded(collision);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        UpdateGrounded(collision);
    }

    private void UpdateGrounded(Collision2D collision)
    {
        foreach (var contact in collision.contacts)
        {
            if (Vector2.Dot(contact.normal, Vector2.up) > MinInclineCos)
            {
                _isGrounded = true;
                return;
            }
        }
        _isGrounded = false;
    }

    void IPersonageControl.Left()
    {
        _rigidbody.velocity = new Vector2(-HorizontalSpeed, _rigidbody.velocity.y);
        _renderer.flipX = true;
        _isIdle = false;
    }

    void IPersonageControl.Right()
    {
        _rigidbody.velocity = new Vector2(+HorizontalSpeed, _rigidbody.velocity.y);
        _renderer.flipX = false;
        _isIdle = false;
    }

    void IPersonageControl.Jump()
    {
        if (!_isGrounded)
            return;

        if (Time.time - _lastJumpTime < MinJumpPeriod)
            return;

        _rigidbody.velocity += Vector2.up * JumpImpulseSpeed;
        _isGrounded = false;
        _lastJumpTime = Time.time;
        _isIdle = false;
    }
}
