using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    //����enemy�����е����ԣ��˺���Ѫ��
    public int health;
    public int Attackdamage;
    //�ܵ�����֮����˸��ɫ��Ҫ�ı�������
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    //�ܵ�����֮����˸��ʱ��
    public float flashTime;

    // Start is called before the first frame update
    public void Start()
    {
        //����ʼ��ʱ��Ĭ�ϻ�ȡԭ������ɫ��Ϣ��һ���ǰ�ɫ��
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    // Update is called once per frame
    public void Update()
    {
        //�Ƿ��������ж�
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    //�ܵ��˺�֮��۳�Ѫ������˸
    public void TakeDamage(int damage)
    {
        health -= damage;
        flashColor(flashTime);
    }

    //�ܻ���˸����
    void flashColor(float time)
    {
        spriteRenderer.color = Color.red;
        //timeʱ��֮�����resetcolor����
        Invoke("resetColor", time);
    }

    //�ָ�ԭ������ɫ
    void resetColor()
    {
        spriteRenderer.color = originalColor;
    }
}
