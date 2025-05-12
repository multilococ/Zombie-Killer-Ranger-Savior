using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private InputReader _inputReader;
        [SerializeField] private Aimer _aimer;
        [SerializeField] private Weapon _weapon;

        private void Update()
        {
            _aimer.Aim(_inputReader.ScreenPointPosition);
            _weapon.Shooting();
        }
    }
}
