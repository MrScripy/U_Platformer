using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject finishPortal;
    private void Start()
    {
        finishPortal.SetActive(false);
        boss.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            boss.SetActive(true);
    }
}
