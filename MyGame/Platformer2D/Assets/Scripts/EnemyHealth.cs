using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float totalHealth = 3f;
    [SerializeField] Slider sliderHealth;
    [SerializeField] float expGain;

    Animator _animator;
    PlayerStats _playerStats;

    float _health;

    bool _isAirBorne = false;

    public bool IsAirBorne
    {
        get => _isAirBorne;
        set { _isAirBorne = value; }
    }
    private void Start()
    {
        _playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        _animator = GetComponent<Animator>();
        _health = totalHealth;
        InitHealth();
    }

    private void Update()
    {
        if (_isAirBorne)
        {
            _animator.SetTrigger("knockUp");
        }
    }
    public void ReduceHealth (float damage)
    {
        _health -= damage;
        InitHealth();
        _animator.SetTrigger("takeDamage");

        if (_health <= 0)
        {
            _animator.SetTrigger("die");
        }

    }

    void InitHealth()
    {
        sliderHealth.value = _health / totalHealth;
    }
    public void Die()
    {
        gameObject.SetActive(false);
        _playerStats.Exp += expGain;
    }
}
