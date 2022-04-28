using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrance : MonoBehaviour
{
    public string entrancepassword;
    private void Start()
    {
        if (PlayerController.instance.password ==entrancepassword)
        {
            PlayerController.instance.transform.position = transform.position;//角色的出生点为EntrancePrefab的所在位置
            //不要忘了将Enrance的z值设置为0
            Debug.Log("ENTER!");
        }
        else
        {
            Debug.Log("Wrong Password!");
        }
    }
    
}
