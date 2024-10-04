using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace MobArchive
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField, CanBeNull] private MobGameHUD _mobGameHUD;
        [SerializeField, CanBeNull] private StudentHandler _studentHandler;
        [SerializeField, CanBeNull] private EnemyHandler _enemyHandler;
        
        private List<StudentComponent> _studentComponents = new List<StudentComponent>();
        
        public void SetUp()
        {
        }

        private void Awake()
        {
            _studentComponents = FindObjectsOfType<StudentComponent>().ToList();
            _studentComponents.ForEach(_ => _.Initialize());
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
