
public class PumpkinItem : Item
{
    private CollectedItemsEnum item = CollectedItemsEnum.Pumpkin;
    public override CollectedItemsEnum ItemType { get => item; }
}
