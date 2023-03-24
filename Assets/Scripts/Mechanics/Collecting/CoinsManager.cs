using UnityEngine;
using TMPro;
using System.Collections.Generic;
using DG.Tweening;

public class CoinsManager : MonoBehaviour
{
    [SerializeField] private TMP_Text coinUIText;
    [SerializeField] private Transform target;
    [SerializeField] private GameObject animatedCoinPref;
    [SerializeField] private int maxCoins;
    Queue<GameObject> coinsQueue = new Queue<GameObject>();

    [Header("Animation settings")]
    [SerializeField] [Range(0.5f, 0.9f)] private float minAnimDuration;
    [SerializeField] [Range(0.9f, 2f)] private float maxAnimDuration;
    [SerializeField] private float spread;
    [SerializeField] Ease easeType;

    private int coins;
    private Vector3 targetPosition;

    public int Coins
    {
        get => coins;
        set
        {
            if (value > 0)
            {
                coins = value;
                coinUIText.text = Coins.ToString();
            }
        }
    }

    private void Awake()
    {
        targetPosition = target.position;
        PrepareCoins();
    }

    private void PrepareCoins()
    {
        GameObject coin;
        for (int i = 0; i < maxCoins; i++)
        {
            coin = Instantiate(animatedCoinPref);
            coin.transform.parent = transform;
            coin.SetActive(false);
            coinsQueue.Enqueue(coin);
        }

    }

    private void Animate(Vector3 CollectedCoinPosition, CollectedItemsEnum item)
    {
        for (int i = 0; i < (int)item; i++)
        {
            if (coinsQueue.Count > 0)
            {
                GameObject coin = coinsQueue.Dequeue();
                coin.SetActive(true);

                coin.transform.position = CollectedCoinPosition + new Vector3 (Random.Range(-spread, spread), 0, 0);

                float duration = Random.Range(minAnimDuration, maxAnimDuration);
                coin.transform.DOMove(targetPosition, duration)
                    .SetEase(easeType)
                    .OnComplete (() =>
                    {
                        coin.SetActive(false);
                        coinsQueue.Enqueue(coin);

                        Coins++;
                    });
            }
        }       
    }

    public void AddCoin(Vector3 CollectedCoinPosition, CollectedItemsEnum item)
    {
        Animate(CollectedCoinPosition, item);
    }
}
