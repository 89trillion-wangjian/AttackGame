using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Controller
{
    public class ArrowController : MonoBehaviour
    {
        private readonly float speed = 20;

        public int attack = 0;

        public static ArrowController Singleton;

        public void Awake()
        {
            Singleton = this;
        }

        private void Fire()
        {
            transform.DOMove(EnemyController.Singleton.transform.position, 1.0f);
        }
        public void InitAttackPower(int atk)
        {
            attack = atk;
            Fire();
        }
    }
}