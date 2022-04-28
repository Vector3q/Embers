using UnityEngine;

public class Getbutton : MonoBehaviour
{
    public GameObject Button_R;
    public GameObject Button_E_OR_I;
    public GameObject talkUI;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Button_R.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Button_R.SetActive(false);
        Button_E_OR_I.SetActive(false);
    }

    private void Update()
    {
        if (Button_R.activeSelf && Input.GetKeyDown(KeyCode.R))
        {
            talkUI.SetActive(true);
        }
        if(Dialog.isOver)
        {
            Button_E_OR_I.SetActive(true);
        }
    }
}
