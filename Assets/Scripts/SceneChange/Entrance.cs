using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrance : MonoBehaviour
{
    public string entrancepassword;
    private void Start()
    {
        if (PlayerController.instance.password ==entrancepassword)
        {
            PlayerController.instance.transform.position = transform.position;//��ɫ�ĳ�����ΪEntrancePrefab������λ��
            //��Ҫ���˽�Enrance��zֵ����Ϊ0
            Debug.Log("ENTER!");
        }
        else
        {
            Debug.Log("Wrong Password!");
        }
    }
    
}
