using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] private CharConfig charConfig;
    public CharConfig Config => charConfig;
}
