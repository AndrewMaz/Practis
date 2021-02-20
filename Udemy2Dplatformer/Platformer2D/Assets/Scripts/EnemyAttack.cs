using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] float damage = 10f;
    [SerializeField] float TimeToDamage = 1f;

    float _damageTime;

    bool _isDamage = true;
    private void Start()
    {
        _damageTime = TimeToDamage;
    }

    private void Update()
    {
        if (!_isDamage)
        {
            _damageTime -= Time.deltaTime;
            if(_damageTime <=0)
            {
                _isDamage = true;
                _damageTime = TimeToDamage;
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

        if (playerHealth != null && _isDamage)
        {
            playerHealth.ReduceHealth(damage);
            _isDamage = false;
        }
    }

}
