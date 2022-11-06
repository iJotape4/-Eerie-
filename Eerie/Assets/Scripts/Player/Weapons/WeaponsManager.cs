using UnityEngine;
using System.Collections;
namespace PlayerScripts
{
    public class WeaponsManager : MonoBehaviour
    {
        [SerializeField] private GameObject currentWeapon;
        [SerializeField] private WeaponsList _currentWeaponIndex=0;
        [SerializeField] private GameObject[] weapons;

        [Header("Animation Parameters")]
        [SerializeField] private Animator _anim;
        private string _animChangeWeaponTrigger = "WeaponChange";
        
        private void Start() 
        {
            FindArmsAnimator();
            UpdateWeaponsList();
            HideWeapons();
        }
        protected void FindArmsAnimator()=>
            _anim = GameObject.FindGameObjectWithTag("Arms").GetComponent<Animator>();

        protected void UpdateWeaponsList() =>  
            weapons = GameObject.FindGameObjectsWithTag("Weapon");
        
        protected void HideWeapons() 
        {
            foreach (GameObject weapon in weapons)
                weapon.SetActive(false);
        }

        protected void SetCurrentWeapon(int index)=>
            currentWeapon =weapons[index];

        private IEnumerator ShowWeapon(int index)
            {
                _anim.SetTrigger(_animChangeWeaponTrigger);
                yield return new WaitForSeconds(0.5f);
                _anim.ResetTrigger(_animChangeWeaponTrigger);

                currentWeapon.SetActive(false);
                currentWeapon = weapons[index];
                currentWeapon.SetActive(true);
                _currentWeaponIndex = (WeaponsList)index;
                SetCurrentWeapon(((int)_currentWeaponIndex));
            }

        public void ReceiveInput(WeaponsList index)
        {
            if(index!= _currentWeaponIndex)
                StartCoroutine(ShowWeapon(((int)index)));
        }       
        
    }

    public enum WeaponsList
    {
        Barehand, Bible, HolyWater
    }
}
