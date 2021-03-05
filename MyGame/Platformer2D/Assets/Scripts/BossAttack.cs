using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] float TimeToDamage = 3f;
    [SerializeField] float damage = 3f;

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
            if (_damageTime <= 0)
            {
                _isDamage = true;
                _damageTime = TimeToDamage;
            }

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

        if (playerHealth != null && _isDamage)
        {
            playerHealth.ReduceHealth(damage);
            _isDamage = false;
        }
    }
}
