public class Hammer : Interactable
{
    public override void Interact()
    {
        GlobalEventManager.TriggerOnPickableItem(ItemType.Hammer);
        Destroy(gameObject);
    }

    protected override void Awake()
    {
        base.Awake();
        ChestTriggerArea.OnChestOpen += HammerMoveOutOfChest;
    }

    private void HammerMoveOutOfChest(bool flag)
    {
        if (flag)
        {
            animator.Play("HammerOutOfChest");
            ChestTriggerArea.OnChestOpen -= HammerMoveOutOfChest;
        }
    }
}