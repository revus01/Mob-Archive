using System;
using System.Collections.Generic;
using System.Linq;
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
        [SerializeField] private Rigidbody _rigidbody;


        private class StudentStat
        {
            // 기본적인 스탯만 적용
            public readonly int MaxHp;
            public int CurrentHp;
            public int AttackPower;
            public int DefencePower;
            public int HealPower;
            public float AttackDelay;

            public int AmmoCapacity;
            public int AmmoCount;
            
            public StudentStat(int maxHp, int attackPower, int defencePower, int healPower, float attackDelay)
            {
                MaxHp = maxHp;
                CurrentHp = maxHp;
                AttackPower = attackPower;
                DefencePower = defencePower;
                HealPower = healPower;
                AmmoCapacity = 5;
                AmmoCount = 5;
                AttackDelay = attackDelay;
            }
        }
        
        public StudentAnimPlayer StudentAnimPlayer;
        private StudentStat _studentStat;
        private IState _currentState;
        private float _remainingAttackDelay;
        
        public Animator Animator => _animator;

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
            _studentStat = new StudentStat(100, 20, 10, 10, 2f);
            _remainingAttackDelay = 0;
        }

        public void StopMovement()
        {
            _navMeshAgent.SetDestination(transform.position);
        }

        public void Move(Vector3 destination)
        {
            _navMeshAgent.SetDestination(destination);
        }
        
        public void OnTimeElapsed(float deltaTime)
        {
            _currentState.UpdateState();
            if (_remainingAttackDelay > 0)
            {
                _remainingAttackDelay = Mathf.Clamp(_remainingAttackDelay - deltaTime, 0, _studentStat.AttackDelay);
            }
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
            newState.EnterState();
            _currentState = newState;
        }

        public void NormalAttack(IDamageble enemy)
        {
            if (enemy.IsDead())
            {
                return;
            }
            enemy.ApplyDamage(new DamageInfo(_studentStat.AttackPower, AttackType.None));
            _remainingAttackDelay = _studentStat.AttackDelay;
        }
        

        public bool IsArrived()
        {
            return !_navMeshAgent.pathPending && _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance + 0.5f;
        }
        
        public bool IsEnemyInViewRange()
        {
            return _viewRangeDetector.GetComponentsInViewRange()
                .Where(_ => !_.IsDead())
                .ToList()
                .Count > 0;
        }
        
        public EnemyComponent GetMoveTarget()
        {
            return _viewRangeDetector.GetComponentsInViewRange()
                .Where(_ => !_.IsDead())
                .ToList().First();
        }

        public bool IsEnemyInAttackRange()
        {
            return _attackRangeDetector.GetComponentsInViewRange()
                .Where(_ => !_.IsDead())
                .ToList()
                .Count > 0;
        }
        
        public EnemyComponent GetTargetEnemy()
        {
            return _attackRangeDetector.GetComponentsInViewRange()
                .Where(_ => !_.IsDead())
                .ToList().First();
        }

        public void ChangeDirection(Vector3 target)
        {
            var targetDirection = target - transform.position;
            targetDirection.y = 0;
            if (targetDirection != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(targetDirection);
            }
        }

        public bool CanNormalAttack()
        {
            return _remainingAttackDelay == 0;
        }
        
        
        

        public void UseSkill(IDamageble enemy)
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