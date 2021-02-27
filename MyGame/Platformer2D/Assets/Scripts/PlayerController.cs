using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speedX = 1f;
    [SerializeField] Animator animator;
    [SerializeField] Transform playerModelTransform;
    [SerializeField] AudioSource jumpSound;

    const float _speedXMultiplier = 150f;

    bool _isGround = false;
    bool _isJump = false;
    bool _isFacingLeft = true;
    bool _isFinish = false;
    bool _isLeverArm = false;

    Finish _finish;
    LeverArm _leverArm;
    Rigidbody2D _rb;

    float _horizontal = 0f;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _finish = GameObject.FindGameObjectWithTag("Finish").GetComponent<Finish>();
        _leverArm = FindObjectOfType<LeverArm>();
    }

    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        animator.SetFloat("speedX", Mathf.Abs(_horizontal));

        if (Input.GetKeyDown(KeyCode.W) && _isGround)
        {
            _isJump = true;
            jumpSound.Play();
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            if (_isFinish)
                _finish.FinishGame();
            if (_isLeverArm)
                _leverArm.ActivateLeverArm();
        }
    }

    void FixedUpdate()
    {
        if (_isJump)
        {
            _rb.AddForce(new Vector2(0f, 450f));
            _isJump = false;
            _isGround = false;
        }

        _rb.velocity = new Vector2(_horizontal * speedX * _speedXMultiplier * Time.fixedDeltaTime, _rb.velocity.y);

        if (_horizontal < 0f && !_isFacingLeft)
            Flip();
        else if (_horizontal > 0f && _isFacingLeft)
            Flip();
    }

    void Flip()
    {
        _isFacingLeft = !_isFacingLeft;
        Vector3 playerScale = playerModelTransform.localScale;
        playerScale.x *= -1;
        playerModelTransform.localScale = playerScale;
    }
    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGround = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LeverArm leverArmTemp = collision.GetComponent<LeverArm>();

        if (collision.CompareTag("Finish"))
            _isFinish = true;

        if (leverArmTemp != null)
            _isLeverArm = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        LeverArm leverArmTemp = collision.GetComponent<LeverArm>();

        if (collision.CompareTag("Finish"))
            _isFinish = false;

        if (leverArmTemp != null)
            _isLeverArm = false;
    }
}
