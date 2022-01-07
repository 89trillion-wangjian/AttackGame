using System;
using Entity;
using Model;
using UnityEngine;
using Utils;

namespace Controller
{
    public class EnemyController : MonoBehaviour
    {
        public int maxHp = 1000;

        public static EnemyController Singleton;

        private Enemy enemyInfo;

        public void Awake()
        {
            Singleton = this;
        }

        public void InitData(Enemy enemy)
        {
            enemyInfo = enemy;
        }

        public void OnTriggerEnter(Collider other)
        {
            if (!other || !other.CompareTag("arraw"))
            {
                return;
            }

            maxHp -= ArrowController.Singleton.attack;
            maxHp = Math.Max(maxHp, 0);
            ArcheryModel.CreateInstance().EnemyHp = maxHp;
            ObjectPool.CreateInstance().RecycleObj(other.gameObject);
            if (maxHp <= 0)
            {
                ArcheryModel.CreateInstance().RemoveEnemy(enemyInfo);
                Destroy(gameObject);
            }
        }
    }
}