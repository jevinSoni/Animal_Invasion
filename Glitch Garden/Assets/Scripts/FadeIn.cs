using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public float fadeInTime;
    public Image fadePanel;
    public Color currentColour=Color.black;
    void Start()
    {
        fadePanel = gameObject.GetComponent<Image>();
    }

    void Update()
    {
        if(Time.timeSinceLevelLoad<fadeInTime)
        {
            float alphaColour = Time.deltaTime / fadeInTime;
            currentColour.a -= alphaColour;
            fadePanel.color = currentColour;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
