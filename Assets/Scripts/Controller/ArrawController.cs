using System.Collections;
using UnityEngine;

namespace Controller
{
    public class ArrawController : MonoBehaviour
    {
        private readonly float speed = 20;

        public int attack;

        public static ArrawController Singleton;

        public void Awake()
        {
            Singleton = this;
        }

        private void Fire()
        {
            StartCoroutine(MoveToTarget());
        }

        private IEnumerator MoveToTarget()
        {
            while (transform.position != EnemyController.Singleton.transform.position)
            {
                transform.position
                    = Vector3.MoveTowards(transform.position, EnemyController.Singleton.transform.position,
                        speed * Time.deltaTime);
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