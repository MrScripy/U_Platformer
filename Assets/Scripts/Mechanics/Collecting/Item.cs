using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public abstract CollectedItemsEnum ItemType { get; }
}
