using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinItem : Item
{
    private CollectedItemsEnum item = CollectedItemsEnum.Pumpkin;
    public override CollectedItemsEnum ItemType { get => item; }
}
