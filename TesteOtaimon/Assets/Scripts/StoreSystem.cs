using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class StoreSystem : MonoBehaviour
{
    [SerializeField] private Transform itensPlace;
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private StoreItens[] itensRef;
    public List<GameObject> itensInStore = new List<GameObject>();
    public int itensBought;
    public int itemCount;
    GameObject lastselect;

    private void OnEnable()
    {
        GameManager.instance.canSpawn = false;
        PlayerBehaviour.instance.canWalk = false;
    }

    private void Start()
    {
        itemCount = Random.Range(3, 6);

        for (int i = 0; i < itensRef.Length; i++)
        {
            StoreItens itemToRandom = itensRef[i];
            int randomizeIndex = Random.Range(0, itensRef.Length);
            itensRef[i] = itensRef[randomizeIndex];
            itensRef[randomizeIndex] = itemToRandom;
        }

        for (int i = 0; i < itemCount; i++)
        {
            GameObject storeItemRef = Instantiate(itemPrefab, itensPlace);
            itensInStore.Add(storeItemRef);
            ItemUI itemRef = storeItemRef.GetComponent<ItemUI>();
            itemRef.itensSO = itensRef[i];
        }
        EventSystem.current.SetSelectedGameObject(itensInStore[0]);
    }

    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            if (itensBought != itemCount)
            {
                GameManager.instance.canSpawn = true;
            }
            PlayerBehaviour.instance.canWalk = true;
            gameObject.SetActive(false);

        }

        if (EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(lastselect);
        }
        else
        {
            lastselect = EventSystem.current.currentSelectedGameObject;
        }
    }
}
