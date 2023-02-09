using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyViwer : MonoBehaviour
{
    [SerializeField] private TMP_Text _textCount;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _textCount.text = _player.Money.ToString();

        Player.MoneyChanged += OnMoneyChanged;
    }

    private void OnDisable()
    {
        Player.MoneyChanged -= OnMoneyChanged;
    }

    private void OnMoneyChanged()
    {
        _textCount.text = _player.Money.ToString();
    }
}
