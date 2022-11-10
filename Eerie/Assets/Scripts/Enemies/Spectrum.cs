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
        [SerializeField] private float shotForce = 15f;

        new void Start()
        {
            base.Start();
            _playerTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            _spawnPoint = transform.GetChild(0);
            _blueFire = Resources.Load<GameObject>("BlueFire");
            capsuleCollider = GetComponent<CapsuleCollider>();
            capsuleCollider.enabled = false;
        }

        protected override void Move()
        {
            var position = new Vector3(Random.Range(-3.0f, 3.0f), 0, Random.Range(-3.0f, 3.0f));
            transform.position = (Vector3.Distance(_playerTarget.position, transform.position) > 5f?
            Vector3.MoveTowards(transform.position, _playerTarget.position, Time.deltaTime):
            Vector3.MoveTowards(transform.position, transform.position += position, Time.deltaTime));
            transform.LookAt(_playerTarget);
        }

        public void SpawnAProjectile()=>
                LaunchFireBall();
    
        public void LaunchFireBall()
        {
            transform.LookAt(_playerTarget);
            GameObject FireBall;
            FireBall = Instantiate(_blueFire, _spawnPoint.transform);
            FireBall.transform.parent = null;
            FireBall.GetComponent<Rigidbody>().AddForce(_spawnPoint.forward * shotForce);
            FireBall.transform.LookAt(_playerTarget);

        }
    }
}
