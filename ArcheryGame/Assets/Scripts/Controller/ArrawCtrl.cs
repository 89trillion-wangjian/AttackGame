using UnityEngine;

public class ArrawCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform nodeEnemy;
    private float speed = 20;
    public int attack;

    void Start()
    {
        nodeEnemy = transform.parent.Find("enemy(Clone)");
    }

    public void InitAttack(int atk)
    {
        attack = atk;
    }

    // Update is called once per frame
    void Update()
    {
        if (!nodeEnemy)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, nodeEnemy.position, speed * Time.deltaTime);
    }
}