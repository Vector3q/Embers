using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeInteract : MonoBehaviour
{
    //��ȡ��ײ��
    private Collider2D mycollider;
    private PlayerController playercontroller;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        playercontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Input.GetButtonDown("Interaction"))
        {
            //�����ʱ�ж�����ɫ�������ڽ�������ִ�����µĶ���
            if (!playercontroller.isInteracting)
            {
                playercontroller.SitDown();
            }
            //������ڽ������ٰ�һ�ξ��˳�����
            else
            {
                playercontroller.isInteracting = !playercontroller.isInteracting;
                anim.SetBool("SittingDown", false);
            }
        }
    }

    ////����������Ŀɽ�����ײ����
    //private void OnTriggerStay2D(Collider2D other)
    //{
    //    if (Input.GetButtonDown("Interaction"))
    //    {
    //        //�����ʱ�ж�����ɫ�������ڽ�������ִ�����µĶ���
    //        if (!playercontroller.isInteracting)
    //        {
    //            playercontroller.SitDown();
    //        }
    //        //������ڽ������ٰ�һ�ξ��˳�����
    //        else
    //        {
    //            playercontroller.isInteracting = !playercontroller.isInteracting;
    //            anim.SetBool("SittingDown", false);
    //        }
    //    }

    //}
}
