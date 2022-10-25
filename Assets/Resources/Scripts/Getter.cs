using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SortCubes
{
    public class Getter : MonoBehaviour
    {
        [SerializeField] public ItemType _type;
        [SerializeField] private float _reboundForceToRight = 100f;
        private int _targetCount = 1;
        private ItemDrag _item;
        private int _currentCount;

        public UnityEvent<Getter> OnCountChanged;

        public void SetCount(int value)
        {
            _targetCount = value;
        }
        
        private void OnTriggerEnter(Collider other) 
        {
            var item = other.attachedRigidbody.GetComponent<ItemDrag>();
            if (item==null) return;
            if (item.IsDraggable)
                _item=item;  
        }

        private void OnTriggerStay(Collider other) 
        {
            var item = other.attachedRigidbody.GetComponent<ItemDrag>();
            if (item!=null && item.IsDraggable==true)
            {
                _item = item;
                return;
            }
            if (item.IsDraggable == false && _item==item)
            {
                TryGetItem();
                _item=null;
                return;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            var item = other.attachedRigidbody.GetComponent<ItemDrag>();
            if (item==null) return;
            if (_item == item)
            {
                if (item.IsDraggable == false)
                    TryGetItem();
                _item=null;
            }
        }

        private void TryGetItem()
        {
            if (_item.Type==_type)
            {
                Destroy(_item.gameObject);
                _currentCount++;
                OnCountChanged.Invoke(this);
            }
            else
            {
                _item.IsDraggable=false;
                _item.GetComponent<Rigidbody>().AddForce(Vector3.right*_reboundForceToRight);
            }
        } 
    }
}
