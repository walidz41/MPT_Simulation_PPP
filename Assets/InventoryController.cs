using UnityEngine;

public class InventoryController : MonoBehaviour
{

    public GameObject inventoryPanel; // The UI panel that shows the inventory
    public GameObject slotPrefab; // A prefab for the inventory slots
    public int slotCount ; // Total number of inventory slots
    public GameObject[] itemPrefabs; // Array to hold references to the slot GameObjects
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < slotCount; i++)
        {
            Slot slot = Instantiate(slotPrefab, inventoryPanel.transform).GetComponent<Slot>();
            if (i< itemPrefabs.Length)
            {
                GameObject item = Instantiate(itemPrefabs[i], slot.transform);
                item.GetComponent<RectTransform>().anchoredPosition = Vector2.zero; // Center the item in the slot
                slot.currentItem = item; // Set the current item in the slot}
        }
    }
}
}