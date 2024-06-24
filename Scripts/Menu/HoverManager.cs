using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class HoverManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI text;

    //public Color normalColor;
    //public Color hoverColor;

    public Image image;

    public AudioClip HoverSound;


    public void OnPointerEnter(PointerEventData eventData)
    {
        text.color = Color.green;
        image.rectTransform.localScale = new Vector2(1.1f, 1.1f);
        SoundManager.instance.PlaySound(HoverSound);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.color = Color.blue;
        image.rectTransform.localScale = Vector2.one;
    }
}
