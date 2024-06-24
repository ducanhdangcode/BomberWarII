using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
    [SerializeField] private RawImage img;
    [SerializeField] private float _x;
    [SerializeField] private float _y;

    private void Update()
    {
        img.uvRect = new Rect(img.uvRect.position + new Vector2(_x, _y), img.uvRect.size);
    }
}
