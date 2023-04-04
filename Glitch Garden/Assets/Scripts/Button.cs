using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    private Text costText;
    public GameObject defenderPrefab;
    public static GameObject selectedDefender;
    
    private Button[] buttonArray;
    private void Start()
    {
        costText = gameObject.GetComponentInChildren<Text>();
        if(!costText)
        {
            Debug.LogWarning("Cost is not set");
        }
        costText.text = defenderPrefab.GetComponent<Defenders>().starCost.ToString();
        buttonArray = GameObject.FindObjectsOfType<Button>();
    }
    private void Update()
    {
        
    }
    private void OnMouseDown()
    {
        foreach (Button thisButton in buttonArray)
        {
            thisButton.GetComponent<SpriteRenderer>().color = Color.black;
        }
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        selectedDefender = defenderPrefab;
    }

}
