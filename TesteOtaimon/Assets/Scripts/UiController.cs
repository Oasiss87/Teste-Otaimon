using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiController : MonoBehaviour
{
    public static UiController instance;
    [SerializeField] private TMP_Text yellowCoinText;
    [SerializeField] private TMP_Text blueCoinText;
    [SerializeField] private TMP_Text greenCoinText;
    [SerializeField] private TMP_Text whiteCoinText;
    [SerializeField] private TMP_Text redCoinText;
    [SerializeField] private GameObject ekeySprite;
    public bool canInteract;
    [SerializeField] private Vector3 offset;
    private PlayerBehaviour stats;
    [SerializeField] private GameObject storeUI;
    public Transform purchaseItensPlace;


    #region
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one UICONTROLLER");
        }

        instance = this;
    }

    #endregion

    void Start()
    {
        stats = PlayerBehaviour.instance;
    }

    // Update is called once per frame
    void Update()
    {
        yellowCoinText.text = "x " + stats.coinYellow.ToString();
        blueCoinText.text = "x " + stats.coinBlue.ToString();
        redCoinText.text = "x " + stats.coinRed.ToString();
        whiteCoinText.text = "x " + stats.coinWhite.ToString();
        greenCoinText.text = "x " + stats.coinGreen.ToString();

        if (canInteract)
        {
            Vector2 screenPos = Camera.main.WorldToScreenPoint(stats.transform.position + offset);
            ekeySprite.SetActive(true);
            ekeySprite.transform.position = screenPos;
        }
        else
        {
            ekeySprite.SetActive(false);
        }

    }

    public void OpenStore()
    {
        storeUI.SetActive(true);
    }
}
