using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Survior : MonoBehaviour, IDamageable
{
    [SerializeField] private Mover _mover;
    [SerializeField] private Transform _destinationPoint;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Health _health;
    [SerializeField] private SurviorAnimationHandler _surviorAnimationHandler;

    private Transform _transform;

    private bool _isALive = true;

    private void OnEnable()
    {
        _health.Died += Die;
    }

    private void OnDisable()
    {
        _health.Died -= Die;
    }

    private void Awake()
    {
        _transform = transform;
    }

    private void FixedUpdate()
    {
        if (_isALive)
            _mover.MoveTo(_destinationPoint, _transform, _rigidbody);
    }

    public void TakeDamage(float damage)
    {
        _health.TakeDamage(damage);
    }

    public void Die()
    {
        _isALive = false;
        _mover.StopMoving(_rigidbody);
        _surviorAnimationHandler.PlayeDeathAnimation();
    }
}
