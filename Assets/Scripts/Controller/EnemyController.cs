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

        public void OnTriggerEnter(Collider other)
        {
            if (!other || !other.CompareTag("arraw"))
            {
                return;
            }

            maxHp -= other.gameObject.GetComponent<ArrawController>().attack;
            maxHp = Math.Max(maxHp, 0);
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