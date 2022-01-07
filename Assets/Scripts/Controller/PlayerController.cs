using Entity;
using Model;
using UnityEngine;
using Utils;

namespace Controller
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Animator anim;

        private GameObject targetEnemy;

        private Enemy targetEnemyInfo;

        private Player mySelf;

        private float speed = 10f;

        private static readonly int Run = Animator.StringToHash("run");

        private static readonly int Idle = Animator.StringToHash("idle");

        private static readonly int Attack = Animator.StringToHash("attack");

        public static PlayerController Singleton;

        private ArcheryModel archeryModel;

        public void Awake()
        {
            Singleton = this;
            archeryModel = ArcheryModel.CreateInstance();
            archeryModel.OnEnemyDie += LockEnemy;
            
        }
        
        public void InitPlayerData(BuffModel playerData)
        {
            mySelf = new Player(playerData);
            archeryModel.PlayerHp = mySelf.MaxHp;
            LockEnemy();
        }

        /// <summary>
        /// 发射弓箭
        /// </summary>
        public void Fire()
        {
            anim.SetTrigger(Attack);
            if (!targetEnemy)
            {
                return;
            }

            var arrow = ObjectPool.CreateInstance().GetObj("FrostArcher_Arrow");
            arrow.transform.SetParent(transform.parent, false);
            var position = transform.position;
            arrow.transform.position = new Vector3(position.x, position.y + 0.3f, position.z);
            arrow.transform.LookAt(targetEnemy.transform.position);
            ArrowController.Singleton.InitAttackPower(mySelf.Atk, targetEnemy);
        }
        
        /// <summary>
        /// 锁定某个敌人
        /// </summary>
        private void LockEnemy()
        {
            targetEnemy = null;   
            if (archeryModel.enemyDic.Count <= 0)
            {
                return;
            }
            //敌人的信息： Hp, Name
            targetEnemyInfo = archeryModel.GetEnemy().Key;
            //敌人节点
            targetEnemy = archeryModel.GetEnemy().Value;
            //显示当前锁定敌人的血量
            archeryModel.EnemyHp = targetEnemyInfo.MaxHp;
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
                anim.SetTrigger(Attack);
                Invoke(nameof(Fire), 0.3f);
            }
        }
        /// <summary>
        /// 动画回调
        /// </summary>
        public void AnimationCallBack()
        {
        }
    }
}