using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class FightDisplayHpView : MonoBehaviour
    {
        // Start is called before the first frame update
        public Text myHp;
        public Text enemyHp;

        /**
     * 刷新血量信息
     */
        public void FreshHpValue(int value, Role role)
        {
            if (role == Role.Ememy)
            {
                enemyHp.text = "敌方血量" + value;
            }
            else
            {
                myHp.text = "我方血量" + value;
            }
        }

        // Update is called once per frame
    }

    public enum Role
    {
        Player = 0,
        Ememy = 1
    }
}