using UnityEngine;

namespace Player
{
    public class Aimer : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private Camera _mainCamera;

        private float _rayMaxDistance = 1000;

        public RaycastHit Aim(Vector2 screenPointPosition)
        {
            Ray ray = _mainCamera.ScreenPointToRay(screenPointPosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, _rayMaxDistance, _layerMask))
                _target.position = hitInfo.point;

            return hitInfo;
        }
    }
}