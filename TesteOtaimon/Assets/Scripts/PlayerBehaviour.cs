using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public static PlayerBehaviour instance;

    [SerializeField] private float playerSpeed = 5;
    Rigidbody2D rb;
    Vector2 move;
    public bool canWalk = true;
    //PurchasedItens
    public List<StoreItens> itensInStore = new List<StoreItens>();

    //Wallet
    public int coinYellow;
    public int coinRed;
    public int coinBlue;
    public int coinWhite;
    public int coinGreen;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one Player");
        }

        instance = this;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        move.x = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate()
    {
        if (canWalk)
        {
            rb.MovePosition(rb.position + move * playerSpeed * Time.fixedDeltaTime);
        }
    }
}
