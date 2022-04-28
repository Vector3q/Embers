using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBeast : Enemy
{
    //老虎的AI设定：一直以直线最短路径向玩家移动
    //老虎受到攻击之后会被击退并且原地眩晕一下（被击退并且僵直）


    public float Speed;
    public float AttackCD;
    Rigidbody2D mrigidbody2D;

    //是否僵直
    bool isStill;

    //老虎的移动目标坐标:玩家
    Vector2 moveTarget;
    //老虎的位置
    Vector2 position;

    private PlayerHealthController healthController;

    // Start is called before the first frame update
    public void Start()
    {
        base.Start();
        mrigidbody2D = GetComponent<Rigidbody2D>();
/*        StartCoroutine(Wake());*/

        healthController=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthController>();
    }

    // Update is called once per frame
    public void Update()
    {
        //怪物移动和攻击的前提是玩家还活着
        if (healthController!=null)
        {
            base.Update();
            //获取玩家的位置
            GetPlayerPosition();
            //向玩家移动
            MoveToPlayer();
        }
        
    }

    private void GetPlayerPosition()
    {
        moveTarget.x = GameObject.FindWithTag("Player").GetComponent<Transform>().position.x;
        moveTarget.y = GameObject.FindWithTag("Player").GetComponent<Transform>().position.y;
    }

    void MoveToPlayer()
    {
        Vector2 MoveDirection;
        //获取运动的方向
        MoveDirection.x=moveTarget.x-transform.position.x;
        MoveDirection.y=moveTarget.y-transform.position.y;
        //运动向量归一化
        MoveDirection.Normalize();

        //向玩家移动
        moveTarget.x=transform.position.x+MoveDirection.x*Speed*Time.deltaTime;
        moveTarget.y=transform.position.y+MoveDirection.y*Speed*Time.deltaTime;
        mrigidbody2D.MovePosition(moveTarget);

    }

    IEnumerator Wake()
    {
        yield return new WaitForSeconds(5);
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        //获取玩家的位置
        GetPlayerPosition();
        //被击退的方向
        Vector2 KnockedBackDirection;
        Vector2 KnockedBackPosition;
        //确定被击退的方向
        KnockedBackDirection.x = transform.position.x - moveTarget.x;
        KnockedBackDirection.y = transform.position.y - moveTarget.y;
/*        Debug.Log(KnockedBackDirection.x);
        Debug.Log(KnockedBackDirection.y);*/
        //方向归一化
        KnockedBackDirection.Normalize();
        //击退位置计算
        KnockedBackPosition.x = transform.position.x + KnockedBackDirection.x * Speed * Time.deltaTime * 50;
        KnockedBackPosition.y = transform.position.y + KnockedBackDirection.y * Speed * Time.deltaTime * 50;
        /*        Debug.Log(KnockedBackPosition.x);
                Debug.Log(KnockedBackPosition.y);*/
        transform.position = KnockedBackPosition;
        /*mrigidbody2D.MovePosition(KnockedBackPosition);*/
    }
}
