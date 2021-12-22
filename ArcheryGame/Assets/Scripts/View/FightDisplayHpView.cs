using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightDisplayHpView : MonoBehaviour
{
    // Start is called before the first frame update
    public Text myHp;
    public Text enemyHp;
    void Start()
    {
        
    }
    
    /**
     * 刷新血量信息
     */
    public void freshHpValue(int value, Role role)
    {
        if (role == Role.ememy)
        {
            enemyHp.text = "敌方血量" + value;
        }
        else
        {
            myHp.text = "我方血量" + value;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum Role
{
    player = 0,
    ememy = 1
}
