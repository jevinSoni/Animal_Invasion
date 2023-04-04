using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    public Camera myCamera;
    private GameObject defenderParent;
    private StarDisplay starDisplay;

    private void Start()
    {
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();
        defenderParent = GameObject.Find("Defenders");
        if (!defenderParent)
        {
            defenderParent = new GameObject("Defenders");
        }
    }
    private void OnMouseDown()
    {
        Vector2 pos = SnapToGrid(CalculateWorldPointToMouseClick());
        GameObject defender = Button.selectedDefender;
        int defenderCost = defender.GetComponent<Defenders>().starCost;
        if(starDisplay.UseStars(defenderCost) == StarDisplay.status.SUCCESS)
        {
            SpawnDefender(pos, defender);
        }
        else
        {
            Debug.Log("Low Cost");
        }
        
    }

    private void SpawnDefender(Vector2 pos, GameObject defender)
    {
        GameObject newDefendeer = Instantiate(defender, pos, Quaternion.identity);
        newDefendeer.transform.parent = defenderParent.transform;
    }

    //converting mouse click to world point
    Vector2 CalculateWorldPointToMouseClick()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY= Input.mousePosition.y ;
        float distanceFromCamera = 10f;
        Vector3 weirdTriplet = new Vector3(mouseX, mouseY, distanceFromCamera);
        Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTriplet);
        return worldPos;
    }
    //rounding wolrd mouse click position
    Vector2 SnapToGrid(Vector2 wolrdPos)
    {
        int posX = Mathf.RoundToInt(wolrdPos.x);
        int posY = Mathf.RoundToInt(wolrdPos.y);
        return new Vector2(posX, posY);
    }
}
