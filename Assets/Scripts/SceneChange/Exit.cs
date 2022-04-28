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
            PlayerController.instance.password = newScenePassword;//�����뿪����һʱ������һ�����һ�����룬Ȼ���˳������ж������Ƿ����
            //�������һ����ת��
            //SceneManager.LoadScene(sceneName);
            FindObjectOfType<SceneFader>().FadeTo(sceneName);
        }
    }
}
