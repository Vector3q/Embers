using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class SynthesisEnd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(disappear());
    }
    public IEnumerator disappear()
    {
        //Thread.Sleep(2000);
        //transform.gameObject.SetActive(false);
        yield return new WaitForSeconds(0);
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
