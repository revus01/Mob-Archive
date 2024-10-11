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
            _studentComponent.Animator.SetBool("move", false);
        }


        public void EnterState()
        {
            Debug.Log("Entering Idle");
        }

        
        public void UpdateState()
        {
            Debug.Log("Updating Idle");
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
            if (!_studentComponent.NavMeshAgent.pathPending &&
            _studentComponent.NavMeshAgent.remainingDistance <= _studentComponent.NavMeshAgent.stoppingDistance + 0.5f)
            {
                _studentComponent.ChangeState(new Idle(_studentComponent));
            }

        }

        public void ExitState()
        {
            Debug.Log("Exiting Move");
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