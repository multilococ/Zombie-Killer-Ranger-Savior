using UnityEngine;

namespace Player
{
    public class WeaponRotator : MonoBehaviour
    {
        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        public void Rotate(Vector3 point)
        {
            _transform.forward = point - _transform.position;
        }
    }
}