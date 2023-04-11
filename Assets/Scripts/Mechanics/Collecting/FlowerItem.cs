
public class FlowerItem : Item
{
    private CollectedItemsEnum item = CollectedItemsEnum.Flower;
    public override CollectedItemsEnum ItemType { get => item; }
}

