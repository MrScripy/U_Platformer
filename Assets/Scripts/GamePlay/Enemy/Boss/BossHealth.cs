

public class BossHealth : CharHealth
{
    private bool isInvulnerable = false;
    public bool IsInvulnerable
    {
        get => isInvulnerable;
        set => isInvulnerable = value;
    }
    public override float Health 
    { 
        get => base.Health;
        set
        {
            if (IsInvulnerable)
                return;
            base.Health = value;
            Check();
        }
    }

    private void Check()
    {
        if (Health == (character.Config.Health / 2))
            character.CharacterAnimator.SetBool("IsEnraged", true);
    }
}
