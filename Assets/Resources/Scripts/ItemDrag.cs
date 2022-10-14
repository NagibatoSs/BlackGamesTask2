using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ItemDrag : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private Rigidbody _rigidbody;
    private bool _isDraggable=false;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _rigidbody.isKinematic = true;
        _isDraggable = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (_isDraggable==false) return;
        _rigidbody.isKinematic = false;
        _isDraggable = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_isDraggable==false) return;
        if (!eventData.pointerCurrentRaycast.isValid)
        {
            _rigidbody.isKinematic = false;
            _isDraggable = false;
        }
        var position = eventData.pointerCurrentRaycast.worldPosition;
        var delta = position - transform.position;
        delta.z = 0;
        transform.position+=delta;
    }
}
