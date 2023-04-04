using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooseColider : MonoBehaviour
{
    private GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.GetComponent<Attackers>())
        {
            gm.LoadLevel("Loose");
        }
    }
}
