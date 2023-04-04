using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defenders : MonoBehaviour
{
    public int starCost=50;
    private StarDisplay starDisplay;
    private void Start()
    {
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();
    }
    private void AddStars(int amount)
    {
        starDisplay.AddStars(amount);
    }
}
