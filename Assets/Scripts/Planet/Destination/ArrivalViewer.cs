using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Destination))]

public class ArrivalViewer : MonoBehaviour
{
    const float EffectTime = 0.7f;

    [SerializeField] private ParticleSystem _parcticle;
    [SerializeField] private TMP_Text _countText;
    [SerializeField] private GameObject _countScreen;

    private Destination _planet;
    private int _planetLimit;

    private void Awake()
    {
        _planet= GetComponent<Destination>();
        _planetLimit = _planet.TouristLimit;

        ShowCount(_planetLimit);
    }

    private void OnEnable()
    {
        _planet.TourisArrived += OnTouristArrived;
    }

    private void OnDisable()
    {
        _planet.TourisArrived += OnTouristArrived;
    }

    private void OnTouristArrived()
    {
        int currentCount = _planet.CurrentTouristCount;

        if (_planetLimit <= currentCount)
        {
            _parcticle.gameObject.SetActive(false);
            _countScreen.SetActive(false);
            enabled = false;
            return;
        }

        _parcticle.Play();

        StartCoroutine(ParticleTimer());

        ShowCount(_planetLimit - currentCount);
    }

    private void ShowCount(int value)
    {
        _countText.text = value.ToString();
    }

    IEnumerator ParticleTimer()
    {
        float particleLifeTime = EffectTime;

        while (particleLifeTime > 0)
        {
            particleLifeTime -= Time.deltaTime;
            yield return null;
        }

        _parcticle.Stop();
    }
}
