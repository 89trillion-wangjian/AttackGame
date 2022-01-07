using Controller;
using Entity;
using Model;
using UnityEngine;
using Random = UnityEngine.Random;

namespace View
{
    public class ArcheryView : MonoBehaviour
    {
        [SerializeField] public GameObject prebEnemy;

        [SerializeField] public GameObject prefMyPlayer;


        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="buf"></param>
        public void CreateRole(BuffModel buf)
        {
            for (int i = 0; i < 3; i++)
            {
                var nodeEnemy = Instantiate(prebEnemy, this.transform, false);
                var x = Random.Range(-20f, -12f);
                var z = Random.Range(-40f, -35f);
                nodeEnemy.transform.position = new Vector3(x, 1.6f, z);
                Enemy enemy = new Enemy(i, i + 1000);
                EnemyController.Singleton.InitData(enemy);
                ArcheryModel.CreateInstance().AddEnemy(enemy, nodeEnemy);
            }

            var player = Instantiate(prefMyPlayer, this.transform, false);
            player.transform.localPosition = new Vector3(-16, 1.16f, -43);
            PlayerController.Singleton.InitPlayerData(buf);
        }
    }
}