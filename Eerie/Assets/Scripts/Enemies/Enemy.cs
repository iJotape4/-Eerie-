using UnityEngine;

namespace  Enemies
{
    [RequireComponent(typeof(Animator))]
    public abstract class Enemy : MonoBehaviour
    {
       [SerializeField] protected float _health =100f;
       [SerializeField, Range(0.1f, 1000f)] protected float _maxHealt =100f;
       [SerializeField] protected float _armor =0f;
       [SerializeField , Range(0.1f, 100f)] protected float _damage =10f;

       [SerializeField] protected Animator anim;

        protected string _animIdleBool = "Idle";

       public void Start()
       {
            anim =GetComponent<Animator>();
       }
    }  
}
