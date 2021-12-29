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
        // Start is called before the first frame update

        public GameObject prebEnemy;
        public GameObject myPlayer;

        void Start()
        {
            Action<BuffModel[]> buf = ReadJson;
            TableParser<BuffModel>.Parse("ArmyModel", buf);
        }

        public void ReadJson(BuffModel[] buf)
        {
            Debug.Log(buf[0].id);

            CreateEnemy(buf[0]);
        }

        /**
     * 创建角色
     */
        public void CreateEnemy(BuffModel buf)
        {
            GameObject player = Instantiate(this.myPlayer, this.transform, false);
            player.transform.localPosition = new Vector3(-16, 1.16f, -43);
            MyPlayer.Singleton.GetPlayerData(buf);

            GameObject enemy = Instantiate(prebEnemy, this.transform, false);
            float x = Random.Range(-20f, -12f);
            float z = Random.Range(-40f, -35f);
            enemy.transform.position = new Vector3(x, 1.6f, z);
        }
    }
}