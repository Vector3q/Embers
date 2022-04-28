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

    void bamboo1()
    {
        string nameb = GameObject.Find("Player").GetComponent<PlayerController>().Equipment_weapon.itemName;
        if (nameb == "knife" && Input.GetKeyDown(KeyCode.I))
        {

            miss.SetActive(false);
            grow.SetActive(true);
            Debug.Log("ok");
        }
    }
// Update is called once per frame
void Update()
    {
        bamboo1();
    }
}
