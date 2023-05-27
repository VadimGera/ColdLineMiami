using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class ShotInput : MonoBehaviour
    {
        [SerializeField] private WeaponController _currentWeapon;
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _currentWeapon.Shot();
            }
        }
    }
}