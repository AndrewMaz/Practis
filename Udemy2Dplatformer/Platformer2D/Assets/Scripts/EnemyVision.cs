using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    [SerializeField] GameObject currentHitObject;

    [SerializeField] float circleRadius;
    [SerializeField] float maxDistance;
    [SerializeField] LayerMask layerMask;

    Vector2 _origin;
    Vector2 _direction;

    float currentHitDistance;

    EnemyController _enemyController;
    private void Update()
    {
        _enemyController = GetComponent<EnemyController>();

        _origin = transform.position;

        if (_enemyController.IsFacingRight)
            _direction = Vector2.right;
        else
            _direction = Vector2.left;

        RaycastHit2D hit = Physics2D.CircleCast(_origin, circleRadius, _direction, maxDistance, layerMask);

        if (hit)
        {

            currentHitObject = hit.transform.gameObject;
            currentHitDistance = hit.distance;
            if (currentHitObject.CompareTag("Player"))
            {
                _enemyController.StartChasingPlayer();
            }

        }

        else
        {
            currentHitObject = null;
            currentHitDistance = maxDistance;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(_origin, _origin + _direction * currentHitDistance);
        Gizmos.DrawWireSphere(_origin + _direction * currentHitDistance, circleRadius);
    }
}
