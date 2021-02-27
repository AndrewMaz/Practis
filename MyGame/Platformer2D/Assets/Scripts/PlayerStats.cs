using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    PlayerHealth _playerHealth;
    EnemyAttack _enemyAttack;
    Rigidbody2D _rb;
    StringBuilder _sbForLvl;
    StringBuilder _sbForList;
    AttackController _attackController;

    [SerializeField] TextMeshProUGUI lvlText;
    [SerializeField] TextMeshProUGUI lvlUpText;
    [SerializeField] TextMeshProUGUI abilityList;
    [SerializeField] float timeToDash = 3f;
    [SerializeField] Animator animator;
    [SerializeField] Transform playerModelTransform;
    [SerializeField] GameObject levelUpCanvas;

    bool _dashCD = true;

    float _damage = 1;
    int _exp = 0;
    int _expRequire = 3;
    int _lvl = 1;
    int _damageInc = 0;
    float _healthInc = 2;
    float _dashTimer;

    public int Exp
    {
        get => _exp;
        set { _exp = value; }
    }
    public float Damage
    {
        get => _damage;
    }
    void Start()
    {
        _sbForLvl = new StringBuilder();
        _sbForLvl.Append("HP+\nDash ability\n");
        lvlUpText.text = _sbForLvl.ToString();


        _sbForList = new StringBuilder();
        _sbForList.Append("Lmb - Light Slash\n");
        abilityList.text = _sbForList.ToString();
        abilityList.color = Color.black;

        lvlText.color = Color.white;
        lvlText.text = _lvl.ToString();

        _rb = GetComponent<Rigidbody2D>();
        _dashTimer = timeToDash;
        _enemyAttack = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyAttack>();
        _playerHealth = GetComponent<PlayerHealth>();
        _attackController = GetComponent<AttackController>();
    }

    
    void Update()
    {
        if (_exp >= _expRequire)
        {
            LevelUp();

            if (_lvl == 2)
            {
                _sbForList.AppendLine("Space - Dash");
                abilityList.text = _sbForList.ToString();
            }

            if (_lvl ==3)
            {
                _sbForList.AppendLine("Rmb - Heavy Slash");
                abilityList.text = _sbForList.ToString();
            }
        }

        if (_lvl >= 2)
        {
            if (Input.GetKeyDown(KeyCode.Space) && _dashCD)
            {
                Dash();
            }

            if (!_dashCD)
                StartDashTimer();
        }

        if (_lvl >= 3)
        {
            _attackController.HeavySlash = true;
        }
    }

    void Dash()
    {
        _enemyAttack.IsDamage = false;

        if (playerModelTransform.localScale.x < 0f)
        {
            animator.SetTrigger("dashR");
            _rb.AddForce(new Vector2(1500f, 0f));
        }

        else
        {
            animator.SetTrigger("dashL");
            _rb.AddForce(new Vector2(-1500f, 0f));
        }


        _dashCD = false;
    }
    void StartDashTimer()
    {
        _dashTimer -= Time.deltaTime;

        if (_dashTimer <0f)
        {
            _enemyAttack.IsDamage = true;
            _dashTimer = timeToDash;
            _dashCD = true;
        }
    }
    void LevelUp()
    {
        _lvl++;
        _exp -= _expRequire;
        _expRequire += 3;
        _damage += _damageInc;
        _damageInc += 1;
        _playerHealth.TotalHealth += _healthInc;
        _playerHealth.Health += _healthInc;
        lvlText.text = _lvl.ToString();
        levelUpCanvas.SetActive(true);
        Time.timeScale = 0f;
    }
}
