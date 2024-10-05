using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace MobArchive
{
    public class DetectionHandler<T> : MonoBehaviour where T : Component
    {
        [SerializeField] private MeshCollider _detectRange;

        private List<T> _componentsInRange;

        public void Initialize()
        {
            _componentsInRange = new List<T>();
            Debug.Log("초기화 됨");
        }

        private void OnTriggerEnter(Collider other)
        {
            T component = other.GetComponent<T>();
            if (component != null)
            {
                _componentsInRange.Add(component);
                Debug.Log("추가 됨!");
            }
        }

        private void OnTriggerExit(Collider other)
        {
            T component = other.GetComponent<T>();
            if (component != null)
            {
                _componentsInRange.Remove(component);
                Debug.Log("제거 됨!");
            }
        }

        public List<T> GetComponentsInViewRange()
        {
            return _componentsInRange;
        }
    }
}