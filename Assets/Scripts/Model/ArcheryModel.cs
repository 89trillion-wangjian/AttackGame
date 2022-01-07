using System.Collections.Generic;
using System.Linq;
using Entity;
using UnityEngine;
using View;

namespace Model
{
    public class ArcheryModel
    {
        public delegate void OnValueChange(int val, Role role);

        public delegate void OnRoleChange();

        public OnValueChange OnRoleHpChange;

        public OnRoleChange OnEnemyDie;

        public Dictionary<Enemy, GameObject> enemyDic = new Dictionary<Enemy, GameObject>();

        //单例
        private static ArcheryModel singleton = null;

        private int enemyHp = 0;

        private int playerHp = 0;

        public static ArcheryModel CreateInstance()
        {
            return singleton ?? (singleton = new ArcheryModel());
        }

        public int EnemyHp
        {
            get { return enemyHp; }
            set
            {
                enemyHp = value;
                OnRoleHpChange?.Invoke(enemyHp, Role.Enemy);
            }
        }

        public int PlayerHp
        {
            get { return playerHp; }
            set
            {
                playerHp = value;
                OnRoleHpChange?.Invoke(playerHp, Role.Player);
            }
        }

        public void AddEnemy(Enemy enemy, GameObject enemyObj)
        {
            this.enemyDic.Add(enemy, enemyObj);
        }

        public void RemoveEnemy(Enemy enemy)
        {
            this.enemyDic.Remove(enemy);
            OnEnemyDie?.Invoke();
        }

        public KeyValuePair<Enemy, GameObject> GetEnemy()
        {
            return this.enemyDic.First();
        }
    }

    public class EnemyInfo
    {
        public Enemy enemy;
        public GameObject obj;
    }
}