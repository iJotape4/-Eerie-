using UnityEngine;
using GameEvents;
namespace PlayerScripts
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] WeaponsManagerScriptableObject weaponsManagerScriptableObject;
        [SerializeField] private bool _fire1, _holdFire1, _fire2, _holdFire2;   

        private void Update() 
        {   
            if(!_fire1 && !_holdFire1 && _fire2 && _holdFire2)
                return;

            Fire();
            
        }

        public void Fire()
        {
            if(_fire1)
                weaponsManagerScriptableObject.Fire1();
            if(_holdFire1)
                weaponsManagerScriptableObject.HoldFire1();
            if(_fire2)
                weaponsManagerScriptableObject.Fire2();
            if(_holdFire2)
                weaponsManagerScriptableObject.HoldFire2();
        }

        public void ReceiveInput(bool fire1, bool holdFire1, bool fire2, bool holdFire2)
        {
            _fire1 = fire1;
            _holdFire1 = holdFire1;
            _fire2 = fire2;
            _holdFire2 = holdFire2;
        }
    }
}
