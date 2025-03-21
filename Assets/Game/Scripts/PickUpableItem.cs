using UnityEngine;
using UnityEngine.UI;

public class PickUpableItem : MonoBehaviour
{   
    [SerializeField] private Button _button;

    private Transform _itemHolderPoint;
    public void PickUp(GameObject parent)
    {
        var curItem = parent.GetComponent<PlayerHandSlot>().CurrentItem;
        if ( curItem == null)
        {
            parent.GetComponent<PlayerHandSlot>().CurrentItem = this;
            _button.gameObject.SetActive(true);
            transform.SetParent(parent.transform);
            SetItemPoint(parent);
            TurnOffItemPhysics();
        }
    }
    private void SetItemPoint(GameObject parent)
    {
        _itemHolderPoint = parent.transform.Find("ItemHolderPoint");
        transform.localPosition = _itemHolderPoint.localPosition;
    }
    private void TurnOffItemPhysics()
    {
        transform.GetComponent<Rigidbody>().isKinematic = true;
        transform.GetComponent<Collider>().enabled = false;
    }
    
}
