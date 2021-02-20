using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float totalHealth = 100f;
    [SerializeField] Slider sliderHealth;
    [SerializeField] Animator _animator;

    float _health;
    private void Start()
    {
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
    }
}
