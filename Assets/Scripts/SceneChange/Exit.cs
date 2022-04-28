using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public string sceneName;
    [SerializeField] private string newScenePassword;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerController.instance.password = newScenePassword;//我们离开场景一时，场景一会给出一个密码，然后到了场景二判断密码是否相符
            //如果密码一样就转换
            //SceneManager.LoadScene(sceneName);
            FindObjectOfType<SceneFader>().FadeTo(sceneName);
        }
    }
}
