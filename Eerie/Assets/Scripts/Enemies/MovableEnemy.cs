using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class MovableEnemy : Enemy
    {
        
        protected Rigidbody _rb;
        protected abstract void Move();

        public new void Start() 
        {
            base.Start();
            _rb = GetComponent<Rigidbody>();
        }
    }

}
