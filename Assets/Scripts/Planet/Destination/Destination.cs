using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Destination : MonoBehaviour
{
    [SerializeField] private int _touristLimit;

    private int _currentTousristCount;
    private ShipSpawner _shipSpawner;

    public int TouristLimit => _touristLimit;
    public int CurrentTouristCount => _currentTousristCount;

    public event UnityAction TourisArrived;

    private void Awake()
    {
        _shipSpawner= GetComponent<ShipSpawner>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _currentTousristCount++;

        if (_shipSpawner.enabled == false)
            if (_touristLimit <= _currentTousristCount)
                _shipSpawner.enabled = true;

        TourisArrived?.Invoke();
    }

}
