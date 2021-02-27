using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] float damage = 10f;
    [SerializeField] float TimeToDamage = 2f;
    [SerializeField] Animator animator;

    float _damageTime;

    bool _isDamage = true;

    public bool IsDamage
    {
        set { _isDamage = value; }
    }
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

    public void AttackR()
    {
        animator.SetTrigger("attackR"); 
    }

    public void AttackL()
    {
        animator.SetTrigger("attackL");
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
