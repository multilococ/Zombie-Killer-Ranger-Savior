using System;
using System.Collections;
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

    public event Action<Zombie> Died;

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

    public void Init(Vector3 position, Survior survior) 
    {
        _tramsform.position = position;
        _survior = survior;
        _isALive = true;
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
        StartCoroutine(DelayDeath());

    }

    private IEnumerator DelayDeath() 
    {
        yield return new WaitForSeconds(3f);

        Died?.Invoke(this);
    }
}
