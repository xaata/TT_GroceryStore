using UnityEngine;

namespace Game.Action
{
    public class PickUpItemAction : ActionBase
    {
        [SerializeField] private PickUpableItem _pickUpableItem;
        public override void PerformAction(GameObject source)
        {
            _pickUpableItem.PickUp(source);
        }
    }
}