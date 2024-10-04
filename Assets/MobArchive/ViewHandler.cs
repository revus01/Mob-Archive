using System;
using System.Collections.Generic;
using UnityEngine;

namespace MobArchive
{
    public class ViewHandler<T> : MonoBehaviour where T : Component
    {
        [SerializeField] private MeshCollider _viewRange;

        private List<T> _componentsInViewRange;

        public void Initialize()
        {
            _componentsInViewRange = new List<T>();
            Debug.Log("초기화 됨");
        }

        private void OnTriggerEnter(Collider other)
        {
            T component = other.GetComponent<T>();
            if (component != null)
            {
                _componentsInViewRange.Add(component);
                Debug.Log("추가 됨!");
            }
        }

        private void OnTriggerExit(Collider other)
        {
            T component = other.GetComponent<T>();
            if (component != null)
            {
                _componentsInViewRange.Remove(component);
                Debug.Log("제거 됨!");
            }
        }

        public List<T> GetComponentsInViewRange()
        {
            return _componentsInViewRange;
        }
    }
}