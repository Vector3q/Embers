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

    //老虎的移动目标坐标:玩家
    Vector2 moveTarget;
    //老虎的位置
    Vector2 position;

    // Start is called before the first frame update
    public void Start()
    {
        base.Start();
        mrigidbody2D = GetComponent<Rigidbody2D>();
/*        StartCoroutine(Wake());*/
    }

    // Update is called once per frame
    public void Update()
    {
        base.Update();
        //获取玩家的位置
        GetPlayerPosition();
        //向玩家移动
        MoveToPlayer();
        
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
}
