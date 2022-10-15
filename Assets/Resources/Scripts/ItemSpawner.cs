using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SortCubes
{
    public class ItemSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private int _count;
        [SerializeField] private Vector3 _range;

        public void Start()
        {
            for (int i=0;i<_count;i++)
            {
                Vector3 offset = new Vector3
                (Random.Range(-_range.x,_range.x),Random.Range(-_range.y,_range.y),Random.Range(-_range.z,_range.z));
                var obj = Instantiate(_prefab,transform.position+offset,Quaternion.identity);
                obj.transform.parent=transform;
            } 
        }
    }
}
