using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.Serialization;

namespace MobArchive
{
    public class GameHandler : MonoBehaviour
    {
        [SerializeField] private MobGameHUD mobGameHUD;
        [SerializeField] private StudentHandler studentHandler;
        [SerializeField] private EnemyHandler enemyHandler;
        
        
        public void SetUp()
        {
        }

        void Update()
        {
            OnTimeElapsed(Time.deltaTime);
        }
        
        void OnTimeElapsed(float timeElapsed)
        {
            
        }
    }
}
