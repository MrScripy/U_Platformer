using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject finishPortal;
    [SerializeField] private Animator camAnim;

    private static bool isCutsceneOn;
    public static bool IsCutsceneOn
    {
        get => isCutsceneOn;
    }

    private void Start()
    {
        finishPortal.SetActive(false);
        boss.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isCutsceneOn = true;
            camAnim.SetBool("FirstCutscene", true);
            boss.SetActive(true);
            Invoke(nameof(StopCutscene), 3f);
        }
    }

    private void StopCutscene()
    {
        isCutsceneOn = false;
        camAnim.SetBool("FirstCutscene", false);
        this.gameObject.SetActive(false);
    }

}
