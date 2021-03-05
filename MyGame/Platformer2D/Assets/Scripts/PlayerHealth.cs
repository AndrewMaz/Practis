using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] GameObject gameOverCanvas;
    [SerializeField] float totalHealth = 200f;
    [SerializeField] Animator animator;
    [SerializeField] Slider healthSlider;
    [SerializeField] AudioSource hurtSound;

    float _health;

    public float Health
    {
        get => _health;
        set { _health = value; }
    }
    public float TotalHealth
    {
        get => totalHealth;
        set { totalHealth = value; }
    }
    private void Start()
    {
        _health = totalHealth;
    }

    private void Update()
    {
        InitHealth();
    }
    public void ReduceHealth(float damage)
    {
        _health -= damage;
        animator.SetTrigger("takeDamage");
        hurtSound.Play();

        if (_health <= 0)
            Die();
    }

    void InitHealth()
    {
        healthSlider.value = _health / totalHealth;
    }
    void Die()
    {
        gameObject.SetActive(false);
        gameOverCanvas.SetActive(true);
    }
}
