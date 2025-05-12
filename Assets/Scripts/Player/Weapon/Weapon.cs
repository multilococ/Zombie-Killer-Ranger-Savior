using UnityEngine;

namespace Player
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Transform _shootingPosition;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float _damage = 10;

        public void Shooting() 
        {
            Ray ray = new Ray(_shootingPosition.position, _shootingPosition.forward);

            if (Physics.Raycast(ray, out RaycastHit hitInfo,Mathf.Infinity, _layerMask, QueryTriggerInteraction.Ignore))
            {
                if (hitInfo.collider.TryGetComponent<IDamageable>(out IDamageable damageable))
                {
                    damageable.TakeDamage(_damage);
                }
            }
        }
    }
}