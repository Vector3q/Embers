using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change : MonoBehaviour
{
    public GameObject miss;
    public GameObject obj;
    public GameObject player;
    bool judge = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) { 
        
            miss.SetActive(false);
            obj.SetActive(true);
        }
    }
}
