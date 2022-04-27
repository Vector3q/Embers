using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    //所有enemy都具有的特性，伤害和血量
    public int maxhealth;
    public int health;
    public int Attackdamage;
    //受到攻击之后闪烁红色需要的变量数据
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    //受到攻击之后闪烁的时间
    public float flashTime;

    //获取血量脚本的相关参数
    private PlayerHealthController playerHealth;

    // Start is called before the first frame update
    public void Start()
    {
        health = maxhealth;
        //获取玩家血量的脚本，用于制造伤害
        playerHealth=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthController>();

        //程序开始的时候默认获取原来的颜色信息（一般是白色）
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    // Update is called once per frame
    public void Update()
    {
        //是否死亡的判定
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    //受到伤害之后扣除血量和闪烁
    public virtual void TakeDamage(int damage)
    {
        health -= damage;
        flashColor(flashTime);
    }

    //受击闪烁函数
    void flashColor(float time)
    {
        spriteRenderer.color = Color.red;
        //time时间之后调用resetcolor方法
        Invoke("resetColor", time);
    }

    //恢复原本的颜色
    void resetColor()
    {
        spriteRenderer.color = originalColor;
    }

    //敌人的攻击的碰撞框碰到player的时候触发
    protected void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")&&other.GetType().ToString()=="UnityEngine.BoxCollider2D")
        {
            if (playerHealth != null)
            {
                playerHealth.HeartPlayer(Attackdamage);
            }
        }
    }
}
