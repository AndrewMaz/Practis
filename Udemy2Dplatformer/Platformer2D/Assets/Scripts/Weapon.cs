using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] AudioSource hitSound;

    AttackController _attackController;

    float damage = 20f;

    private void Start()
    {
        _attackController = transform.root.GetComponent<AttackController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();

        if (enemyHealth != null && _attackController.IsAttack)
        {
            hitSound.Play();
            enemyHealth.ReduceHealth(damage);
        }

    }
}
