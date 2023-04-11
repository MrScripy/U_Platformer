using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField] private GamePlayUIManager gamePlayManager;
    [SerializeField] private CoinsManager coinsManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gamePlayManager.PlayerWin(coinsManager.Coins);
    }
}
