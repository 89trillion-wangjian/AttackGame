using System.Collections;
using UnityEngine;

namespace Controller
{
    public class ArrawCtrl : MonoBehaviour
    {
        // Start is called before the first frame update
        private Transform nodeEnemy;
        private readonly float speed = 20;
        public int attack;

        void Start()
        {
            nodeEnemy = transform.parent.Find("enemy(Clone)");
            StartCoroutine(MoveToTarget());
        }

        IEnumerator MoveToTarget()
        {
            while (transform.position != nodeEnemy.position)
            {
                transform.position =
                    Vector3.MoveTowards(transform.position, nodeEnemy.position, speed * Time.deltaTime);
                yield return new WaitForFixedUpdate();
            }
        }

        public void InitAttack(int atk)
        {
            attack = atk;
        }
    }
}