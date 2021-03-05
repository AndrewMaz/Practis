using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    PlayerHealth _playerHealth;
    Animator _animator;

    private void Start()
    {
        _playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        _animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _playerHealth.Health += 10;
        if (_playerHealth.Health > _playerHealth.TotalHealth)
            _playerHealth.Health = _playerHealth.TotalHealth;
        _animator.SetTrigger("pickUp");
    }

    public void Destroy()
    {
        gameObject.SetActive(false);
    }
}
