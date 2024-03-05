using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Digging : MonoBehaviour
{

    public int veggiesCollected;
    public GameObject gameManager;

    //public GameObject ClickedObj;

    
    //public Animation animShovel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //when left mouse button pressed
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit,5)) //shoot ray
            {
                if (hit.collider.CompareTag("Mound")) //if it mound
                {
                    hit.collider.gameObject.GetComponent<Mound>().SpawnArtifact(); //spawn artifact
                    Debug.Log("D I G");
                }

                if(hit.collider.CompareTag("Vegetable")) //if hit veggie
                {
                    Destroy(hit.collider.gameObject); //destroy gameobject
                    veggiesCollected++; //add to veggies collected
                    if (veggiesCollected == 4)
                    {
                        gameManager.GetComponent<GameManager>().ShowCanvas(
                            "Good job on collecting all the vegetables. Head over to the mosque for a special gift. "); //do show canvas function with this text
                    }
                }

                if (hit.collider.CompareTag("Book")) //if hit book
                {
                    Destroy(hit.collider.gameObject);
                    gameManager.GetComponent<GameManager>().ShowCanvas(
                        "When you pick up the book, you feel a power from it. Your surroundings begin to change and you are not where you started.");
                }
                
            }
        }

     
    }
    
}
