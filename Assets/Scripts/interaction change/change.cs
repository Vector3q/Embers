using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change : MonoBehaviour
{
    public GameObject miss;
   // public GameObject obj;
    public GameObject grow;
    public GameObject find;
   // bool judge = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player").GetComponent<PlayerController>().Equipment_weapon.itemName == "autumn")//Çï
        {
            miss.SetActive(false);
            grow.SetActive(true);
            
        }
        

    }
}
