using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private int _health;

    private int _currentHealth;

    public int Health => _health;

    public event UnityAction<int, int> HealthChanged;

    private void Start()
    {
        _currentHealth = _health;
    }

    public void ApplyDamage(int value)
    {
        if (_currentHealth + value >= 0 && _currentHealth + value <= _health)
        {
            _currentHealth += value;
            HealthChanged?.Invoke(_currentHealth, _health);

            SetAnimation(value);
        }
    }

    private void SetAnimation(int value)
    {
        if (value > 0)
            _animator.SetTrigger("Heal");
        else if (value < 0)
            _animator.SetTrigger("Hurt");
    }
}
