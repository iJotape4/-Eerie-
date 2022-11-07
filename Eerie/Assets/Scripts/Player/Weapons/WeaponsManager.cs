using UnityEngine;
using System.Collections;
using GameEvents;

namespace PlayerScripts
{
    public class WeaponsManager : MonoBehaviour
    {
        [SerializeField] public GameObject currentWeapon;
        [SerializeField] public WeaponsList _currentWeaponIndex=0;
        [SerializeField] private GameObject[] weapons;

        [SerializeField] public WeaponsManagerScriptableObject weaponsManagerScriptableObject;

        [Header("Animation Parameters")]
        [SerializeField] private Animator _anim;
        private string _animChangeWeaponTrigger = "WeaponChange";
        private string _animCurrentWeaponInt = "CurrentWeapon";

        [Header("AnimationsDictionary")]
		private string _animationBibleHit = "Anim_Arms_BibleHit";
		private string _animationHolyWater = "Anim_Arms_HolyWater";
		private string _animationBibloomerang = "Anim_Arms_Bibloomerang";
		private string _animationSmartWatch = "Anim_Arms_SmartWatch";

		[SerializeField] public bool _inBiblioomerang;
        
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

        protected void SetCurrentWeapon(int index)
        {
            currentWeapon =weapons[index];
            _anim.SetInteger(_animCurrentWeaponInt, index);
        }      


        private IEnumerator ShowWeapon(int index)
            {
                StartCoroutine(AnimatorTriggersController(_animChangeWeaponTrigger));
                
                yield return new WaitForSeconds(1f);
                currentWeapon.SetActive(false);
                currentWeapon = weapons[index];
                currentWeapon.SetActive(true);
                _currentWeaponIndex = (WeaponsList)index;
                SetCurrentWeapon(((int)_currentWeaponIndex));             
            }

        public void CallAttackAnimationTrigger(string animatorTrigger)=>
            StartCoroutine(AnimatorTriggersController(animatorTrigger));

        private IEnumerator AnimatorTriggersController(string animatorTrigger)
		{
			_anim.SetTrigger(animatorTrigger);
			yield return new WaitForSeconds(0.5f);
			_anim.ResetTrigger(animatorTrigger);
			
		}

        public bool verifyAnimator()
        {
            AnimatorStateInfo animState = _anim.GetCurrentAnimatorStateInfo(0);

			if (animState.IsName(_animationBibleHit) || animState.IsName(_animationHolyWater) || _inBiblioomerang)
			{
				return false;
            }
            else
            {
				return true;
			}	
        }
        

        public void ReceiveInput(WeaponsList index)
        {
            if(index!= _currentWeaponIndex && verifyAnimator())
                StartCoroutine(ShowWeapon(((int)index)));
        }       
        
    }

    public enum WeaponsList
    {
        Barehand, Bible, HolyWater
    }
}
