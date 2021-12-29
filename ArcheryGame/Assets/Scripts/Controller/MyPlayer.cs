using Model;
using UnityEngine;
using View;

namespace Controller
{
    public class MyPlayer : MonoBehaviour
    {
        [SerializeField] private MyPlayer myPlayer;

        [SerializeField] private GameObject prebArrow;

        private Transform nodeEnemy;

        private Player mySelf;

        private float speed = 10f;

        private GameObject uiGameRoot;

        private Animator anim;

        private static readonly int Run = Animator.StringToHash("run");

        private static readonly int Idle = Animator.StringToHash("idle");

        private static readonly int Attack = Animator.StringToHash("attack");

        public static MyPlayer Singleton;

        public void Awake()
        {
            Singleton = myPlayer;
        }

        void Start()
        {
            anim = gameObject.GetComponent<Animator>();
        }

        public void GetPlayerData(BuffModel playerData)
        {
            mySelf = new Player(playerData);
            uiGameRoot = GameObject.Find("Canvas");
            uiGameRoot.GetComponent<FightDisplayHpView>().FreshHpValue(mySelf.MaxHp, Role.Player);
        }

        /// <summary>
        /// 发射弓箭
        /// </summary>
        public void Fire()
        {
            nodeEnemy = transform.parent.Find("enemy(Clone)");
            if (!nodeEnemy)
            {
                return;
            }
            var arrow = Instantiate(prebArrow, transform.parent, false);
            ArrawCtrl.Singleton.InitAttackPower(mySelf.Atk);
            var position = transform.position;
            arrow.transform.position = new Vector3(position.x, position.y + 0.3f, position.z);
            arrow.transform.LookAt(nodeEnemy.position);
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
    }


    public class Player
    {
        public int id;
        public int Name;
        public int Note;
        public int MaxHp;
        public int Atk;
        public int Def;
        public int ShootSpeed;

        public Player(BuffModel buf)
        {
            id = buf.id;
            Name = buf.Name;
            Note = buf.Note;
            MaxHp = buf.MaxHp;
            Atk = buf.Atk;
            Def = buf.Def;
            ShootSpeed = buf.ShootSpeed;
        }
    }
}