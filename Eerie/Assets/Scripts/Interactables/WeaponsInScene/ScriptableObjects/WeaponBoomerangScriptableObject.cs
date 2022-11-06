using UnityEngine;

namespace WeaponsScripts
{
    [CreateAssetMenu(fileName = "Weapon Boomerang", menuName = "ScriptableObjects/Weapons/boomerang", order = 1)]
    public class WeaponBoomerangScriptableObject : WeaponScriptableObject
    {
        [Header("Item Specfic Stats")]
        [SerializeField] float shotForce;
        [SerializeField] float range;
    }
}
