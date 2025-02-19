using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.Enemy
{
    public class EnemyPool
    {
        private EnemyView _enemyView;
        private EnemyData _enemyData;
        private List<PooledEnemy> _pooledEnemyList;

        public EnemyPool(EnemyView enemyView, EnemyData enemyData)
        {
            this._enemyView = enemyView;
            this._enemyData = enemyData;
            _pooledEnemyList = new List<PooledEnemy>();
        }

        public EnemyController GetEnemy()
        {
            if (_pooledEnemyList.Count > 0)
            {
                PooledEnemy pooledEnemy = _pooledEnemyList.Find(item => !item.isUsed);
                if (pooledEnemy != null)
                {
                    pooledEnemy.isUsed = true;
                    return pooledEnemy.Enemy;
                }

            }
            return CreateNewPooledEnemy();

        }

        private EnemyController CreateNewPooledEnemy()
        {
            PooledEnemy pooledEnemy = new PooledEnemy();
            pooledEnemy.Enemy = new EnemyController(_enemyView, _enemyData);
            pooledEnemy.isUsed = true;
            _pooledEnemyList.Add(pooledEnemy);

            return pooledEnemy.Enemy;
        }

        public void ReturnEnemyToPool(EnemyController returnedEnemy)
        {
            PooledEnemy pooledEnemy = _pooledEnemyList.Find(item => item.Enemy.Equals(returnedEnemy));
            pooledEnemy.isUsed = false;
        }

        public class PooledEnemy
        {
            public EnemyController Enemy;
            public bool isUsed;
        }
    }
}