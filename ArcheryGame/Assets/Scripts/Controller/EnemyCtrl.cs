using System;
using UnityEngine;
using View;

namespace Controller
{
    public class EnemyCtrl : MonoBehaviour
    {
        // Start is called before the first frame update
        public int maxHp = 1000;
        private GameObject uiGameRoot;

        void Start()
        {
            uiGameRoot = GameObject.Find("Canvas");
            uiGameRoot.GetComponent<FightDisplayHpView>().FreshHpValue(maxHp, Role.Ememy);
        }

        // Update is called once per frame

        void OnCollisionEnter(Collision col)
        {
            Debug.Log("开始碰撞" + col.collider.gameObject.name);
        }

        void OnCollisionStay(Collision col)
        {
            Debug.Log("持续碰撞中" + col.collider.gameObject.name);
        }

        void OnCollisionExit(Collision col)
        {
            Debug.Log("碰撞结束" + col.collider.gameObject.name);
        }

        void OnTriggerEnter(Collider other)
        {
            Debug.Log("触发器开始出发:" + other.gameObject.name);
            if (other && other.CompareTag("arraw"))
            {
                maxHp -= other.gameObject.GetComponent<ArrawCtrl>().attack;
                maxHp = Math.Max(maxHp, 0);
                uiGameRoot.GetComponent<FightDisplayHpView>().FreshHpValue(maxHp, Role.Ememy);
                Destroy(other.gameObject);
                if (maxHp <= 0)
                {
                    Destroy(this.gameObject);
                }
            }
        }

        void OnTriggerExit(Collider other)
        {
            Debug.Log("触发器结束:" + other.gameObject.name);
        }
    }
}