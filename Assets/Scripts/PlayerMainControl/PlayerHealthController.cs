using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public int health;
    public int maxhealth;
    public int numBlinks;
    public float BlinksTime;

    private Renderer myRenderer;

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //角色受到伤害的时候调用的函数
    public void HeartPlayer(int damage)
    {
        health-=damage;
        PlayerBlinks(numBlinks, BlinksTime);
        if(health<=0)
        {
            Destroy(gameObject);
        }
    }

    //角色受伤的时候会多次或者一次闪烁红色，每次second秒
    void PlayerBlinks(int numBlinks,float seconds)
    {
        StartCoroutine(DoBlinks(numBlinks,seconds));
    }

    //闪烁的携程
    IEnumerator DoBlinks(int numBlinks,float seconds)
    {
        //变红一次，回来一次，算是一次闪烁
        for (int i = 0; i < numBlinks * 2; i++)
        {
            myRenderer .enabled = !myRenderer .enabled;
            yield return new WaitForSeconds(seconds);
        }
        myRenderer.enabled = true;
    }
}
