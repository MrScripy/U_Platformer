using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
