using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeInteract: MonoBehaviour
{
    //��ȡ��ײ��
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

    //����������Ŀɽ�����ײ����
    private void OnTriggerStay2D(Collider2D other)
    {
        playercontroller.interactive = true;
    }
}
