using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverManagerForStage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public AudioClip HoverSound;
    public Image image;
    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = new Color(1, 1, 1, 0.7f);
        SoundManager.instance.PlaySound(HoverSound);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = new Color(1, 1, 1, 1);
    }
}
