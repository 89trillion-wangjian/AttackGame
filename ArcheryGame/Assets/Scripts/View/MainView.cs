using System;
using System.Collections;
using System.Collections.Generic;
using model;
using Model;
using TableConfig;
using UnityEngine;
using Random = UnityEngine.Random;

public class MainView : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject prebEnemy;
    public GameObject myPlayer;
    void Start()
    {
        Action<BuffModel[]> buf = ReadJson;
        TableParser<BuffModel>.Parse("ArmyModel", buf);
        CreateEnemy();
    }

    public void ReadJson(BuffModel[] buf)
    {
        Debug.Log(buf[0].id);
        
        myPlayer.GetComponent<MyPlayer>().GetPlayerData(buf[0]);
    }

    /**
     * 创建敌方角色
     */
    public void CreateEnemy()
    {
        GameObject enemy = Instantiate(prebEnemy);
        enemy.transform.SetParent(this.transform, false);
        float x = Random.Range(-20f, -12f);
        float z = Random.Range(-40f, -35f);
        enemy.transform.position = new Vector3(x, 1.6f, z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}