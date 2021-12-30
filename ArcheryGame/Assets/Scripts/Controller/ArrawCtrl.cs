using System;
using System.Collections;
using UnityEngine;
using Utils;

namespace Controller
{
    public class ArrawCtrl : MonoBehaviour
    {

        private readonly float speed = 20;

        public int attack;

        public static ArrawCtrl Singleton;

        public void Awake()
        {
            Singleton = this;
        }

        public void Fire()
        {
            StartCoroutine(MoveToTarget());
        }

        private IEnumerator MoveToTarget()
        {
            while (transform.position != EnemyCtrl.Singleton.transform.position)
            {
                transform.position
                    = Vector3.MoveTowards(transform.position, EnemyCtrl.Singleton.transform.position, speed * Time.deltaTime);
                yield return new WaitForFixedUpdate();
            }
        }

        public void InitAttackPower(int atk)
        {
            attack = atk;
            Fire();
        }
    }
}