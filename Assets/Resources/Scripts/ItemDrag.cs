using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
namespace SortCubes
{
    public class ItemDrag : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        private Rigidbody _rigidbody;
        public bool IsDraggable { get; set;}
        [SerializeField] ItemType _type;
        public ItemType Type { get =>_type;}

        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _rigidbody.isKinematic = true;
            IsDraggable = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (IsDraggable==false) return;
                _rigidbody.isKinematic = false;
            IsDraggable = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (IsDraggable==false) return;
            if (!eventData.pointerCurrentRaycast.isValid)
            {
                _rigidbody.isKinematic = false;
                IsDraggable = false;
            }
            var position = eventData.pointerCurrentRaycast.worldPosition;
            var delta = position - transform.position;
            delta.z = 0;
            transform.position+=delta;
            if (transform.position.y<0.5) 
                transform.position=new Vector3(transform.position.x,0.5f,transform.position.z);
            // if (transform.position.x<-2) 
            //     transform.position=new Vector3(-2,transform.position.y,transform.position.z);
            // if (transform.position.x>2) 
            //     transform.position=new Vector3(2,transform.position.y,transform.position.z);
        }
    }
}

