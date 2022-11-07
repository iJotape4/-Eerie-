using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmsAnimationEvents : MonoBehaviour
{
    [SerializeField] private Rigidbody _waterRB;
    [SerializeField] private Transform _bottleCap;
    [SerializeField] private GameObject _smartWatch;
    [SerializeField] private GameObject _player;

    [SerializeField] private float shotForce = 2000f;

    private void Awake()=>
     _player = GameObject.FindGameObjectWithTag("Player");     


    public void EnableBibleCollider()
    {

    }
    public void DisableBibleCollider()
    {

    }

    public void LaunchWater()
    {      
        _waterRB = Resources.Load<GameObject>("WaterJet").GetComponent<Rigidbody>();
        if(_waterRB==null)
            return;

        Rigidbody _waterInstance;
        _waterInstance = Instantiate(_waterRB, _bottleCap.position, _bottleCap.rotation) as Rigidbody;
        _waterInstance.AddForce(_bottleCap.forward * shotForce);
    }

    public void SmartWatch()
    {

    }
}
