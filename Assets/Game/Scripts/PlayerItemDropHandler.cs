using UnityEngine;

public class PlayerItemDropHandler : MonoBehaviour
{
    private PickUpableItem _currentItem;

    public void DropItem() 
    {
        Debug.Log("drop");
        _currentItem = GetComponent<PlayerHandSlot>().CurrentItem;
        if(_currentItem != null) 
        {
            _currentItem.GetComponent<DropableItem>().Drop();
            GetComponent<PlayerHandSlot>().CurrentItem = null;       
        }        
    }
}
