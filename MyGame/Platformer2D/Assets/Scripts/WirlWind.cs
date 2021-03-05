using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WirlWind : MonoBehaviour
{
    [SerializeField] AudioSource hitSound;

    PlayerStats _playerStats;
    AttackController _attackController;

    private void Start()
    {
        _attackController = GameObject.FindGameObjectWithTag("Player").GetComponent<AttackController>();
        _playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();

        if (enemyHealth != null && _attackController.IsAttack)
        {
            hitSound.Play();
            enemyHealth.ReduceHealth(_playerStats.Damage);
            enemyHealth.IsAirBorne = true;
        }

    }
}
