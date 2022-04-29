using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipsController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DIS());
    }

    IEnumerator DIS()
    {
        yield return new WaitForSecondsRealtime(1f);
        Debug.Log("Print");
        Destroy(gameObject);
    }
}
