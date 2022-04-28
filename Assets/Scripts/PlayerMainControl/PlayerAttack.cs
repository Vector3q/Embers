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
    //��������֮��
    public float EndWaitTime;
    //��ʼ����֮ǰ�ĵȴ�ʱ�䣨ǰҡ��
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

    //����j������
    void Attack()
    {
        //���¹��������й���
        if (Input.GetButtonDown("Attack"))
        {
            anim.SetTrigger("Attack");
            //������ײ��ĳ��ֺ���ʧ
            StartCoroutine(StartAttack());
        }
    }

    //����ײ����ֵ�Я��
    IEnumerator StartAttack()
    {
        yield return new WaitForSeconds(StartAttackTime);
        mcollider2D.enabled = true;
        StartCoroutine(DisabledHitBox());
    }

    //����ײ�����ŵ�Я��
    IEnumerator DisabledHitBox()
    {
        yield return new WaitForSeconds(EndWaitTime);
        mcollider2D.enabled = false;
    }

    //ʹ�ù�����ʱ���˺������˵���
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(SwordDamage);
        }
    }
}
