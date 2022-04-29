using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;//单例模式可以让这个脚本中任何public变量，在其他脚本中都可以直接调用

    public string password;//判断我们player的密码是否和场景的密码一样，是的话转换
    //即场景A的exit脚本变量：密码和场景B的Entrence脚本变量：密码一样,角色进入场景B并出现在正确的位置
    //速度
    public float speed;
    //背包
    public GameObject bag;
    //人物所携带的物体
    public Item Equipment_weapon;
    //背包中选中的物体
    static public Item Selected_Equipment;
    //合成界面
    public Plane synthesisPlane;
    //是否可以交互
    public bool interactive;
    //是否正在交互
    public bool isInteracting;
    //背包是否打开
    bool isOpen;
    //动画管理器
    public Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);
    //是否在行走
    bool isRunning;

    //角色刚体
    Rigidbody2D rigidbody2d;
    
    Vector3 movement;

    float horizontal;
    float vertical;

    //原本物体的Scale信息
    float ScaleX;
    float ScaleY;  
    float ScaleZ;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else//如果这个场景已经存在一个PlayerController脚本了
        {
            if(instance!=this)
            {
                Destroy(gameObject);//保证游戏中永远只有一个playercontroller脚本
            }
            DontDestroyOnLoad(gameObject);//保证在场景转换中该脚本存在于任何场景中，不会因为加载新的场景就消失不见
        }
    }
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //初始设置为站立
        isRunning = false;
        //获取原本的主角scale信息
        ScaleX = transform.localScale.x;
        ScaleY = transform.localScale.y;
        ScaleZ = transform.localScale.z;

        interactive = false;
        isInteracting = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (!isInteracting)
        {*/
            FlipX();
            Move();
            OpenMyBag();
        /*}*/
    }


    /*void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }*/


    //行走的函数
    void Move()
    {
        //获取x和y轴的变量
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //判断是否正在跑步（在其他动画转跳的时候需要）
        if (horizontal != 0 || vertical != 0)
            isRunning = true;
        else if (horizontal == 0&&vertical==0)
            isRunning=false;

        //把朝向和是否正在跑步的信息传给animator
        animator.SetFloat("MoveX", horizontal);
        animator.SetFloat("MoveY", vertical);
        animator.SetBool("Running", isRunning);

        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;
        rigidbody2d.MovePosition(position);       

    }

    //将人物的模型和动画进行翻面,x轴翻面
    void FlipX()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        //检测玩家是否有速度
        bool PlayerHasSpeed = horizontal != 0 || vertical != 0;

        if(PlayerHasSpeed)
        {
            if (horizontal > 0.01f)
            {
                //默认是左边
                transform.localScale = new Vector3(ScaleX, ScaleY, ScaleZ);
            }
            if(horizontal<-0.01f)
            {
                transform.localScale = new Vector3(-ScaleX, ScaleY, ScaleZ);
            }

        }
    }

    public void SitDown()
    {
            //设置动画
            animator.SetBool("SittingDown", true);
            isInteracting = true;
    }


    /// <summary>
    /// M键打开关闭背包
    /// </summary>
    /// 
    void OpenMyBag()
    {
        //按下M键打开背包
        if(Input.GetKeyDown(KeyCode.M))
        {
            isOpen = !isOpen;
            bag.SetActive(isOpen);
        }
        //按下Esc键关闭背包
        if(Input.GetKeyDown(KeyCode.Escape) && isOpen)
        {
            isOpen = false;
            bag.SetActive(isOpen);
        }
    }
    /// <summary>
    /// 检测是否有使用特殊物品
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public bool isSpecial(Item item)
    {
        if (item.itemName == "paper")
            return true;
        return false;
    }
    /// <summary>
    /// Use按键替换player携带的武器
    /// </summary>
    public void EquipmentReplace()
    {
        if(!isSpecial(Selected_Equipment) && !DetectSpecial.Detected)//所选物品不是特殊物体并且合成界面未打开
            Equipment_weapon = Selected_Equipment;
    }
}
