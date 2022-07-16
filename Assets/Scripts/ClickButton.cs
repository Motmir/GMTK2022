using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image img;
    [SerializeField] private Sprite defaultB; 
    [SerializeField] private Sprite pressed;
    // [SerializeField] private AudioClip compressClip;
    // [SerializeField] private AudioClip uncompressClip;
    // [SerializeField] private AudioSource source;


    public void OnPointerDown(PointerEventData eventData)
    {
        img.sprite = pressed;
        // source.PlayOneShot(compressClip);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        img.sprite = defaultB;
        // source.PlayOneShot(uncompressClip);
    }


}
