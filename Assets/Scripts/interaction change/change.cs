using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change : MonoBehaviour
{
    public GameObject miss;
    // public GameObject obj;
    public GameObject grow;

    // Start is called before the first frame update
    void Start()
    {
    }


    // Update is called once per frame

    void Autum()
    {
       
            string namea = GameObject.Find("Player").GetComponent<PlayerController>().Equipment_weapon.itemName;
        if (namea == "autumn"&&Input .GetKeyDown(KeyCode.I))
        {
            miss.SetActive(false);
            grow.SetActive(true);


        }


    }
    // Update is called once per frame
    void Update()
    {

        Autum();

    }
}
