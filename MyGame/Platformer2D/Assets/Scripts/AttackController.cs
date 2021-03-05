using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] AudioSource attackSound;
    [SerializeField] float timeToStealTempest = 3f;
    [SerializeField] float timeToUlt = 30f;

    Weapon _weapon;

    float _doubleClickTimeLimit = 0.25f;
    float _stealTempestTimer;
    float _ultTimer;

    bool _isAttack = false;
    bool _heavySlash = false;
    bool _isHeavySlash = false;
    bool _stealTempest = false;
    bool _isStealTempest = false;
    bool _stealTempestCD = true;
    bool _isUlt = false;
    bool _ultCD = true;

    public bool IsUlt
    {
        get => _isUlt;
        set { _isUlt = value; }
    }
    public bool IsStealTempest
    {
        get => _isStealTempest;
        set { _isStealTempest = value; }
    }

    public bool StealTempest
    {
        get => _stealTempest;
        set { _stealTempest = value; }
    }
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
        _weapon = GameObject.FindGameObjectWithTag("Weapon").GetComponent<Weapon>();
        StartCoroutine(InputListener());
        _stealTempestTimer = timeToStealTempest;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && _heavySlash)
        {
            PerformHeavySlash();
        }

        if (Input.GetKeyDown(KeyCode.Q) && _stealTempest && _stealTempestCD)
        {
            PerformStealTempest();
        }

        if (!_stealTempestCD)
            StartStealTempestTimer();

        if (!_ultCD)
            StartUltTimer();

        if (Input.GetKeyDown(KeyCode.R) && _isUlt && _ultCD)
            PerformUlt();
    }

    void PerformUlt()
    {
        _isAttack = true;
        animator.SetTrigger("ult");
        _ultCD = false;
    }

    void StartUltTimer()
    {
        _ultTimer -= Time.deltaTime;
        if (_ultTimer <=0)
        {
            _ultTimer = timeToUlt;
            _ultCD = true;
        }
    }
    void StartStealTempestTimer()
    {
        _stealTempestTimer -= Time.deltaTime;
        if (_stealTempestTimer<=0)
        {
            _stealTempestTimer = timeToStealTempest;
            _stealTempestCD = true;
        }
    }
    void PerformStealTempest()
    {
        if (_weapon.TempestStacks <2)
        {
            _isAttack = true;
            animator.SetTrigger("attack3");
            attackSound.Play();
            _isStealTempest = true;
            _stealTempestCD = false;
        }

        else if (_weapon.TempestStacks == 2)
        {
            _isAttack = true;
            animator.SetTrigger("wirlWind");
            attackSound.Play();
            _isStealTempest = true;
            _stealTempestCD = false;
        }

    }
    void PerformHeavySlash()
    {
        _isAttack = true;
        animator.SetTrigger("attack2");
        attackSound.Play();
        _isHeavySlash = true;
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
