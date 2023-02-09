using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ShipSpawner : MonoBehaviour
{
    [SerializeField] private Mover _shipMover;
    [SerializeField] private int _shipCount;
    [SerializeField] Transform _startPosition;

    [SerializeField] private List<Mover> _ships;

    private void Start()
    {
        for (int i = 0; i < _shipCount; i++)
        {
            _ships.Add(Instantiate(_shipMover, _startPosition));
        }

        StartCoroutine(ShipGenerator());

    }

    IEnumerator ShipGenerator()
    {
        while (_ships.Count > 0) 
        {
            foreach (var ship in _ships)
            {
                if (ship.gameObject.activeSelf == false)
                {
                    ship.gameObject.transform.position = _startPosition.position;
                    ship.gameObject.SetActive(true);
                    ship.Init(_startPosition.position - gameObject.transform.position);
                    break;
                }
            }

            yield return new WaitForSeconds(2f);
        }
    }
}
