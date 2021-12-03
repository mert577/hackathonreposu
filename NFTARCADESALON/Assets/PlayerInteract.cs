using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public GameObject interactedObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (interactedObject != null)
        {

            

            if (Input.GetKeyDown(KeyCode.E))
            {
                interactedObject.GetComponent<ArcadeMachine>().Interaction();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ArcadeMachine"))
        {
            interactedObject = collision.gameObject;
            interactedObject.GetComponent<ArcadeMachine>().Highlight();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(interactedObject== collision.gameObject)
        {
            interactedObject.GetComponent<ArcadeMachine>().UnHighlight();
            interactedObject = null;

        }
    }
}
