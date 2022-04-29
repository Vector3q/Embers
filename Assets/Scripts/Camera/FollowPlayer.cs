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
    public Inventory playerInventory;

    const float THERESOLD = 100;
    const float MINTHERESOLD = 10;

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
                if (light.range <= THERESOLD && light.range>=MINTHERESOLD)
                {
                    // 小于阈值时加亮度
                    sumLight += Input.GetAxis("Mouse ScrollWheel") * 100;
                    if(LightRange+sumLight <= THERESOLD && LightRange+sumLight >= MINTHERESOLD)
                        light.range = LightRange + sumLight;

                }
                if(light.range == THERESOLD)
                {
                    //等于阈值时获得炬字
                    if(!wordList.isObtainItem(word_Torch))
                    {
                        wordList.itemList.Add(word_Torch);
                        for (int i = 0; i < playerInventory.itemList.Count; i++)
                        {
                            if (playerInventory.itemList[i] == null)
                            {
                                playerInventory.itemList[i] = word_Torch;
                                break;
                            }
                        }
                        InventroyManager.RefreshItem();
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
