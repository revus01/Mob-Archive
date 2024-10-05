using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace MobArchive
{
    public class StudentComponent : MonoBehaviour, ICombatable
    {
        [SerializeField] private EnemyDetectionHandler _viewRangeDetector;
        [SerializeField] private EnemyDetectionHandler _attackRangeDetector;
        [SerializeField] private NavMeshAgent _navMeshAgent;


        private StudentState _currentState;
        private int _attackDamage = 10;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Camera.main != null)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                    if (Physics.Raycast(ray, out RaycastHit hit))
                    {
                        _navMeshAgent.SetDestination(hit.point);
                    }
                }
            }
        }

        public void Initialize()
        {
            _viewRangeDetector.Initialize();
            _attackRangeDetector.Initialize();
            _currentState = new Idle();
        }
        
        public void OnTimeElapsed(float deltaTime)
        {
            OnUpdateState();
        }

        private void ChangeState(StudentState previousState, StudentState newState, bool isForce)
        {
            
        }

        private void OnEnterState(StudentState state)
        {
            
        }

        private void OnExitState(StudentState state)
        {
            
        }

        private void OnUpdateState()
        {
            if (_currentState is Idle || _currentState is Move)
            {
                return;
            }

            return;
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