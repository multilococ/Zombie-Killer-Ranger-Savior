using UnityEngine;

namespace Player
{
    public class Weapon : MonoBehaviour
    {
        private RaycastHit _hit;

        public void SetRaycastHit(RaycastHit hitInfo)
        {
            _hit = hitInfo;
        }

        public void Shoot()
        {
            Debug.Log("Shoot");

            if (_hit.collider.TryGetComponent<Enemy>(out Enemy enemy))
                Debug.Log("This was enemy " + enemy.name);
        }
    }
}