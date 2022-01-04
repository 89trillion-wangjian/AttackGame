using System;
using Model;
using UnityEngine;
using Utils;
using View;

namespace Controller
{
    public class EnemyController : MonoBehaviour
    {
        public int maxHp = 1000;

        public static EnemyController Singleton;

        public void Awake()
        {
            Singleton = this;
        }

        public void Start()
        {
            ArcheryModel.CreateInstance().EnemyHp = maxHp;
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

            maxHp -= other.gameObject.GetComponent<ArrawController>().attack;
            maxHp = Math.Max(maxHp, 0);
            // FightDisplayHpView.Singleton.FreshHpValue(maxHp, Role.Enemy);
            ArcheryModel.CreateInstance().EnemyHp = maxHp;
            ObjectPool.CreateInstance().RecycleObj(other.gameObject);
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