using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    [SerializeField] AudioSource hitSound;

    AttackController _attackController;
    PlayerStats _playerStats;


    private void Start()
    {
        _playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        _attackController = transform.root.GetComponent<AttackController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();

        if (enemyHealth != null && _attackController.IsAttack)
        {
            if (_attackController.IsHeavySlash)
            {
                hitSound.Play();
                enemyHealth.ReduceHealth(_playerStats.Damage + 2);
            }

            else
            {
                hitSound.Play();
                enemyHealth.ReduceHealth(_playerStats.Damage);
            }
        }

    }
}
