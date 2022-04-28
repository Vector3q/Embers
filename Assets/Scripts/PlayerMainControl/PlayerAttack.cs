using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.Reflection;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    public int SwordDamage;
    private PolygonCollider2D mcollider2D;
    //结束攻击之后
    public float EndWaitTime;
    //开始攻击之前的等待时间（前摇）
    public float StartAttackTime;
    // Start is called before the first frame update
    void Start()
    {
        anim=GameObject.Find("Player").GetComponent<Animator>();
        mcollider2D=GetComponent<PolygonCollider2D>();
        EndWaitTime = 0.15f;
        StartAttackTime = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    //按下j键攻击
    void Attack()
    {
        //按下攻击键进行攻击
        if (Input.GetButtonDown("Attack"))
        {
            anim.SetTrigger("Attack");
            //控制碰撞体的出现和消失
            StartCoroutine(StartAttack());
        }
    }

    //让碰撞体出现的携程
    IEnumerator StartAttack()
    {
        yield return new WaitForSeconds(StartAttackTime);
        mcollider2D.enabled = true;
        StartCoroutine(DisabledHitBox());
    }

    //让碰撞体消逝的携程
    IEnumerator DisabledHitBox()
    {
        yield return new WaitForSeconds(EndWaitTime);
        mcollider2D.enabled = false;
    }

    //使用攻击的时候伤害到敌人调用
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(SwordDamage);
        }
    }
}
