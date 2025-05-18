using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Zombie : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private Survior _survior;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Health _health;
    [SerializeField] private ZombieHand _zombieHand;
    [SerializeField] private ZombieAnimatorHandler _animatorHandler;

    private Transform _tramsform;

    private bool _isALive;

    private void OnEnable()
    {
        _health.Died += Die;
        _mover.EnoughClosed += Attack;
    }

    private void OnDisable()
    {
        _health.Died -= Die;
        _mover.EnoughClosed -= Attack;
    }

    private void Awake()
    {
        _tramsform = transform;
        _isALive = true;
    }

    private void FixedUpdate()
    {
        if (_isALive)
        {
            _mover.MoveTo(_survior.transform, _tramsform, _rigidbody);
        }
    }

    private void Attack() 
    {
        _zombieHand.Attack(_survior);
        _animatorHandler.PlayAttackAnimation();
    }

    private void Die()
    {
        _isALive = false;
        _mover.StopMoving(_rigidbody);
        _animatorHandler.PlayDeathAnimation();
    }
}
