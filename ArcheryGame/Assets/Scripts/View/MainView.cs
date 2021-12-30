using System;
using Controller;
using Model;
using TableConfig;
using UnityEngine;
using Random = UnityEngine.Random;

namespace View
{
    public class MainView : MonoBehaviour
    {
        [SerializeField] public GameObject prebEnemy;
        
        [SerializeField] public GameObject myPlayer;

        public void Start()
        {
            Action<BuffModel[]> buf = ReadJson;
            try
            {
                TableParser<BuffModel>.Parse("ArmyModel", buf);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void ReadJson(BuffModel[] buf)
        {
            CreateRole(buf[0]);
        }

        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="buf"></param>
        private void CreateRole(BuffModel buf)
        {
            var player = Instantiate(this.myPlayer, this.transform, false);
            player.transform.localPosition = new Vector3(-16, 1.16f, -43);
            MyPlayer.Singleton.GetPlayerData(buf);

            var enemy = Instantiate(prebEnemy, this.transform, false);
            var x = Random.Range(-20f, -12f);
            var z = Random.Range(-40f, -35f);
            enemy.transform.position = new Vector3(x, 1.6f, z);
        }
    }
}