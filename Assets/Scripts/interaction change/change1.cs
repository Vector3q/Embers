using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change1 : MonoBehaviour
{
    
    public GameObject obj;
    public GameObject grow;
    static public bool isChange;
    // Start is called before the first frame update
    void Start()
    {
        isChange = false;
    }
    void Knife()
    {
        string namek = GameObject.Find("Player").GetComponent<PlayerController>().Equipment_weapon.itemName;
        if (namek=="sword"&& Input.GetKeyDown(KeyCode.I))//��
        {
          
            grow.SetActive(false);
            obj.SetActive(true);
            Debug.Log("ok");
            isChange = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Knife();
    }
}
