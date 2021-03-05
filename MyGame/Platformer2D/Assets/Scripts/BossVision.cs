using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class BossVision : MonoBehaviour
{
    [SerializeField] GameObject currentHitObject;

    [SerializeField] float circleRadius;
    [SerializeField] float maxDistance;
    [SerializeField] LayerMask layerMask;
    [SerializeField] Animator animator;
    [SerializeField] float TimeToAttack;

    Vector2 _origin;
    Vector2 _direction;

    float currentHitDistance;
    float _attackTimer;

    private void Start()
    {
        _attackTimer = TimeToAttack;
    }
    private void Update()
    {
        _origin = transform.position;

        _direction = Vector2.left;

        RaycastHit2D hit = Physics2D.CircleCast(_origin, circleRadius, _direction, maxDistance, layerMask);

        if (hit)
        {

            currentHitObject = hit.transform.gameObject;
            currentHitDistance = hit.distance;
            StartAttackTimer();

        }

        else
        {
            currentHitObject = null;
            currentHitDistance = maxDistance;
        }
    }

    void InitAttack()
    {
        if (currentHitObject.CompareTag("Player"))
        {
            animator.SetTrigger(Random.Range(1, 5).ToString());
        }
    }

    void StartAttackTimer()
    {
        _attackTimer -= Time.deltaTime;
        if (_attackTimer <=0)
        {
            _attackTimer = TimeToAttack;
            InitAttack();
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(_origin, _origin + _direction * currentHitDistance);
        Gizmos.DrawWireSphere(_origin + _direction * currentHitDistance, circleRadius);
    }
}
