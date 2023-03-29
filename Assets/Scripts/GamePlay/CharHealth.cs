using System;
using UnityEngine;
using UnityEngine.UI;

public class CharHealth : MonoBehaviour
{
    [SerializeField] protected Character character;    
    [SerializeField] private Slider slider;
    [SerializeField] private Gradient gradient;
    [SerializeField] private Image fill;

    public float MaxHealth { get; private set; }

    protected float _health;

    public event Action<float> OnHealthChanged;

    public virtual float Health
    {
        get => _health;
        set
        {
            _health = Mathf.Clamp(value, 0, MaxHealth);
            OnHealthChanged?.Invoke(_health);
            if (_health == 0)
                Die();
        }
    }

    protected void Awake()
    {
        Initialize();
    }

    protected void Initialize()
    {
        MaxHealth = character.Config.Health;
        _health = MaxHealth;
        slider.maxValue = MaxHealth;
        fill.color = gradient.Evaluate(1f);
        OnHealthChanged += SetHealthBar;
    }

    public void SetHealthBar(float health)
    {        
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    protected void Die()
    {
        // Die animation;
        character.CharacterAnimator.SetBool("IsDead", true);
        // Disable char
        character.Death();        
    }
    
}
