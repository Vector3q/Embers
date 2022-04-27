using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBeast : Enemy
{
    //�ϻ���AI�趨��һֱ��ֱ�����·��������ƶ�
    //�ϻ��ܵ�����֮��ᱻ���˲���ԭ��ѣ��һ�£������˲��ҽ�ֱ��


    public float Speed;
    public float AttackCD;
    Rigidbody2D mrigidbody2D;

    //�Ƿ�ֱ
    bool isStill;

    //�ϻ����ƶ�Ŀ������:���
    Vector2 moveTarget;
    //�ϻ���λ��
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
        //�����ƶ��͹�����ǰ������һ�����
        if (healthController!=null)
        {
            base.Update();
            //��ȡ��ҵ�λ��
            GetPlayerPosition();
            //������ƶ�
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
        //��ȡ�˶��ķ���
        MoveDirection.x=moveTarget.x-transform.position.x;
        MoveDirection.y=moveTarget.y-transform.position.y;
        //�˶�������һ��
        MoveDirection.Normalize();

        //������ƶ�
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
        //��ȡ��ҵ�λ��
        GetPlayerPosition();
        //�����˵ķ���
        Vector2 KnockedBackDirection;
        Vector2 KnockedBackPosition;
        //ȷ�������˵ķ���
        KnockedBackDirection.x = transform.position.x - moveTarget.x;
        KnockedBackDirection.y = transform.position.y - moveTarget.y;
/*        Debug.Log(KnockedBackDirection.x);
        Debug.Log(KnockedBackDirection.y);*/
        //�����һ��
        KnockedBackDirection.Normalize();
        //����λ�ü���
        KnockedBackPosition.x = transform.position.x + KnockedBackDirection.x * Speed * Time.deltaTime * 50;
        KnockedBackPosition.y = transform.position.y + KnockedBackDirection.y * Speed * Time.deltaTime * 50;
        /*        Debug.Log(KnockedBackPosition.x);
                Debug.Log(KnockedBackPosition.y);*/
        transform.position = KnockedBackPosition;
        /*mrigidbody2D.MovePosition(KnockedBackPosition);*/
    }
}
