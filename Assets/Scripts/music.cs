using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    public static music instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else//�����������Ѿ�����һ��PlayerController�ű���
        {
            if (instance != this)
            {
                Destroy(gameObject);//��֤��Ϸ����Զֻ��һ��playercontroller�ű�
            }
            DontDestroyOnLoad(gameObject);//��֤�ڳ���ת���иýű��������κγ����У�������Ϊ�����µĳ�������ʧ����
        }
    }

    //// Start is called before the first frame update
    //void Start()
    //{
    //    DontDestroyOnLoad(this.gameObject);
    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}
