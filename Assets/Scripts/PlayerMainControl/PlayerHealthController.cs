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
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //角色受到伤害的时候调用的函数
    public void HeartPlayer(int damage)
    {
        health = Mathf.Clamp(health - damage, 0, maxhealth);
        PlayerBlinks(numBlinks, BlinksTime);
        UIHealthBar.instance.SetValue(health / (float)maxhealth);
        if (health==0)
        {
            anim.SetTrigger("Dead");
            //一秒之后再摧毁玩家对象
            Destroy(gameObject,2.0f);
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
        //透明一次，回来一次，算是一次闪烁
        for (int i = 0; i < numBlinks * 2; i++)
        {
            myRenderer .enabled = !myRenderer .enabled;
            yield return new WaitForSeconds(seconds);
        }
        myRenderer.enabled = true;
    }


}
