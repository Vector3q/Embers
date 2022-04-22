using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    [Header("UI组件")]
    public Text textLabel;
    public Image faceimage;

    [Header("文本文件")]
    public TextAsset textFile;
    public int index;//编号
    public float textspeed;//用于控制字符的速度

    [Header("头像")]
    public Sprite face01, face02;

    bool textFinished;

    List<string> textList = new List<string>();//创建一个列表存储字符

    void Awake()
    {
        GetTextFromFile(textFile);
    }

    private void OnEnable()//一开始对话的时候会显示第一句话
    {
        //textLabel.text = textList[index];
        //index++;
        StartCoroutine(SetTextUI());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)&&index ==textList.Count)//代表文本结束了
        {
            gameObject.SetActive(false);//直接将文本框关闭
            index = 0;//序列归零
            return;
        }


       if(Input.GetKeyDown(KeyCode.R)&&textFinished)//按下R进行循环输出,并且判断这一行是否输出完了
        {
            //textLabel.text = textList[index];
            //index++;
            StartCoroutine(SetTextUI());
        }

    }

    void GetTextFromFile(TextAsset file)
    {
        //注意要先清空列表再来读取文档
        textList.Clear();
        index = 0;
        //text函数将会把文本转换为字符型的变量
        //var会自动识别类型
        var lineDate = file.text.Split('\n');//文本按行切割,切割后会变成一个字符型数组,我们只需要循环输出到list就形成了效果

        foreach(var line in lineDate)
        {
            textList.Add(line);//每一行加到列表当中
        }

    }

    IEnumerator SetTextUI()
    {
        textFinished = false;//代表开始打字了
        textLabel.text = "";//一开始要清空

        switch(textList[index])
        {
            case"A":
                    faceimage.sprite = face01;//我们不希望A显示在文本框中
                index++;
                break;
            case "B":
                faceimage.sprite = face02;//我们不希望B显示在文本框中
                index++;
                break;
        }



        for(int i = 0;i<textList[index].Length;i++)
        {
            textLabel.text += textList[index][i];//这一行的字符一个一个加上去显示

            yield return new WaitForSeconds(textspeed);
        }
        index++;
        textFinished = true;
    }
}
