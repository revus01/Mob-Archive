using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.Serialization;

namespace MobArchive
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField, CanBeNull] private MobGameHUD _mobGameHUD;
        [SerializeField, CanBeNull] private StudentHandler _studentHandler;
        [SerializeField, CanBeNull] private EnemyHandler _enemyHandler;
        [SerializeField] private NavMeshSurface _navMeshSurface;
        
        private List<StudentComponent> _studentComponents = new List<StudentComponent>();
        private SkillManager SkillManager => SkillManager.Instance;
        private FXManager FXManager => FXManager.Instance;
        
        public void SetUp()
        {
        }

        private void Awake()
        {
            _studentComponents = FindObjectsOfType<StudentComponent>().ToList();
            _studentComponents.ForEach(_ => _.Initialize());
            
            _navMeshSurface.BuildNavMesh();
        }

        void Update()
        {
            OnTimeElapsed(Time.deltaTime);
        }
        
        void OnTimeElapsed(float timeElapsed)
        {
            _studentComponents?.ForEach(_ => _.OnTimeElapsed(timeElapsed));
        }
    }
}
