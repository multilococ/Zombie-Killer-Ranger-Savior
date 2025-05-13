using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private Transform _target;

    private Transform _tramsform;

    private void Awake()
    {
        _tramsform = transform;
    }

    private void FixedUpdate()
    {
        _mover.MoveTo(_target,_tramsform);
    }
}
