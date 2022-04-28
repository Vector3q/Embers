using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeInteract: MonoBehaviour
{
    //获取碰撞体
    private Collider2D mycollider;
    private PlayerController playercontroller;

    // Start is called before the first frame update
    void Start()
    {
        playercontroller=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //如果人在树的可交互碰撞体内
    private void OnTriggerStay2D(Collider2D other)
    {
        playercontroller.interactive = true;
    }
}
