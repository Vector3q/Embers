using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiggerTest : MonoBehaviour
{
    public GameObject prompt;
    public GameObject pickobject;
    public void Show(GameObject prompt)
    {
        //������ĳ�����弤����ǽ��ã�������prompt��Ҳ�����Ǹ�ͼ��
        //����ʱ���������������嶼����ã���������Ľű���������ܷ���
        prompt.SetActive(true);
    }
    public void Hide(GameObject prompt)
    {
        prompt.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D other)//�Ӵ�ʱ�������������
    {
       // Debug.Log(Time.time + ":����ô������Ķ����ǣ�" + other.gameObject.name);
        Show(prompt);
    }
    void OnTriggerStay2D(Collider2D other)    //ÿ֡����һ��OnTriggerStay()����
    {
        //Debug.Log(Time.time + "���ڴ������Ķ����ǣ�" + other.gameObject.name);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log(Time.time + "�뿪�������Ķ����ǣ�" + other.gameObject.name);
        Hide(prompt);
    }
  

    // Start is called before the first frame update
    void Start()
    {
        Hide(prompt);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Destroy(pickobject);
            Debug.Log("shuchula");
        }
    }
}
