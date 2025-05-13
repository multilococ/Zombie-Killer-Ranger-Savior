using UnityEngine;

public class Survior : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private Transform _destinationPoint;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void FixedUpdate()
    {
        _mover.MoveTo(_destinationPoint,_transform);
    }
}
