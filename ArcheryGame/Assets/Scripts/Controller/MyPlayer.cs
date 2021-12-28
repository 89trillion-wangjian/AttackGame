using System.Collections;
using System.Collections.Generic;
using Model;
using UnityEngine;
using View;

public class MyPlayer : MonoBehaviour
{
    public float walkSpeed = 4f;

    public float turnSpeed = 30f;

    public GameObject prebArrow;
    private Transform nodeEnemy;

    private Player mySelf;


    private float speed = 10f;

    private GameObject uiGameRoot;

    private Animator anim;

    private static readonly int Run = Animator.StringToHash("run");
    private static readonly int Idle = Animator.StringToHash("idle");
    private static readonly int Attack = Animator.StringToHash("attack");

    // Start is called before the first frame update
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

    /**
     * 发射弓箭
     */
    public void OnFire()
    {
        nodeEnemy = transform.parent.Find("enemy(Clone)");
        if (!nodeEnemy)
        {
            return;
        }

        GameObject arraw = Instantiate(prebArrow, transform.parent, false);
        arraw.GetComponent<ArrawCtrl>().InitAttack(mySelf.Atk);
        var position = transform.position;
        arraw.transform.position = new Vector3(position.x, position.y + 0.3f, position.z);

        arraw.transform.LookAt(nodeEnemy.position);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            Debug.Log("跑步动画");
            anim.SetBool(Run, true);
        }
        else if (Input.GetKeyUp(KeyCode.R))
        {
            anim.SetBool(Run, false);
        }

        if (Input.GetKey(KeyCode.I))
        {
            Debug.Log("待机动画");
            anim.SetBool(Idle, true);
        }
        // else if (Input.GetKeyUp(KeyCode.I))
        // {
        //     Debug.Log("待机动画");
        //     anim.SetBool("idle", false);
        // }


        speed += Time.deltaTime;

        if (mySelf == null || speed < mySelf.ShootSpeed)
        {
            return;
        }


        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, walkSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -walkSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            // transform.Rotate(0, - turnSpeed * Time.deltaTime, 0);
            speed = 0;
            anim.SetTrigger(Attack);
            Invoke("OnFire", 0.3f);
            // OnFire();
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