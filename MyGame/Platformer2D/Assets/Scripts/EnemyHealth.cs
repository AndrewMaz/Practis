using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float totalHealth = 3f;
    [SerializeField] Slider sliderHealth;
    [SerializeField] int expGain;

    Animator _animator;
    PlayerStats _playerStats;

    float _health;
    private void Start()
    {
        _playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        _animator = GetComponent<Animator>();
        _health = totalHealth;
        InitHealth();
    }
    public void ReduceHealth (float damage)
    {
        _health -= damage;
        InitHealth();
        _animator.SetTrigger("takeDamage");

        if (_health <= 0)
            Die();
    }

    void InitHealth()
    {
        sliderHealth.value = _health / totalHealth;
    }
    void Die()
    {
        gameObject.SetActive(false);
        _playerStats.Exp += expGain;
    }
}
