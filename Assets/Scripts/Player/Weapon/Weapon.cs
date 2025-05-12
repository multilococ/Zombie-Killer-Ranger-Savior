using UnityEngine;

namespace Player
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Transform _shootingPosition;
        [SerializeField] private LayerMask _layerMask;

        public void Shooting() 
        {
            Ray ray = new Ray(_shootingPosition.position, _shootingPosition.forward);

            if (Physics.Raycast(ray, out RaycastHit hitInfo,Mathf.Infinity, _layerMask, QueryTriggerInteraction.Ignore))
            {
                if (hitInfo.collider.TryGetComponent<Enemy>(out Enemy enemy))
                {
                    Debug.Log("Shoot on " + enemy.name);
                }
            }
        }
    }
}