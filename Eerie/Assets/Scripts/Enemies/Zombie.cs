using UnityEngine;
using System.Collections;

namespace Enemies
{
    public class Zombie : PatrollerEnemy, IPlayerFollower, IStuneable, IMortalGameActor, IDispelable, IDamageable, IAttackWithHands
    {
        [SerializeField] private bool _stunned;
        [SerializeField] private bool _hitted;
        [SerializeField] private bool _canPursuit = true;

        [SerializeField, Range(0.5f, 3f)] private float _attackzone = 1.2f;
        [SerializeField, Range(0.5f, 3f)] private float pushForce;
        [SerializeField] private SkinnedMeshRenderer[] meshRenderers;
       
       //Anim Params
       protected string _animAttackZoneBool = "AttackZone";
        protected string _animRunnerZombieBool = "RunnerZombie";
        protected string _animStunnedBool = "Stunned";
        protected string _animHittedTrigger = "Hitted";
        protected string _animDeathTrigger = "Death";

        public new void Start()
        {
            base.Start();
            meshRenderers= GetComponentsInChildren<SkinnedMeshRenderer>();

            foreach(Transform GO in GetComponentsInChildren<Transform>())
            {
                if(GO.gameObject.name == "PatrolPoints")
                {
                    points = GO.GetComponentsInChildren<Transform>();

                    for (int i =0; i<points.Length-1;i++)
                        points[i] = points[i+1];
                    GO.SetParent(null);
                }
            }
        }

       public override void Walk()
       {

       }

        public override void Patrol()
       {

       }

       public override IEnumerator GoToNextPoint(int patrolPoint)
       {
            yield return null;
       }
       
        public override void DetectPlayer()
       {

       }
       
        public  void FollowPlayer()
       {

       }

       public void AttackWithHands()
       {

       }
       
       public void ReceiveStun()
       {

       }

       public void StunEnds()
       {

       }

       public void CallDeath()
       {

       }

       public void OnDeath()
       {

       }

       public void Dispel()
       {

       }

       public void  ChangeHealth( float newHealth)
       {

       }
    }
}
