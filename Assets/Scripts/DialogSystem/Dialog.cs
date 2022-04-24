using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{

    [Header("UI���")]
    public Text textLabel;
    public Image faceimage;

    [Header("�ı��ļ�")]
    public TextAsset textFile;
    public int index;//���
    public float textspeed;//���ڿ����ַ����ٶ�

    [Header("ͷ��")]
    public Sprite face01, face02;

    bool textFinished;//�Ƿ���ɴ���
    bool cancelTyping;//ȡ������

    List<string> textList = new List<string>();//����һ���б�洢�ַ�

    void Awake()
    {
        GetTextFromFile(textFile);
    }

    private void OnEnable()//һ��ʼ�Ի���ʱ�����ʾ��һ�仰
    {
        //textLabel.text = textList[index];
        //index++;
        textFinished = true;
        StartCoroutine(SetTextUI());//��ʼЭ��
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)&&index ==textList.Count)//�����ı�������
        {
            gameObject.SetActive(false);//ֱ�ӽ��ı���ر�
            if(gameObject!=null)
            index = 0;//���й���
            return;
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);//ֱ�ӽ��ı���ر�
            index = 0;//���й���
            return;
        }


       //if(Input.GetKeyDown(KeyCode.R)&&textFinished)//����R����ѭ�����,�����ж���һ���Ƿ��������
       // {
       //     //textLabel.text = textList[index];
       //     //index++;
       //     StartCoroutine(SetTextUI());
       // }
       if(Input.GetKeyDown(KeyCode.R))
        {
            if(textFinished&&!cancelTyping)
            {
                StartCoroutine(SetTextUI());
            }
            else if(!textFinished&&!cancelTyping)
            {
                cancelTyping = true;
            }
        }


    }

    void GetTextFromFile(TextAsset file)
    {
        //ע��Ҫ������б�������ȡ�ĵ�
        textList.Clear();
        index = 0;
        //text����������ı�ת��Ϊ�ַ��͵ı���
        //var���Զ�ʶ������
        var lineData = file.text.Split('\n');//�ı������и�,�и�����һ���ַ�������,����ֻ��Ҫѭ�������list���γ���Ч��

        foreach(var line in lineData)
        {
            textList.Add(line);//ÿһ�мӵ��б���
        }

    }

    IEnumerator SetTextUI()//������ഴ��һ��Э��
    {
        textFinished = false;//����ʼ������
        textLabel.text = "";//һ��ʼҪ���

        switch(textList[index].Trim().ToString())
        {
            case"A":
                    //faceimage.sprite = face01;//���ǲ�ϣ��A��ʾ���ı�����
                index++;
                break;
            case"B":
                //faceimage.sprite = face02;//���ǲ�ϣ��B��ʾ���ı�����
                index++;
                break;
        }



        //for(int i = 0;i<textList[index].Length;i++)
        //{
        //    textLabel.text += textList[index][i];//��һ�е��ַ�һ��һ������ȥ��ʾ

        //    yield return new WaitForSeconds(textspeed);
        //}
        int letter = 0;
        while(!cancelTyping&&letter<textList[index].Length-1)
        {
            textLabel.text+=textList[index][letter];
            letter++;
            yield return new WaitForSeconds(textspeed);
        }
        textLabel.text = textList[index];
        cancelTyping=false;
        textFinished = true;
        index++;

    }
}
