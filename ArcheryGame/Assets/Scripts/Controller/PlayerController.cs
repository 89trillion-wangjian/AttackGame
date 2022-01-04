using Entity;
using Model;
using UnityEngine;
using Utils;

namespace Controller
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Animator anim;

        private Transform nodeEnemy;

        private Player mySelf;

        private float speed = 10f;

        private GameObject uiGameRoot;

        private static readonly int Run = Animator.StringToHash("run");

        private static readonly int Idle = Animator.StringToHash("idle");

        private static readonly int Atk = Animator.StringToHash("atk");

        public static PlayerController Singleton;


        public void Awake()
        {
            Singleton = this;
        }

        public void GetPlayerData(BuffModel playerData)
        {
            mySelf = new Player(playerData);
            ArcheryModel.CreateInstance().PlayerHp = mySelf.MaxHp;
        }

        /// <summary>
        /// 发射弓箭
        /// </summary>
        public void Fire()
        {
            nodeEnemy = transform.parent.Find("enemy(Clone)");
            anim.SetTrigger(Atk);
            if (!nodeEnemy)
            {
                return;
            }

            var arrow = ObjectPool.CreateInstance().GetObj("FrostArcher_Arrow");
            arrow.transform.SetParent(transform.parent, false);
            var position = transform.position;
            arrow.transform.position = new Vector3(position.x, position.y + 0.3f, position.z);
            arrow.transform.LookAt(nodeEnemy.position);
            ArrawController.Singleton.InitAttackPower(mySelf.Atk);
        }


        void Update()
        {
            if (Input.GetKey(KeyCode.R))
            {
                anim.SetBool(Run, true);
            }
            else if (Input.GetKeyUp(KeyCode.R))
            {
                anim.SetBool(Run, false);
            }

            if (Input.GetKey(KeyCode.I))
            {
                anim.SetBool(Idle, true);
            }

            speed += Time.deltaTime;
            if (mySelf == null || speed < mySelf.ShootSpeed)
            {
                return;
            }

            if (Input.GetKey(KeyCode.A))
            {
                speed = 0;
                anim.SetTrigger(Atk);
                Invoke(nameof(Fire), 0.3f);
            }
        }

        public void AnimationCallBack()
        {
        }
    }
}