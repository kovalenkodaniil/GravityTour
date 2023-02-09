using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private float _maxLifeTime;

    private float _lifeTime;

    private void OnEnable()
    {
        _lifeTime = _maxLifeTime;

        StartCoroutine(CountLifeTime());
    }

    IEnumerator CountLifeTime()
    {
        while (_lifeTime > 0)
        {
            _lifeTime -= Time.deltaTime;

            yield return null;
        }

        gameObject.SetActive(false);
    }
}
