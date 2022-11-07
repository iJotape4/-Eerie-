using UnityEngine;

namespace WeaponsScripts
{
    [CreateAssetMenu(fileName = "Weapon Bible", menuName = "ScriptableObjects/Weapons/Bible", order = 1)]
    public class WeaponBibleScriptableObject : WeaponScriptableObject
    {
        [Header("Item Specfic Stats")]
        [SerializeField] float shotForce;
        [SerializeField] float range;
    }
}
