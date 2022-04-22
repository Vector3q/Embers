using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change : MonoBehaviour
{
    public GameObject miss;
    public GameObject obj;
    bool judge = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (judge)
        {
            miss.SetActive(false);
            obj.SetActive(true);
        }
    }
}
