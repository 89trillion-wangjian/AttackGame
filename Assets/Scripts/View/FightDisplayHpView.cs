using Model;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class FightDisplayHpView : MonoBehaviour
    {
        [SerializeField] private FightDisplayHpView fightDisplayHpView;

        [SerializeField] private Text myHp;

        [SerializeField] private Text enemyHp;

        public void Awake()
        {
            ArcheryModel.CreateInstance().OnRoleHpChange += FreshHpValue;
        }

        /// <summary>
        /// 刷新血量信息
        /// </summary>
        /// <param name="value">数值</param>
        /// <param name="role">角色？ 敌人or自己</param>
        private void FreshHpValue(int value, Role role)
        {
            if (role == Role.Enemy)
            {
                enemyHp.text = "敌方血量" + value;
            }
            else
            {
                myHp.text = "我方血量" + value;
            }
        }
    }

    public enum Role
    {
        Player = 0,
        Enemy = 1
    }
}