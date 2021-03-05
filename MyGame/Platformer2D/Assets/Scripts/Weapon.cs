using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    [SerializeField] AudioSource hitSound;
    [SerializeField] float timeToStacks = 5f;

    AttackController _attackController;
    PlayerStats _playerStats;

    float _tempestStacks;
    float _stacksTimer;

    public float TempestStacks
    {
        get => _tempestStacks;
    }
    private void Start()
    {
        _tempestStacks = 0f;
        Debug.Log(_tempestStacks);
        _stacksTimer = timeToStacks;
        _playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        _attackController = GameObject.FindGameObjectWithTag("Player").GetComponent<AttackController>();
    }

    private void Update()
    {
        if (_tempestStacks > 0)
            StartStacksTimer();
    }

    void StartStacksTimer()
    {
        _stacksTimer -= Time.deltaTime;
        if(_stacksTimer <=0)
        {
            _stacksTimer = timeToStacks;
            _tempestStacks = 0;
        }
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

            else if (_attackController.IsStealTempest && _tempestStacks <2)
            {
                hitSound.Play();
                enemyHealth.ReduceHealth(_playerStats.Damage - 2);
                _tempestStacks++;
                Debug.Log(_tempestStacks);
                _stacksTimer = timeToStacks;
            }

            else
            {
                hitSound.Play();
                enemyHealth.ReduceHealth(_playerStats.Damage);
            }


        }

    }
}
