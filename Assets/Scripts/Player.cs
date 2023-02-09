using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public static UnityAction<int> MoneyChangeCalled;
    public static event UnityAction MoneyChanged;

    [SerializeField] private int _money;

    public int Money => _money;

    private void OnEnable()
    {
        MoneyChangeCalled += OnMoneyChanged;
    }

    private void OnDisable()
    {
        MoneyChangeCalled -= OnMoneyChanged;
    }

    private void OnMoneyChanged(int value)
    {
        _money += value;

        if (_money < 0)
            _money= 0;

        MoneyChanged?.Invoke();
    }
}
