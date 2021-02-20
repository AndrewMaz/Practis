using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] AudioSource attackSound;

    bool _isAttack = false;
    public bool IsAttack { get => _isAttack; }

    public void AttackFinished()
    {
        _isAttack = false;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isAttack = true;
            animator.SetTrigger("attack");
            attackSound.Play();
        }
    }
}
