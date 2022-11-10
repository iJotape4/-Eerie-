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

        protected string animZombieIdle = "Anim_ZombieIdle";
        protected string animZombieWalk = "Anim_ZombieWalk";
        protected string[] animZombieAttacks = 
        { 
        "Anim_ZombieAttack", 
        "Anim_Zombie2Attack", 
        "Anim_SubBossAttack1", 
        "Anim_SubBossAttack2",
        "Anim_SubBossAttack3", 
        "Anim_SubBossAttack4"
        };

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

        public void Update()
        {
            Walk();
        }

       public override void Walk()
       {
           if(DetectPlayer() && _canPursuit)
            {                
                anim.SetBool(_animPlayerDetectedBool, true);
                FollowPlayer();
            }
            else
            {
                anim.SetBool(_animAttackZoneBool, false);
                Patrol();
            }
       }

        public override void Patrol()
        {
            if (points.Length == 0)
            {
                anim.Play(animZombieIdle);
                return;
            }
            StartCoroutine(GoToNextPoint(currentPatrolPoint));
        }

       public override IEnumerator GoToNextPoint(int patrolPoint)
       {
            Vector3 target = points[patrolPoint].transform.position;
            anim.Play(animZombieWalk);
            transform.LookAt(points[patrolPoint]);
            transform.position = Vector3.MoveTowards(transform.position, target, _speed * Time.deltaTime);

            if (transform.position.x == target.x && transform.position.z == target.z)            
                currentPatrolPoint++;       

            if (currentPatrolPoint == points.Length )
                currentPatrolPoint = 0;
            yield return null;
       }
      
      public Transform DoRayCast()
      {          
            RaycastHit hit;
            Vector3 rayDirection =  transform.forward*_range;
            Ray detectionRay = new Ray(transform.position, rayDirection);
            Debug.DrawRay(transform.position, rayDirection, Color.green);

            if (Physics.Raycast(detectionRay, out hit))
                return hit.transform;
                       
           return null;
      }
       
        public override bool DetectPlayer()
       {          
            var selection = DoRayCast();
            if(selection==null)
                return false;

            if(selection.CompareTag("Untagged"))
                return false;

            if(selection.CompareTag("Player"))
                return true;
            
            return false;
       }
       
        public  void FollowPlayer()
       {
            var selection = DoRayCast();

            if(selection==null)
                return;

            if(Vector3.Distance(transform.position, selection.position) < _attackzone)
            {
                anim.SetBool(_animAttackZoneBool, true);
            }
            else
            {
                anim.SetBool(_animAttackZoneBool, false);
            }

            foreach (string animation in animZombieAttacks)
            {
                if (anim.GetCurrentAnimatorStateInfo(0).IsName(animation))               
                    //This stops the zombie to move while is attacking
                    return;
                
            }
            //Move Towards Player
            transform.position = Vector3.MoveTowards(transform.position, selection.transform.position, _speed * Time.deltaTime);
            transform.LookAt(selection.transform.position);
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
