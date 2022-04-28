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
    void Knife()
    {
        string namek = GameObject.Find("Player").GetComponent<PlayerController>().Equipment_weapon.itemName;
        if (namek=="kinfe"&& Input.GetKeyDown(KeyCode.I))//¹È
        {

            grow.SetActive(false);
            obj.SetActive(true);
            Debug.Log("ok");
        }
    }
    // Update is called once per frame
    void Update()
    {
        Knife();
    }
}
