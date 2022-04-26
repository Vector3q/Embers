using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change1 : MonoBehaviour
{
    
    public GameObject obj;
    public GameObject grow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {

            grow.SetActive(false);
            obj.SetActive(true);
            Debug.Log("ok");
        }
    }
}
