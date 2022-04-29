using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeInteract : MonoBehaviour
{
    //获取碰撞体
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
            //如果此时判定到角色不是正在交互，就执行坐下的动画
            if (!playercontroller.isInteracting)
            {
                playercontroller.SitDown();
            }
            //如果正在交互，再按一次就退出交互
            else
            {
                playercontroller.isInteracting = !playercontroller.isInteracting;
                anim.SetBool("SittingDown", false);
            }
        }
    }

    ////如果人在树的可交互碰撞体内
    //private void OnTriggerStay2D(Collider2D other)
    //{
    //    if (Input.GetButtonDown("Interaction"))
    //    {
    //        //如果此时判定到角色不是正在交互，就执行坐下的动画
    //        if (!playercontroller.isInteracting)
    //        {
    //            playercontroller.SitDown();
    //        }
    //        //如果正在交互，再按一次就退出交互
    //        else
    //        {
    //            playercontroller.isInteracting = !playercontroller.isInteracting;
    //            anim.SetBool("SittingDown", false);
    //        }
    //    }

    //}
}
