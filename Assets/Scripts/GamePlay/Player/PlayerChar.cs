using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerChar : Character
{
    [SerializeField] private PlayerMovement move;
    [SerializeField] private GamePlayUIManager gameUI;

    //[SerializeField] private GameObject deadPanel;

    private void Start()
    {
        //deadPanel.SetActive(false);
    }
    void Update()
    {
        move.PlayerMove();
    }
    public override void Death()
    {
        gameUI.PlayerDie();
    }

}
