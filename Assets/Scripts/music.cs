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
        else//如果这个场景已经存在一个PlayerController脚本了
        {
            if (instance != this)
            {
                Destroy(gameObject);//保证游戏中永远只有一个playercontroller脚本
            }
            DontDestroyOnLoad(gameObject);//保证在场景转换中该脚本存在于任何场景中，不会因为加载新的场景就消失不见
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
