using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace MobArchive
{
    public class StudentComponent : MonoBehaviour, ICombatable
    {
        [FormerlySerializedAs("_viewRangeHandler")] [SerializeField] private StudentViewHandler _viewHandler;

        private int _attackDamage = 10;

        
        
        public void Initialize()
        {
            _viewHandler.Initialize();
        }
        
        public void OnTimeElapsed(float deltaTime)
        {
        }

        public void NormalAttack()
        {
            Debug.Log(_attackDamage);
            throw new System.NotImplementedException();
        }

        public void UseSkill()
        {
            throw new System.NotImplementedException();
        }

        public void Reload()
        {
            throw new System.NotImplementedException();
        }

        public void Die()
        {
            throw new System.NotImplementedException();
        }

        
    }
}