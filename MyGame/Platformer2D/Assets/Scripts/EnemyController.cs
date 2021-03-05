using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float walkDistance = 5f;
    [SerializeField] float patrolSpeed= 1f;
    [SerializeField] float chaseSpeed = 3f;
    [SerializeField] float timeToWait = 5f;
    [SerializeField] float timeToChase = 3f;
    [SerializeField] float attackCD = 2f;
    [SerializeField] float minDistanceToPlayer = 1.5f;
    [SerializeField] Transform enemyModelTransform;
    [SerializeField] EnemyHealth enemyHealth;

    Rigidbody2D _rb;
    Transform _playerTransform;
    EnemyAttack _enemyAttack;

    Vector2 _leftBoundaryPosition;
    Vector2 _rightBoundaryPosition;
    Vector2 _nextPoint;

    bool _isWait = false;
    bool _isFacingRight = true;
    bool _isChasingPlayer = false;
    bool _isAttacking = false;

    public bool IsFacingRight
    {
        get => _isFacingRight;
    }

    public void ResetChaseSpeed()
    {
        chaseSpeed = 3f;
    }

    float _waitTime;
    float _chaseTime;
    float _walkSpeed;
    float _CdTime;

    public void StartChasingPlayer()
    {
        _isChasingPlayer = true;
        _chaseTime = timeToChase;
        _walkSpeed = chaseSpeed;
    }
    void Start()
    {
        _enemyAttack = GetComponent<EnemyAttack>();
        _playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _rb = GetComponent<Rigidbody2D>();
        _leftBoundaryPosition = transform.position;
        _rightBoundaryPosition = _leftBoundaryPosition + Vector2.right * walkDistance;
        _waitTime = timeToWait;
        _chaseTime = timeToChase;
        _walkSpeed = patrolSpeed;
        _CdTime = attackCD;
    }

    private void Update()
    {
        if (enemyHealth.IsAirBorne)
        {
            _walkSpeed = 0f;
        }


        if (_isAttacking && !enemyHealth.IsAirBorne)
            StartCdTimer();

        if (_isChasingPlayer && !enemyHealth.IsAirBorne)
            StartChaseTimer();

        if (_isWait && !_isChasingPlayer && !enemyHealth.IsAirBorne)
            StartWaitTimer();

        if (ShouldWait() && !enemyHealth.IsAirBorne)
            _isWait = true;
    }
    void FixedUpdate()
    {
        _nextPoint = Vector2.right * _walkSpeed * Time.fixedDeltaTime;

        if (Mathf.Abs(DistanceToPlayer()) < minDistanceToPlayer && _isChasingPlayer && !enemyHealth.IsAirBorne)
            InitiateAttack();

        if (_isChasingPlayer && !enemyHealth.IsAirBorne)
        {
            ChasePlayer();
        }

        if (!_isWait && !_isChasingPlayer && !enemyHealth.IsAirBorne)
            Patrol();
    }

    void InitiateAttack()
    {
        chaseSpeed = 0f;
        _isAttacking = true;

        if (enemyModelTransform.localScale.x < 0f)
            _enemyAttack.AttackR();

        else
            _enemyAttack.AttackL();
    }
    float DistanceToPlayer()
    {
        return _playerTransform.position.x - transform.position.x;
    }
    void ChasePlayer()
    {
        float distance = DistanceToPlayer();

        if (distance < 0)
            _nextPoint.x *= -1;
        _rb.MovePosition((Vector2)transform.position + _nextPoint);

        if (distance > 0.2f && !_isFacingRight)
            Flip();
        if (distance < 0.2f && _isFacingRight)
            Flip();
    }
    void Patrol()
    {

        if (!_isFacingRight)
            _nextPoint *= -1;
        _rb.MovePosition((Vector2)transform.position + _nextPoint);
    }

    void StartCdTimer()
    {
        _CdTime -= Time.deltaTime;

        if (_CdTime < 0f)
        {
            _CdTime = attackCD;
            chaseSpeed = 3f;
            _isAttacking = false;
        }
    }
    void StartChaseTimer()
    {
        _chaseTime -= Time.deltaTime;
        if(_chaseTime <0f)
        {
            _chaseTime = timeToChase;
            _isChasingPlayer = false;
            _walkSpeed = patrolSpeed;
        }
    }
    void StartWaitTimer()
    {
        _waitTime -= Time.deltaTime;
        if(_waitTime <0f)
        {
            _waitTime = timeToWait;
            _isWait = false;
            Flip();
        }
    }
    bool ShouldWait()
    {
        bool outOfRightBoundary = _isFacingRight && transform.position.x >= _rightBoundaryPosition.x;
        bool outOfLeftBoundary = !_isFacingRight && transform.position.x <= _leftBoundaryPosition.x;

        return outOfLeftBoundary || outOfRightBoundary;
    }

    void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 playerScale = enemyModelTransform.localScale;
        playerScale.x *= -1;
        enemyModelTransform.localScale = playerScale;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(_leftBoundaryPosition, _rightBoundaryPosition);
    }
}
