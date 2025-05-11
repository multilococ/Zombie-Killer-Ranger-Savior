using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private InputReader _inputReader;
        [SerializeField] private Aimer _aimer;
        [SerializeField] private Weapon _weapon;
        [SerializeField] private WeaponRotator _weaponRotator;

        private void OnEnable()
        {
            _inputReader.OnShootPressed += _weapon.Shoot;
        }

        private void OnDisable()
        {
            _inputReader.OnShootPressed -= _weapon.Shoot;
        }

        private void Update()
        {
            RaycastHit hit = _aimer.Aim(_inputReader.ScreenPointPosition);
          
            _weapon.SetRaycastHit(hit);
            _weaponRotator.Rotate(hit.point);
        }
    }
}
