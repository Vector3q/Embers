using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_monochange : Dialog
{
    // Start is called before the first frame update

    public void Awake()
    {
        base.Awake();
    }

    public void OnEnable()
    {
        base.OnEnable();
    }

    public void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.R) && isOver)//代表文本结束了
        {
            GameObject.Find("ScenceFade").GetComponent<SceneFader>().FadeTo("C01S02");
            return;
        }


    }



}
