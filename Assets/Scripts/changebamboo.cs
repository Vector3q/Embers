using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changebamboo : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject miss;
    // public GameObject obj;
    public GameObject grow;
    // bool judge = true;
    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        //GameObject.Find("Player").GetComponent<PlayerController>().Equipment_weapon.itemName == "Corn"
        if (Input.GetKeyDown(KeyCode.B))
        {
            miss.SetActive(false);
            grow.SetActive(true);

        }
    }
}
