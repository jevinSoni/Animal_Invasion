using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    private Text starText;
    private int stars=100;
    public enum status { SUCCESS, FAILURE };

    private void Start()
    {
        starText = gameObject.GetComponent<Text>();
        UpdateDisplay();
    }
    public void AddStars(int amount)
    {
        stars += amount;
        UpdateDisplay();
    }
    public status UseStars(int amount)
    {
        if (stars >= amount)
        {
            stars -= amount;
            UpdateDisplay();
            return status.SUCCESS;
        }
        return status.FAILURE;
    }
    private void UpdateDisplay()
    {
        starText.text = stars.ToString();
    }
}
