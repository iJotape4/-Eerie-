using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Enemies
{
    public class Spectrum : MovableEnemy, IProjectilesSpawner
    {
        [SerializeField] protected Transform _playerTarget;
        [SerializeField] protected Transform _spawnPoint;
        [SerializeField] protected GameObject _blueFire;

        [SerializeField] protected CapsuleCollider capsuleCollider;

        [SerializeField, Range(1f, 20f)] protected float shotCadency = 15f;
        [SerializeField] private float counter;

       protected override void Move()
       {

       }

       public void SpawnAProjectile()
       {

       }
    }
}
