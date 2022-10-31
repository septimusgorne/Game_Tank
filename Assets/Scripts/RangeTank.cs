using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeTank : ShootableTank
{
    [SerializeField] private float _distanceTopPlayer = 5f;
    private float _timer;
    private Transform _target;

    private Player _player;
    //for fake Singletone

    protected override void Start()
    {
        base.Start();
        //_target = GameObject.FindGameObjectWithTag("Player").transform;
        _target = FindObjectOfType<Player>().transform;
        //equal notepad up

        _player = Player.Instance;
        //----fake Singletone
        
    }
    protected override void Move()
    {
        transform.Translate(Vector2.down * _movementSpeed * Time.deltaTime);
    }
    private void Update()
    {
        if(Vector2.Distance(transform.position, _target.position) > _distanceTopPlayer)
            Move();
        SetAngle(_target.position);
        if(_timer <= 0)
        {
            Shoot();
            _timer = _reloadTime;
        }
        else
            _timer = Time.deltaTime;
    }
}
