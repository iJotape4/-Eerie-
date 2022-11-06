using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "PlayerWeaponScriptableObject", menuName ="ScriptableObjects/PlayerWeaponsManager")]
public class PlayerWeaponsManagerScriptableObject : ScriptableObject
{
    public string magneticWeapon = "MagneticWeapon";
    public string parabolicWeapon = "ParabolicWeapon";
    public string boomerangWeapon = "BoomerangWeapon";
    public string currentWeapon;

   /* public WeaponParabolicScriptableObject parabolicScriptableObject;
    public WeaponForceFieldScriptableObject forceFieldScriptableObject;
      public WeaponBoomerangScriptableObject weaponBoomerangScriptableObject;*/
    public ScriptableObject currentWeaponScriptableObject;

    [System.NonSerialized]
    public UnityEvent<string> weaponChangeEvent;

    // Start is called before the first frame update
    private void OnEnable(){
        currentWeapon = "";
        if(weaponChangeEvent ==null){
            weaponChangeEvent = new UnityEvent<string>();
        }
    }

    public void ChangePlayerWeapon(string weapon){
        currentWeapon = weapon;
        
     /*   if(weapon == parabolicWeapon)
        {
            currentWeaponScriptableObject = parabolicScriptableObject;
        }
        else if (weapon == magneticWeapon)
        {
            currentWeaponScriptableObject = forceFieldScriptableObject;
        }else if( weapon == boomerangWeapon)
        {
            currentWeaponScriptableObject = weaponBoomerangScriptableObject;
        }*/

        weaponChangeEvent.Invoke(currentWeapon);
    }
}

public enum Weapon
{
    BareHand,
    MagneticWeapon, 
    ParabolicWeapon,
    Boomerang,
    HolyWater
}
