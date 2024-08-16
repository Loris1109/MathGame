using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{

    #region private variables
    Inventory inventory;
    #endregion

    #region public variables
    public Transform itemParent;
    #endregion

    ItemSlot[] slots;

    #region methods
    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;
        slots = itemParent.GetComponentsInChildren<ItemSlot>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.Items.Count)
            {
                slots[i].AddCharacter(inventory.Items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

    void UpdateUI()
    {
        Debug.Log("Updating UI");
    }

    #endregion
}
