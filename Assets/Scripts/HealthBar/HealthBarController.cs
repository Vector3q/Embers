using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour
{
    public float timeInvincible = 2.0f;//无敌时间常量
    private bool isInvincible;
    private float invincibleTimer;//计时器
    PlayerHealthController playerhealthcontroller;
    //public int CurrentHealth { get => currentHealth; set => currentHealth = value; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
  
        public void ChangeHealth(int amount)
        {
            if (amount < 0)
            {
                if (isInvincible)
                {
                    return;
                }
                //收到伤害
                isInvincible = true;
                invincibleTimer = timeInvincible;
            }
            playerhealthcontroller.health = Mathf.Clamp(playerhealthcontroller.health + amount, 0, playerhealthcontroller.maxhealth);
            UIHealthBar.instance.SetValue(playerhealthcontroller.health / (float)playerhealthcontroller.maxhealth);
        }
   
}
