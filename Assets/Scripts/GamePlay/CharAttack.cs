using System;
using UnityEngine;

public class CharAttack : MonoBehaviour
{
    [SerializeField] private Character character;

    public event Action<float> OnDamageChanged;

    private float _damage;

    public float Damage
    {
        get => _damage;
        set
        {
            _damage = Mathf.Clamp(value, 0, float.MaxValue);
            OnDamageChanged?.Invoke(_damage);
        }
    }

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        Damage = character.Config.Damage;
    }

    public virtual void PerformAttack(CharDamagable damageRecipient)
    {
        damageRecipient.ApplyDamage(Damage);
    }
    public virtual void PerformAttack(CharDamagable damageRecipient, float extraDamage)
    {
        damageRecipient.ApplyDamage(Damage*extraDamage);
    }
}
