using Controller;
using Entity;
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
            var player = Instantiate(prefMyPlayer, this.transform, false);
            player.transform.localPosition = new Vector3(-16, 1.16f, -43);
            PlayerController.Singleton.InitPlayerData(buf);

            var enemy = Instantiate(prebEnemy, this.transform, false);
            var x = Random.Range(-20f, -12f);
            var z = Random.Range(-40f, -35f);
            enemy.transform.position = new Vector3(x, 1.6f, z);
        }
    }
}