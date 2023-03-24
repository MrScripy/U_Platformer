using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleItem : Item
{
    private CollectedItemsEnum item = CollectedItemsEnum.Apple;
    public override CollectedItemsEnum ItemType { get => item; }
}
