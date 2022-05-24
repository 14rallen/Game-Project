using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScreen : MonoBehaviour
{
    private GameObject menus;
    private GameObject inventoryScreen;
    private bool inventoryIsOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        menus = gameObject.transform.Find("Menus").gameObject;
        inventoryScreen = menus.transform.Find("Inventory").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleInventory()
    {
        
        if(inventoryIsOpen)
        {
            inventoryScreen.SetActive(false);
            inventoryIsOpen = false;
        }
        else
        {
            inventoryScreen.SetActive(true);
            inventoryIsOpen = true;
        }
    }
}
