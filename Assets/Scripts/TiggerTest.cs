using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiggerTest : MonoBehaviour
{
    public GameObject prompt;//按E拾取
    public GameObject pickobject;//要拾取的物体
    public Collider2D collider2;
    bool judge=false;
    public void Show(GameObject prompt)
    {
        prompt.SetActive(true);
    }
    public void Hide(GameObject prompt)
    {
        prompt.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D other)//接触时触发，无需调用
    {
        judge = true;
        Show(prompt);
    }
    void OnTriggerStay2D(Collider2D other)    //每帧调用一次OnTriggerStay()函数
    {
        
    }
    void OnTriggerExit2D(Collider2D other)
    {
        judge = false;
        Hide(prompt);
    }
  

    
    void Start()
    {
        Hide(prompt);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&&judge==true)
        {
            Destroy(pickobject);
            //Debug.Log("shuchula");
            //gameObject.AddComponent<ItemOnWorld>();
        }
    }
}
