using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinItem : MonoBehaviour
{

    UiController uiController;
    GameObject uiObj;
    [SerializeField] private GameObject outlineCoin;
    PlayerBehaviour stats;
    bool canGet;
    public enum coinTypes {yellowCoin, blueCoin, redCoin, whiteCoin, greenCoin};
    public coinTypes thisCoin = coinTypes.yellowCoin;

    void Start()
    {
        uiController = UiController.instance;
    }

    private void OnTriggerEnter2D(Collider2D playerCol)
    {
        if (playerCol.tag == "Player")
        {
            this.canGet = true;
            outlineCoin.SetActive(true);
            uiController.canInteract = true;
            stats = playerCol.GetComponent<PlayerBehaviour>();
        }
    }

    private void OnTriggerExit2D(Collider2D playerCol)
    {   
            if (playerCol.tag == "Player")
            {
                this.canGet = false;
                outlineCoin.SetActive(false);
                this.uiController.canInteract = false;
           }
    }

    private void Update()
    {
        if (this.canGet)
        {
            if (Input.GetButtonDown("Submit"))
            {
                switch (thisCoin)
                {
                    case coinTypes.yellowCoin:
                        stats.coinYellow++;
                        break;
                    case coinTypes.redCoin:
                        stats.coinRed++;
                        break;
                    case coinTypes.blueCoin:
                        stats.coinBlue++;
                        break;
                    case coinTypes.whiteCoin:
                        stats.coinWhite++;
                        break;
                    case coinTypes.greenCoin:
                        stats.coinGreen++;
                        break;
                }
                Destroy(gameObject);
            }
        }

        Destroy(gameObject, 5);
    }

    private void OnDestroy()
    {
        this.uiController.canInteract = false;
    }

}

   






