using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Image backgournd;
    [SerializeField] private float alpha;//用alpha控制image的透明度改变

    private void Start()
    {
        StartCoroutine(FadeIn());

    }
    public void FadeTo()
    {
        StartCoroutine(FadeOut());
    }

    public void FadeTo(string _scenename)
    {
        StartCoroutine(FadeOut(_scenename));
    }
    IEnumerator FadeIn()
    {
        alpha = 1;
        while (alpha>0)
        {
            alpha-=Time.deltaTime;
            backgournd.color=new Color(0,0,0,alpha);
            yield return new WaitForSeconds(0);//等一秒执行
        }
    }

    IEnumerator FadeOut()//这是点击开始游戏之后的淡入效果
    {
        alpha = 0;
        while (alpha<0)
        {
            alpha += Time.deltaTime;
            backgournd.color = new Color(0, 0, 0, alpha);
            yield return new WaitForSeconds(0);
        }
    }

    IEnumerator FadeOut(string SceneName)
    {
        alpha = 0;
        while (alpha<0)
        {
            alpha += Time.deltaTime;
            backgournd.color = new Color(0, 0, 0, alpha);
            yield return new WaitForSeconds(0);
        }
        SceneManager.LoadScene(SceneName);

    }

}
