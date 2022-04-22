using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    //速度
    public float speed;
    //背包
    public GameObject bag;
    //人物所携带的物体
    public Item Equipment_weapon;
    //背包中选中的物体
    static public Item Selected_Equipment;

    public Plane synthesisPlane;

    //背包是否打开
    bool isOpen;


    Animator animator;
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
        //movement = new Vector3(Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed, Input.GetAxisRaw("Vertical") * Time.deltaTime * speed, 0);

        //transform.Translate(movement);//移动

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("MoveX", lookDirection.x);
        animator.SetFloat("MoveY", lookDirection.y);
        animator.SetFloat("running", move.magnitude);

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

        //if (movement.x > 0)//翻脸
        //    transform.localScale = new Vector3(1, 1, 1);
        //if (movement.x < 0)
        //    transform.localScale = new Vector3(-1, 1, 1);

        OpenMyBag();
    }
    /*void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }*/

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
    public bool isSpecial(Item item)
    {
        if (item.itemName == "paper")
            return true;
        return false;
    }
    public void EquipmentReplace()
    {
        if(!isSpecial(Selected_Equipment))
            Equipment_weapon = Selected_Equipment;
    }
}
