using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public Light light;
    float LightRange;
    float sumLight;

    public Item word_Torch;

    public Inventory wordList;

    const float THERESOLD = 100;

    private void Start()
    {
        light = gameObject.GetComponent<Light>();
        LightRange = light.range;
        sumLight = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x,player.transform.position.y,transform.position.z);
        changeLight();
    }

    void changeLight()
    {
        if(player.GetComponent<PlayerController>().Equipment_weapon.itemName == "fire")
        {
            if(Input.GetAxis("Mouse ScrollWheel") != 0)
            {
                Debug.Log(Input.GetAxis("Mouse ScrollWheel"));
                if (light.range < THERESOLD)
                {
                    // 小于阈值时加亮度
                    sumLight += Input.GetAxis("Mouse ScrollWheel") * 20;
                    light.range = LightRange + sumLight;

                }
                else if(light.range == THERESOLD)
                {
                    //等于阈值时获得炬字
                    if(!IsObtainTorch())
                    {
                        //InventroyManager.
                    }
                }
            }

        }
        else if(player.GetComponent<PlayerController>().Equipment_weapon.itemName != "fire")
        {
            light.range = LightRange;
        }
    }

    bool IsObtainTorch()
    {
        if (wordList.itemList.Contains(word_Torch))
            return true;
        return false;
    }
}
