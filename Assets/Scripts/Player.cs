using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : ShootableTank
{
    private float _timer;

    //-------fake Singleton Warning
    public static Player Instance;

    private void Awake()
    {
        Instance = this;
        //reference in Player Class!
    }
    //--------
    public override void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        _ui.UpdateHp(_currentHealth);
        if(_currentHealth <= 0)
        {
            Stats.ResetAllStats();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //reload scene using UnityEngine.SceneManagment;
        }
    }
    protected override void Move()
    {
        //Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //_rigidbody.velocity = direction.normalized * _movementSpeed;

        transform.Translate(Vector2.down * Input.GetAxis("Vertical") * _movementSpeed * Time.deltaTime);

    }
    private void Update()
    {
        Move();
        SetAngle(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        //flow input mousePosition
        if (_timer <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
                _timer = _reloadTime;
            }
        }
        else 
            _timer -= Time.deltaTime;
    }
}
