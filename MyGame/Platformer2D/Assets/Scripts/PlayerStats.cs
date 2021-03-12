using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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
    [SerializeField] Slider slderExp;

    bool _dashCD = true;

    float _damage = 1f;
    float _exp = 0f;
    float _expRequire = 3f;
    int _lvl = 1;
    int _damageInc = 0;
    float _healthInc = 2;
    float _dashTimer;

    public float Exp
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
        _sbForList.Append("LMB - LIGHT SLASH\n");
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
        InitExp();

        if (_exp >= _expRequire)
        {
            LevelUp();

            if (_lvl == 2)
            {
                _sbForList.AppendLine("SPACE - DASH");
                abilityList.text = _sbForList.ToString();
            }

            if (_lvl ==3)
            {
                _sbForLvl.Clear();
                _sbForLvl.Append("HP+\nDamage+\nHeavySlash");
                lvlUpText.text = _sbForLvl.ToString();

                _sbForList.AppendLine("RMB - HEAVY SLASH");
                abilityList.text = _sbForList.ToString();
            }

            if (_lvl == 4)
            {
                _sbForLvl.Clear();
                _sbForLvl.Append("HP+\nDamage+\nStealTempest");
                lvlUpText.text = _sbForLvl.ToString();

                _sbForList.AppendLine("Q - STEALTEMPEST (Q3 WILL SEND WIRLWIND THAT KNOCKS UP ENEMIES)");
                abilityList.text = _sbForList.ToString();
            }

            if (_lvl == 5)
            {
                _sbForLvl.Clear();
                _sbForLvl.Append("HP+\nDamage+");
                lvlUpText.text = _sbForLvl.ToString();
            }

            if (_lvl == 6)
            {
                _sbForLvl.Clear();
                _sbForLvl.Append("HP+\nDamage+\nLastBreath");
                lvlUpText.text = _sbForLvl.ToString();

                _sbForList.AppendLine("R - FINAL SLASH TO AIRBORNE ANEMIES (30 SEC COOLDOWN)");
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

        if (_lvl >= 4)
        {
            _attackController.StealTempest = true;
        }

        if (_lvl >= 6)
        {
            _attackController.IsUlt = true;
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
        _expRequire += 4;
        _damage += _damageInc;
        _damageInc++;
        _playerHealth.TotalHealth += _healthInc;
        _playerHealth.Health += _healthInc;
        lvlText.text = _lvl.ToString();
        levelUpCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    void InitExp()
    {
        slderExp.value = _exp / _expRequire;
    }
}
