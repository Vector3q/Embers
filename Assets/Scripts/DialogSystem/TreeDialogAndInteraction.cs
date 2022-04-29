using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeDialogAndInteraction : Dialog
{

    private Animator anim;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Awake()
    {
        base.Awake();
        anim=GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    //���û���ķ�����Ȼ������ҲҪ�ж���
    private void OnEnable()
    {
        base.OnEnable();
        //��ʼ���µĶ���
        anim.SetBool("SittingDown", true);
    }

    //�Ի�����֮������������µĶ���
    private void OnDisable()
    {
        anim.SetBool("SittingDown", false);
        playerController.isInteracting = false;
    }
}
