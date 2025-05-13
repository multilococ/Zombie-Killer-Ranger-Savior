using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;

    [SerializeField] private float _minDistanceToTarget = 0.1f;

    public void MoveTo(Transform target, Transform transform) 
    {
        if (transform.position.IsEnoughClose(target.position, _minDistanceToTarget) == false)
        {
            Vector3 direction = target.position - transform.position;

            direction = direction.normalized;
            transform.position += direction * _speed * Time.deltaTime;
            transform.LookAt(target.position);
        }
    }
}
