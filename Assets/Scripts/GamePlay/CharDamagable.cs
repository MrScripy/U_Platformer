using System;
using UnityEngine;

public class CharDamagable : MonoBehaviour
{
    [SerializeField] private Character character;
    [SerializeField] private CharHealth charHealth;


    public void ApplyDamage(float damage)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException(nameof(damage));
        var totalDamage = ProcessDamage(damage);
        if (totalDamage < 0)
            throw new ArgumentOutOfRangeException(nameof(totalDamage));
        charHealth.Health -= totalDamage;
        character.CharacterAnimator.SetTrigger("Damaged");
    }

    protected virtual float ProcessDamage(float damage) => damage;

}
