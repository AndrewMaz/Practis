using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverArm : MonoBehaviour
{
    Finish _finish;
    Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _finish = GameObject.FindGameObjectWithTag("Finish").GetComponent<Finish>();
    }
    public void ActivateLeverArm()
    {
        _animator.SetTrigger("Activate");
        _finish.ActivateFinish();
    }
}
