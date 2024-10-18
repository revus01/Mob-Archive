using UnityEngine;

namespace MobArchive
{
    public interface IState
    {
        void EnterState();
        void UpdateState();
        void ExitState();
    }


    public class Idle : IState
    {
        private StudentComponent _studentComponent;

        public Idle(StudentComponent studentComponent)
        {
            _studentComponent = studentComponent;
        }


        public void EnterState()
        {
            Debug.Log("Entering Idle");
        }

        
        public void UpdateState()
        {
            if (_studentComponent.IsEnemyInAttackRange())
            {
                _studentComponent.ChangeState(new AimIdle(_studentComponent, _studentComponent.GetTargetEnemy()));
                return;
            }
            
            if (_studentComponent.IsEnemyInViewRange())
            {
                var moveTarget = _studentComponent.GetMoveTarget();
                if (moveTarget != null)
                {
                    _studentComponent.ChangeState(new Move(_studentComponent));
                    _studentComponent.Move(moveTarget.transform.position);
                }
            }
        }

        public void ExitState()
        {
            Debug.Log("Exiting Idle");
        }
    }
    
    public class Move : IState
    {
        private StudentComponent _studentComponent;

        public Move(StudentComponent studentComponent)
        {
            _studentComponent = studentComponent;
        }


        public void EnterState()
        {
            Debug.Log("Entering Move");
            _studentComponent.Animator.SetBool("move", true);

        }

        
        public void UpdateState()
        {
            if (_studentComponent.IsEnemyInAttackRange())
            {
                _studentComponent.ChangeState(new Idle(_studentComponent));
                return;
            }

            if (_studentComponent.IsArrived())
            {
                _studentComponent.ChangeState(new Idle(_studentComponent));
            }

        }

        public void ExitState()
        {
            _studentComponent.Animator.SetBool("move", false);
            _studentComponent.StopMovement();
        }
    }
    
    public class AimIdle : IState
    {
        private StudentComponent _studentComponent;
        private EnemyComponent _targetEnemy;

        public AimIdle(StudentComponent studentComponent, EnemyComponent targetEnemy)
        {
            _studentComponent = studentComponent;
            _targetEnemy = targetEnemy;
        }


        public void EnterState()
        {
            _studentComponent.Animator.SetBool("aim", true);
            _studentComponent.ChangeDirection(_targetEnemy.transform.position);
        }

        
        public void UpdateState()
        {
            if (_targetEnemy == null)
            {
                if (!_studentComponent.IsEnemyInAttackRange())
                {
                    _studentComponent.ChangeState(new Idle(_studentComponent));
                    return;
                }

                _targetEnemy = _studentComponent.GetTargetEnemy();
            }
            
            _studentComponent.ChangeDirection(_targetEnemy.transform.position);

            if (_studentComponent.CanNormalAttack())
            {
                _studentComponent.NormalAttack(_targetEnemy);
            }
        }

        public void ExitState()
        {
            _studentComponent.Animator.SetBool("aim", false);
        }
    }
    
    public class NormalAttack : IState
    {
        private StudentComponent _studentComponent;
        private float _animationTime;

        public NormalAttack(StudentComponent studentComponent, float animationTime)
        {
            _studentComponent = studentComponent;
            _animationTime = animationTime;
        }


        public void EnterState()
        {
            throw new System.NotImplementedException();
        }

        
        public void UpdateState()
        {
            throw new System.NotImplementedException();
        }

        public void ExitState()
        {
            throw new System.NotImplementedException();
        }
    }
    
    public class Reload : IState
    {
        private StudentComponent _studentComponent;
        private float _animationTime;

        public Reload(StudentComponent studentComponent, float animationTime)
        {
            _studentComponent = studentComponent;
            _animationTime = animationTime;
        }


        public void EnterState()
        {
            throw new System.NotImplementedException();
        }

        
        public void UpdateState()
        {
            throw new System.NotImplementedException();
        }

        public void ExitState()
        {
            throw new System.NotImplementedException();
        }
    }
    
    public class UseSkill : IState
    {
        private StudentComponent _studentComponent;
        private float _animationTime;

        public UseSkill(StudentComponent studentComponent, float animationTime)
        {
            _studentComponent = studentComponent;
            _animationTime = animationTime;
        }


        public void EnterState()
        {
            throw new System.NotImplementedException();
        }

        
        public void UpdateState()
        {
            throw new System.NotImplementedException();
        }

        public void ExitState()
        {
            throw new System.NotImplementedException();
        }
    }
    
    public class Dead : IState
    {
        private StudentComponent _studentComponent;
        private float _animationTime;

        public Dead(StudentComponent studentComponent, float animationTime)
        {
            _studentComponent = studentComponent;
            _animationTime = animationTime;
        }


        public void EnterState()
        {
            throw new System.NotImplementedException();
        }

        
        public void UpdateState()
        {
            throw new System.NotImplementedException();
        }

        public void ExitState()
        {
            throw new System.NotImplementedException();
        }
    }
    
    
}