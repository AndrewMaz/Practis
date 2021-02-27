using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] AudioSource attackSound;

    float _doubleClickTimeLimit = 0.25f;

    bool _isAttack = false;
    bool _heavySlash = false;
    bool _isHeavySlash = false;

    public bool IsHeavySlash
    {
        get => _isHeavySlash;
        set { _isHeavySlash = value; }
    }
    public bool HeavySlash
    {
        get => _heavySlash;
        set { _heavySlash = value; }
    }
    public bool IsAttack { get => _isAttack; }

    public void AttackFinished()
    {
        _isAttack = false;
    }

    IEnumerator InputListener()
    {
        while (enabled)
        {

            if (Input.GetMouseButtonDown(0))
                yield return ClickEvent();

            yield return null;
        }
    }

    private void Start()
    {
        StartCoroutine(InputListener());
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && _heavySlash)
        {
            _isAttack = true;
            animator.SetTrigger("attack2");
            attackSound.Play();
            _isHeavySlash = true;
        }
    }

    IEnumerator ClickEvent()
    {
        yield return new WaitForEndOfFrame();

        float count = 0f;
        while (count < _doubleClickTimeLimit)
        {
            if (Input.GetMouseButtonDown(0))
            {
                DoubleClick();
                yield break;
            }

            count += Time.deltaTime;
            yield return null; 
        }
        SingleClick();
    }


    void SingleClick()
    {
        _isAttack = true;
        animator.SetTrigger("attack");
        attackSound.Play();
    }

    void DoubleClick()
    {
        _isAttack = true;
        animator.SetTrigger("attack");
        attackSound.Play();

        _isAttack = true;
        animator.SetTrigger("combo1");
        attackSound.Play();
    }

}
