using UnityEngine;

public class ItemPickUp : Interactable
{
    #region public variables
    public Items Item;
    #endregion

    #region methods
    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Picking up " + Item.name);
        bool wasPickedUp = Inventory.instance.Add(Item); 

        if (wasPickedUp == true)
        {
            gameObject.SetActive(false);
        }

    }
    #endregion
}
