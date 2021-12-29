using System.Collections;
using UnityEngine;

namespace Controller
{
    public class ArrawCtrl : MonoBehaviour
    {
        [SerializeField] private ArrawCtrl arrawCtrl;
        
        private Transform nodeEnemy;
        
        private readonly float speed = 20;
        
        public int attack;

        public static ArrawCtrl Singleton;
        public void Awake()
        {
            Singleton = arrawCtrl;
        }

        public void Start()
        {
            nodeEnemy = transform.parent.Find("enemy(Clone)");
            StartCoroutine(MoveToTarget());
        }

        private IEnumerator MoveToTarget()
        {
            while (transform.position != nodeEnemy.position)
            {
                transform.position 
                    = Vector3.MoveTowards(transform.position, nodeEnemy.position, speed * Time.deltaTime);
                yield return new WaitForFixedUpdate();
            }
        }

        public void InitAttackPower(int atk)
        {
            attack = atk;
        }
    }
}