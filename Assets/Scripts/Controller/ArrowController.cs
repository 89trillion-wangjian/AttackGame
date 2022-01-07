using DG.Tweening;
using UnityEngine;

namespace Controller
{
    public class ArrowController : MonoBehaviour
    {
        public int attack = 0;

        public static ArrowController Singleton;

        public void Awake()
        {
            Singleton = this;
        }

        private void Fire(GameObject enemyObj)
        {
            transform.DOMove(enemyObj.transform.position, 1.0f);
        }
        public void InitAttackPower(int atk, GameObject enemyObj)
        {
            attack = atk;
            Fire(enemyObj);
        }
    }
}