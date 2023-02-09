using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlanetSpawner))]
[RequireComponent(typeof(Button))]

public class BuyButtonViewer : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _costText;

    private Button _button;
    private PlanetSpawner _planetSpawner;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _planetSpawner= GetComponent<PlanetSpawner>();
    }

    private void OnEnable()
    {
        OnMoneyChanged();

        _costText.text = _planetSpawner.PlanetCost.ToString();

        Player.MoneyChanged += OnMoneyChanged;
    }

    private void OnDisable()
    {
        Player.MoneyChanged -= OnMoneyChanged;
    }

    private void OnMoneyChanged()
    {
        if (_player.Money < _planetSpawner.PlanetCost)
            _button.interactable = false;
    }
}
