using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    //背包
    public GameObject bag;

    bool isOpen;

    //Animator animator;
    Vector3 movement;

    void Start()
    {
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed, Input.GetAxisRaw("Vertical") * Time.deltaTime * speed, 0);

        transform.Translate(movement);//移动

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
}
