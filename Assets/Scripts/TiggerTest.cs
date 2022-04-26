using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiggerTest : MonoBehaviour
{
    public GameObject prompt;//��Eʰȡ
    public GameObject pickobject;//Ҫʰȡ������
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
    void OnTriggerEnter2D(Collider2D other)//�Ӵ�ʱ�������������
    {
        judge = true;
        Show(prompt);
    }
    void OnTriggerStay2D(Collider2D other)    //ÿ֡����һ��OnTriggerStay()����
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
