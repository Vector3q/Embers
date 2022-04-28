using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    public Image Mask;
    float originalSize;
    public static UIHealthBar instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        originalSize = Mask.rectTransform.rect.width;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetValue(float fillPercent)//设置当前UI血条显示值
    {
        Mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,
            originalSize * fillPercent);
    }
}
