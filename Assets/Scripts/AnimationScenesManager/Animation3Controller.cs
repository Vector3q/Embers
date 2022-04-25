using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Animation3Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obje;
    GameObject obj = null;
    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.FindGameObjectWithTag("sound");
        if (obj == null)
            obj = (GameObject)Instantiate(obje);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown) { SceneManager.LoadScene("C01S01"); }
    }
}
