using UnityEngine;

// class for enemy that opens the finish portal after its death
public class ExitOrangeSlime : OrangeSlime
{
    [Header("Exit")]
    [SerializeField] private GameObject finish;
    private void Start()
    {
        finish.SetActive(false);
    }
    public override void Death()
    {
        base.Death();
        finish.SetActive(true);
    }
}
