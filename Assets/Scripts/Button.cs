using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private int _value;

    public void OnButtonClick()
    {
        _player.ApplyDamage(_value);
    }
}
