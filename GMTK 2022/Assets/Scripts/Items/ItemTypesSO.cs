using UnityEngine;

public enum Itemtype {
    NormalMovements,
    Invincible,
    AddLife,
    RemoveLife
};

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class ItemTypesSO : ScriptableObject
{
    public string itemName;
    //public Sprite itemSprite;
    //public Color spriteColor;
    public GameObject itemPrefab;
    public Itemtype itemType;    
}