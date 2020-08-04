using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public StoreItens itensSO;
    [SerializeField] private Image mainImage;
    [SerializeField] private Image typeImage;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text valueText;
    [SerializeField] private GameObject itemPuchased;
    private GameObject itemPurchasedRef;
    public StoreItens.productType thisTypeItem;
    PlayerBehaviour stats;
    UiController uiController;
    bool boughtProduct;
    StoreSystem storeSystem;

    void Start()
    {
        uiController = UiController.instance;
        storeSystem = GetComponentInParent<StoreSystem>();

        if (itensSO != null)
        {
            typeImage.sprite = itensSO.productTypeImage;
            nameText.text = itensSO.productName;
            valueText.text = "x " + itensSO.productValue.ToString();
            thisTypeItem = itensSO.thisType;
            mainImage.sprite = itensSO.productImage;
            stats = PlayerBehaviour.instance;
        }
    }

    public void clickButton()
    {
        if (!boughtProduct)
        {
            switch (thisTypeItem)
            {
                case StoreItens.productType.blueCoin:
                    if (stats.coinBlue >= itensSO.productValue)
                    {
                        BuyItem();
                        stats.coinBlue -= itensSO.productValue;
                    }
                    else
                    {
                        cantBuy();
                    }
                    break;

                case StoreItens.productType.yellowCoin:
                    if (stats.coinYellow >= itensSO.productValue)
                    {
                        BuyItem();
                        stats.coinYellow -= itensSO.productValue;
                    }
                    else
                    {
                        cantBuy();
                    }
                    break;
                case StoreItens.productType.redCoin:
                    if (stats.coinRed >= itensSO.productValue)
                    {
                        BuyItem();
                        stats.coinRed -= itensSO.productValue;
                    }
                    else
                    {
                        cantBuy();
                    }
                    break;

                case StoreItens.productType.whiteCoin:
                    if (stats.coinWhite >= itensSO.productValue)
                    {
                        BuyItem();
                        stats.coinWhite -= itensSO.productValue;
                    }
                    else
                    {
                        cantBuy();
                    }
                    break;

                case StoreItens.productType.greenCoin:
                    if (stats.coinGreen >= itensSO.productValue)
                    {
                        BuyItem();
                        stats.coinGreen -= itensSO.productValue;
                    }
                    else
                    {
                        cantBuy();
                    }
                    break;

            }
        }

    }

    void BuyItem()
    {
        GameObject itemPurchasedRef = Instantiate(itemPuchased, uiController.purchaseItensPlace);
        Image spriteItem = itemPurchasedRef.GetComponentInChildren<Image>();
        PlayerBehaviour.instance.itensInStore.Add(itensSO);
        spriteItem.sprite = itensSO.productImage;
        valueText.text = "Puchased";
        typeImage.gameObject.SetActive(false);
        storeSystem.itensBought++;
        boughtProduct = true;
    }

    void cantBuy()
    {
        Debug.Log("Not enouch cash"); //stranger
    }

}
