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

    //��ɫ�ܵ��˺���ʱ����õĺ���
    public void HeartPlayer(int damage)
    {
        health = Mathf.Clamp(health - damage, 0, maxhealth);
        PlayerBlinks(numBlinks, BlinksTime);
        UIHealthBar.instance.SetValue(health / (float)maxhealth);
        if (health==0)
        {
            anim.SetTrigger("Dead");
            //һ��֮���ٴݻ���Ҷ���
            Destroy(gameObject,2.0f);
        }
    }

    //��ɫ���˵�ʱ����λ���һ����˸��ɫ��ÿ��second��
    void PlayerBlinks(int numBlinks,float seconds)
    {
        StartCoroutine(DoBlinks(numBlinks,seconds));
    }

    //��˸��Я��
    IEnumerator DoBlinks(int numBlinks,float seconds)
    {
        //͸��һ�Σ�����һ�Σ�����һ����˸
        for (int i = 0; i < numBlinks * 2; i++)
        {
            myRenderer .enabled = !myRenderer .enabled;
            yield return new WaitForSeconds(seconds);
        }
        myRenderer.enabled = true;
    }


}
