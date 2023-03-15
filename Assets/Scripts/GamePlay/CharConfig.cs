using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterConfig", menuName = "Custom/Character/Config", order = 0)]
public class CharConfig : ScriptableObject
{
    [Header("[Name]"), Space]
    [SerializeField] private string charName;
    [Header("[Common]"), Space]
    [SerializeField, Min(0)] private float health;
    [SerializeField, Min(0)] private float damage;
    //[SerializeField, Min(0)] private float speed;
    //[Header("[Prefab}"), Space]
    //[SerializeField] private Player playerPrefab;

    public string Name => charName;
    public float Health => health;
    public float Damage => damage;
    //public float Speed => speed;
}
