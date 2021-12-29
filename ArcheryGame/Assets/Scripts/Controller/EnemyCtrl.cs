using System;
using UnityEngine;
using View;

namespace Controller
{
    public class EnemyCtrl : MonoBehaviour
    {
        public int maxHp = 1000;

        public void Start()
        {
            FightDisplayHpView.Singleton.FreshHpValue(maxHp, Role.Enemy);
        }

        private void OnCollisionEnter(Collision col)
        {
            Debug.Log("开始碰撞" + col.collider.gameObject.name);
        }

        public void OnCollisionStay(Collision col)
        {
            Debug.Log("持续碰撞中" + col.collider.gameObject.name);
        }

        public void OnCollisionExit(Collision col)
        {
            Debug.Log("碰撞结束" + col.collider.gameObject.name);
        }

        public void OnTriggerEnter(Collider other)
        {
            Debug.Log("触发器开始出发:" + other.gameObject.name);
            if (!other || !other.CompareTag("arraw"))
            {
                return;
            }
            maxHp -= other.gameObject.GetComponent<ArrawCtrl>().attack;
            maxHp = Math.Max(maxHp, 0);
            FightDisplayHpView.Singleton.FreshHpValue(maxHp, Role.Enemy);
            Destroy(other.gameObject);
            if (maxHp <= 0)
            {
                Destroy(this.gameObject);
            }
        }

        public void OnTriggerExit(Collider other)
        {
            Debug.Log("触发器结束:" + other.gameObject.name);
        }
    }
}