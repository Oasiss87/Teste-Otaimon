using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ShopNpc : MonoBehaviour
{
    UiController uiController;
    bool canBuy;

    private void Start()
    {
        uiController = UiController.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            canBuy = true;
            uiController.canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canBuy = false;
            uiController.canInteract = false;
        }
    }

    private void Update()
    {
        if (this.canBuy)
        {
            if (Input.GetButtonDown("Submit"))
            {
                uiController.OpenStore();
            }
        }
    }
}
