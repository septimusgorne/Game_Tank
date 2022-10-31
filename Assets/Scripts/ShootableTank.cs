using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootableTank : Tank
{
    [SerializeField] private GameObject _projectTile;
    [SerializeField] private string _projecTileTag;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] protected float _reloadTime = 0.5f;
    private ObjectPool _objectPool;
    protected override void Start()
    {
        base.Start();
        _objectPool = ObjectPool.Instance;
        //for fake Singletone in Object Pool
    }
    protected void Shoot()
    {
        //Instantiate(_projectTile, _shootPoint.position, transform.rotation);
        _objectPool.SpawnFromPool(_projecTileTag, _shootPoint.position, transform.rotation);
    }
}
