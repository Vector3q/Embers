﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    //速度
    public float speed=2.0f;
    //背包
    public GameObject bag;
    //人物所携带的物体
    public Item Equipment_weapon;
    //背包中选中的物体
    static public Item Selected_Equipment;
    //合成界面
    public Plane synthesisPlane;


    //背包是否打开
    bool isOpen;

    //动画管理器
    public Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);

    Rigidbody2D rigidbody2d;
    
    Vector3 movement;

    float horizontal;
    float vertical;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Attack();
        OpenMyBag();
    }
    /*void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }*/
    /// <summary>
    /// M键打开关闭背包
    /// </summary>
    /// 

    //攻击的函数
    void Attack()
    {
        if (Input.GetButtonDown("Attack")) 
        {
            animator.SetTrigger("Attack");
        }
    }

    //行走的函数
    void Move()
    {
        //movement = new Vector3(Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed, Input.GetAxisRaw("Vertical") * Time.deltaTime * speed, 0);

        //transform.Translate(movement);//移动

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        /*if (movement.x > 0)//翻脸
            transform.localScale = new Vector3(1, 1, 1);
        if (movement.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);*/

        //把朝向的信息传给animator
        animator.SetFloat("MoveX", horizontal);
        animator.SetFloat("MoveY", vertical);

        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);

        //if (movement != Vector3.zero)//动画
        //{
        //    animator.SetBool("running", true);
        //}
        //else
        //{
        //    animator.SetBool("running", false);
        //}

        

    }

    void OpenMyBag()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            isOpen = !isOpen;
            bag.SetActive(isOpen);
        }
        if(Input.GetKeyDown(KeyCode.Escape) && isOpen)
        {
            isOpen = false;
            bag.SetActive(isOpen);
        }
    }
    /// <summary>
    /// 检测是否有使用特殊物品
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public bool isSpecial(Item item)
    {
        if (item.itemName == "paper")
            return true;
        return false;
    }
    /// <summary>
    /// Use按键替换player携带的武器
    /// </summary>
    public void EquipmentReplace()
    {
        if(!isSpecial(Selected_Equipment) && !DetectSpecial.Detected)//所选物品不是特殊物体并且合成界面未打开
            Equipment_weapon = Selected_Equipment;
    }
}
