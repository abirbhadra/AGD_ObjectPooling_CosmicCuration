using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.Bullets
{
    //1. Create class of a pooledBullet
    //2. Create this pool via PlayerService
    //3. Create constructor of pool
    public class Bulletpool
    {
        private BulletView bulletView;
        private BulletScriptableObject bulletScriptableObject;
        private List<PooledBullet> pooledBullets = new List<PooledBullet>();
        public Bulletpool(BulletView bulletView, BulletScriptableObject bulletScriptableObject)
        {
            this.bulletView = bulletView;
            this.bulletScriptableObject = bulletScriptableObject;
        }
        public class PooledBullet
        {
            public BulletController Bullet;
            public bool isUsed;

        }
    }
}