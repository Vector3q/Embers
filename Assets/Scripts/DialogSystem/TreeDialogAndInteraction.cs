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

    //调用基类的方法，然后人物也要有动画
    private void OnEnable()
    {
        base.OnEnable();
        //开始坐下的动画
        anim.SetBool("SittingDown", true);
    }

    //对话结束之后，人物结束坐下的动作
    private void OnDisable()
    {
        anim.SetBool("SittingDown", false);
        playerController.isInteracting = false;
    }
}
