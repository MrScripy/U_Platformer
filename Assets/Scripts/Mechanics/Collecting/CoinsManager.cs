using UnityEngine;
using TMPro;
using DG.Tweening;

public class CoinsManager : MonoBehaviour
{
    [SerializeField] private TMP_Text coinUIText;
    [SerializeField] private Transform target;
    [SerializeField] private GameObject animatedCoinPref;
    [SerializeField] private int maxCoins;

    [Header("Animation settings")]
    [SerializeField] [Range(0.5f, 0.9f)] private float minAnimDuration;
    [SerializeField] [Range(0.9f, 2f)] private float maxAnimDuration;
    [SerializeField] private float spread;
    [SerializeField] Ease easeType;

    private int coins;
    private Vector3 targetPosition;

    private void Awake()
    {
        targetPosition = target.position;
    }

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



    private void Animate(Vector3 CollectedCoinPosition, CollectedItemsEnum item)
    {
        for (int i = 0; i < (int)item; i++)
        {
            GameObject coin = Instantiate(animatedCoinPref, transform);

            coin.transform.position = CollectedCoinPosition + new Vector3(Random.Range(-spread, spread), 0, 0);

            float duration = Random.Range(minAnimDuration, maxAnimDuration);
            coin.transform.DOMove(targetPosition, duration)
                .SetEase(easeType)
                .OnComplete(() =>
               {
                   coin.SetActive(false);
                   Coins++;
               });
        }
    }

    public void AddCoin(Vector3 CollectedCoinPosition, CollectedItemsEnum item)
    {
        Animate(CollectedCoinPosition, item);
    }
}
