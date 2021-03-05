using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ult : MonoBehaviour
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
        Rigidbody2D _rb = collision.transform.root.GetComponent<Rigidbody2D>();

        if (enemyHealth != null && _attackController.IsAttack && enemyHealth.IsAirBorne)
        {
            hitSound.Play();
            enemyHealth.ReduceHealth(_playerStats.Damage + 5);
            _rb.AddForce(new Vector2(0f, 2000f));
        }

    }
}
