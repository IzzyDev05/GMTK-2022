using System.Collections.Generic;
using UnityEngine;

public class SpecificItemSpawner : MonoBehaviour
{
    [SerializeField] private List<ItemTypesSO> itemScriptableObject = new List<ItemTypesSO>();
    [SerializeField] private GameObject itemBase;

    /*
        0: NormalMovements
        1: Invincible
        2: AddLife
        3: RemoveLife
    */
    private int itemType;
    private ItemTypesSO item;
    private PlayerManager playerManager;
    private PlayerCollisionManager playerCollisionManager;
    private PlayerGridMovement playerGridMovement;
    
    private void Start() {
        playerManager = FindObjectOfType<PlayerManager>();
        playerGridMovement = FindObjectOfType<PlayerGridMovement>();
    }

    public void SpawnItem(GameObject point) {
        var obj = Instantiate(itemBase, point.transform.position, Quaternion.identity, point.transform);

        var rand = Random.Range(0, 100);
        if (rand <= 10) {
            itemType = 1;
        } 
        else if (rand > 10 && rand <= 30) {
            itemType = 3;
        } 
        else if (rand > 30 && rand <= 60) {
            itemType = 2;
        } 
        else {
            itemType = 0;
        }

        item = itemScriptableObject[itemType];
        obj.gameObject.name = item.itemName;
        obj.GetComponent<SpriteRenderer>().sprite = item.itemSprite;
        obj.GetComponent<SpriteRenderer>().color = item.spriteColor;
        obj.gameObject.tag = item.name;
    }
}