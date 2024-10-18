using UnityEngine;

namespace MobArchive
{
    public class EnemyComponent : MonoBehaviour, IDamageble
    {

        private int _enemyHp = 100;
        private bool _isDead;

        public void Initialize()
        {
            _enemyHp = 100;
            _isDead = false;
        }

        public void ApplyDamage(DamageInfo damageInfo)
        {
            if (_isDead)
            {
                return;
            }
            
            var deltaHp = damageInfo.Value;
            UpdateEnemyHp(deltaHp);
        }

        private void UpdateEnemyHp(int deltaHp)
        {
            _enemyHp -= deltaHp;
            if (_enemyHp < 0)
            {
                OnEnemyDead();
            }
        }

        private void OnEnemyDead()
        {
            _isDead = true;
            Debug.Log("Dead");
            Destroy(gameObject);
        }

        public bool IsDead()
        {
            return _isDead;
        }
        
        
        
        
        
    }
}