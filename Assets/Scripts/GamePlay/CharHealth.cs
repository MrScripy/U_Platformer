using System;
using UnityEngine;
using UnityEngine.UI;

public class CharHealth : MonoBehaviour
{
    [SerializeField] private Character character;
    [SerializeField] private Slider slider;
    [SerializeField] private Gradient gradient;
    [SerializeField] private Image fill;

    public float MaxHealth { get; private set; }

    private float _health;

    public event Action<float> OnHealthChanged;

    public float Health
    {
        get => _health;
        set
        {
            _health = Mathf.Clamp(value, 0, MaxHealth);
            OnHealthChanged?.Invoke(_health);
        }
    }

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
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


    
}
