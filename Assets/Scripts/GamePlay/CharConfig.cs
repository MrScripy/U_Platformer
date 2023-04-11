using UnityEngine;

[CreateAssetMenu(fileName = "CharacterConfig", menuName = "Custom/Character/Config", order = 0)]
public class CharConfig : ScriptableObject
{
    [Header("[Name]"), Space]
    [SerializeField] private string charName;
    [Header("[Common]"), Space]
    [SerializeField, Min(0)] private float health;
    [SerializeField, Min(0)] private float damage;

    public string Name => charName;
    public float Health => health;
    public float Damage => damage;
}
