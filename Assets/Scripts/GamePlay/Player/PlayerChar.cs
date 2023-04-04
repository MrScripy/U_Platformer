using UnityEngine;



public class PlayerChar : Character
{
    [SerializeField] private PlayerMovement move;
    [SerializeField] private GamePlayUIManager gameUI;

    void Update()
    {
        move.PlayerMove();
    }

    public override void Death()
    {
        gameUI.PlayerDie();
    }
}
