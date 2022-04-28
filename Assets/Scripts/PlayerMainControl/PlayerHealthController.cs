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

    //��ɫ�ܵ��˺���ʱ����õĺ���
    public void HeartPlayer(int damage)
    {
        health-=damage;
        PlayerBlinks(numBlinks, BlinksTime);
        if(health<=0)
        {
            Destroy(gameObject);
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
        //���һ�Σ�����һ�Σ�����һ����˸
        for (int i = 0; i < numBlinks * 2; i++)
        {
            myRenderer .enabled = !myRenderer .enabled;
            yield return new WaitForSeconds(seconds);
        }
        myRenderer.enabled = true;
    }
}
