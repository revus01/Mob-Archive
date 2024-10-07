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
        [SerializeField] private Animator _animator;


        private class StudentStat
        {
            // 기본적인 스탯만 적용
            public readonly int MaxHp;
            public int CurrentHp;
            public int AttackPower;
            public int DefencePower;
            public int HealPower;

            public int AmmoCapacity;
            public int AmmoCount;
            
            public StudentStat(int maxHp, int attackPower, int defencePower, int healPower)
            {
                MaxHp = maxHp;
                CurrentHp = maxHp;
                AttackPower = attackPower;
                DefencePower = defencePower;
                HealPower = healPower;
                AmmoCapacity = 5;
                AmmoCount = 5;
            }
        }
        
        public StudentAnimPlayer StudentAnimPlayer;
        private int _attackDamage = 10;
        private StudentStat _studentStat;
        private IState _currentState;
        
        public Animator Animator => _animator;
        public NavMeshAgent NavMeshAgent => _navMeshAgent;

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
                        ChangeState(new Move(this));
                    }
                }
            }
        }

        public void Initialize()
        {
            StudentAnimPlayer = new StudentAnimPlayer();
            _viewRangeDetector.Initialize();
            _attackRangeDetector.Initialize();
            _currentState = new Idle(this);
            _studentStat = new StudentStat(100, 20, 10, 10);
        }
        
        public void OnTimeElapsed(float deltaTime)
        {
            _currentState.UpdateState();
        }
        
        private void ChangeHp(int delta)
        {
            _studentStat.CurrentHp = Mathf.Clamp(_studentStat.CurrentHp + delta, 0, _studentStat.MaxHp);

            if (_studentStat.CurrentHp == 0)
            {
                OnStudentDead();
            }
        }

        private void OnStudentDead()
        {
            
        }

        public void ChangeState(IState newState)
        {
            _currentState.ExitState();
            _currentState = newState;
            _currentState.EnterState();
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