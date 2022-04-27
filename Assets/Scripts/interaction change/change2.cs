using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change2 : MonoBehaviour
{
    public GameObject wuti;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Player").GetComponent<PlayerController>().Equipment_weapon.itemName == "plant")//ÖÖ
        wuti.SetActive(true);
    }
}
