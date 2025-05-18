using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxValue = 100;

    private float _currentValue;

    public event Action Died;

    private void Awake()
    {
        _currentValue = _maxValue;
    }

    public void TakeDamage(float damage)
    {
        if (_currentValue >= 0)
        {
            _currentValue -= damage;
           

            if (_currentValue < 0)
            {
                _currentValue = 0;
                Died?.Invoke();
            }

            Debug.Log(gameObject.name + " Health : " + _currentValue);
        }
    }
}
