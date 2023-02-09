using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShipRewardViewer : MonoBehaviour
{
    const float TextLifeTime = 0.8f;

    [SerializeField] private GameObject _rewardScreen;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Planet _planet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ShowReward();

        Player.MoneyChangeCalled?.Invoke(_planet.Reward);
    }

    private void ShowReward()
    {
        _rewardScreen.SetActive(true);

        _text.text = $"+{_planet.Reward}";

        StartCoroutine(CountTextLifeTime());
    }

    IEnumerator CountTextLifeTime()
    {
        float currentLifeTime = TextLifeTime;

        while (currentLifeTime > 0)
        {
            currentLifeTime -= Time.deltaTime;

            yield return null;
        }

        _rewardScreen.SetActive(false);
    }
}
