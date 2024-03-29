using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] private CharConfig charConfig;
    #region Animation
    [Header("Animation")]
    [SerializeField] private Animator animator;
    public Animator CharacterAnimator => animator;
    #endregion
    public CharConfig Config => charConfig;
    public abstract void Death();

}
