using UnityEngine;

public class Helicopter : MonoBehaviour
{
    [SerializeField] private Transform _surviorTransform;

    private Transform _transform;
    private Vector3 _offset;

    private void Awake()
    {
        _transform = transform;
        _offset = transform.position;
    }

    private void FixedUpdate()
    {
        _transform.position = _surviorTransform.position + _offset;
    }
}