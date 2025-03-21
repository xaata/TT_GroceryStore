using UnityEngine;
using DG.Tweening;

public class Door : MonoBehaviour
{
    [SerializeField] private float _doorOpenRotation;
    [SerializeField] private bool _isOpen = false;
    [SerializeField] private float _duration = 1f;

    public bool IsOpen { get { return _isOpen; } }

    public void Open()
    {
        transform.DOLocalRotate(new Vector3(0, _doorOpenRotation, 0), _duration)
                     .SetEase(Ease.OutSine);
        _isOpen = true;
    }
    public void Close()
    {
        transform.DOLocalRotate(new Vector3(0, 0, 0), _duration)
                     .SetEase(Ease.OutSine);
        _isOpen = false;
    }
    public void Toggle()
    {
        if (_isOpen)
        {
            Close();
        }
        else
        {
            Open();
        }
    }
}
