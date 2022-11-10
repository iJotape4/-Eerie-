using UnityEngine;
using System.Collections;

namespace Enemies
{
    public abstract class PatrollerEnemy : MovableEnemy, IPatrolAction
    {
        [SerializeField] protected Transform[] points;
        [SerializeField] protected int currentPatrolPoint = 0;
        [SerializeField, Range(1f,20f)] public float _range = 20f;
        [SerializeField, Range(1f,20f)] public float _speed = 1f;
        [SerializeField, Range(1f,20f)] public float _walkSpeed = 1f;
        [SerializeField, Range(1f,20f)] public float _runSpeed = 5f;

        //Animation Params
        protected string _animPatrollingBool = "Patrolling";
        protected string _animPlayerDetectedBool = "PlayerDetected";

       protected override void Move()=>
            Walk();    

       public abstract void Walk();
       public abstract void Patrol();
       public abstract IEnumerator GoToNextPoint(int patrolPoint);
       
       public abstract bool DetectPlayer();
    }
}
