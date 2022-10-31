using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeTank : Tank
{
    [SerializeField] private int _damage = 5;
    private Transform _target;
    private float _timer;
    private float _hitCooldown = 1f;

    protected override void Start()
    {
        base.Start();
        _target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    protected override void Move()
    {
        transform.Translate(Vector2.down * _movementSpeed * Time.deltaTime);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Player>() != null && _timer <= 0)
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(_damage);
            _timer = _hitCooldown;
        }
    }

    private void Update()
    {
        if (_target != null)
        {
            if (_timer <= 0)
            {
                Move();
                SetAngle(_target.position);
            }
            else
                _timer = Time.deltaTime;
        }
    }
}
