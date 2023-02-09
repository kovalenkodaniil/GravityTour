using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class PlanetSpawner : MonoBehaviour
{
    [SerializeField] private Planet _planet;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private int _planetCost;

    private Button _buyButton;

    public int PlanetCost => _planetCost;

    private void OnEnable()
    {
        _buyButton = GetComponent<Button>();

        _buyButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _buyButton.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        Instantiate(_planet, _startPosition.position, Quaternion.identity);

        Player.MoneyChangeCalled?.Invoke(-_planetCost);
    }
}
