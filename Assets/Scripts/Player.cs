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

            StartCoroutine(Transition(value));
        }
    }

    private IEnumerator Transition(int value)
    {
        _animator.SetInteger("Value", value);

        yield return new WaitForSeconds(.5f);

        _animator.SetInteger("Value", 0);
    }
}
