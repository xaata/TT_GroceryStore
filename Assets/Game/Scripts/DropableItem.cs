using UnityEngine;
using UnityEngine.UI;

public class DropableItem : MonoBehaviour
{
    [SerializeField] private float _dropForce;
    [SerializeField] private Button _dropButton;

    public void Drop()
    { 
        transform.SetParent(null);
        _dropButton.gameObject.SetActive(false);

        Rigidbody rb = transform.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        transform.GetComponent<Collider>().enabled = true;

        Vector3 direction = Camera.main.transform.forward;
        rb.AddForce(direction * _dropForce, ForceMode.Impulse);
    }
}
