using UnityEngine;

public class PlayerHandSlot : MonoBehaviour
{
    private PickUpableItem _currentItem;
    public PickUpableItem CurrentItem
    {
        get => _currentItem; set => _currentItem = value;
    }
}
