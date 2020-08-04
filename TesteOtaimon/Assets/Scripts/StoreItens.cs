using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Store Item", menuName ="Store/Item")]
public class StoreItens : ScriptableObject
{
    public string productName;
    public Sprite productImage;
    public int productValue;
    public enum productType {yellowCoin, blueCoin, redCoin, whiteCoin, greenCoin};
    public productType thisType;
    public Sprite productTypeImage;
}
