using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //SpawnCoins
    public bool canSpawn;
    [SerializeField] private GameObject[] coinsPrefab;
    private Vector2 screenBounds;
    float cooldown;
    private GameObject playerObj;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one UICONTROLLER");
        }

        instance = this;

        //Add UI Scene
        if (SceneManager.GetSceneByName("UI").isLoaded == false)
            SceneManager.LoadSceneAsync("UI", LoadSceneMode.Additive);
        else
            SceneManager.UnloadSceneAsync("UI");

        //GetScreenBounds
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    private void Start()
    {
        canSpawn = true;
        playerObj = PlayerBehaviour.instance.gameObject;
    }
    private void Update()
    {
        if(canSpawn)
        {
            cooldown -= Time.deltaTime;
            if (cooldown <= 0)
            {
                Spawner();
            }
        }
    }


    void Spawner()
    {
        int randomCoin = Random.Range(0, coinsPrefab.Length);
        GameObject coin = Instantiate(coinsPrefab[randomCoin]);
        coin.transform.position = new Vector2(Random.Range(-screenBounds.x +3f, screenBounds.x -3f), playerObj.transform.position.y - 1.2f);
        cooldown = 2.5f;
    }

}
