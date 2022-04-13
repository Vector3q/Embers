using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 界面动画，不用增减脚本
/// </summary>
public class zoomController : MonoBehaviour
{
    float zoomsize;

    // Start is called before the first frame update
    void Start()
    {
        zoomsize = 0.001f;
    }

    // Update is called once per frame
    void Update()
    {
        sizeChange();
    }

    void sizeChange()
    {
        transform.localScale = transform.localScale + zoomsize * transform.localScale;

        if(transform.localScale.x >= 3.2f)
        {
            transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        }
    }
}
