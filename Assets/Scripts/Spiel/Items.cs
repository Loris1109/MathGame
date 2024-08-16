
using UnityEngine;
[CreateAssetMenu(fileName = "New item", menuName = "Inventory/item")]
public class Items : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
    public bool hasBeenUsed = false;

    public virtual void Use ()
    {
        // Use the item
        Debug.Log("Using " + name);
        if (isDefaultItem == false)
        {
            RemoveFromInventory();
        }
        else
        {
            hasBeenUsed = true;
        }
        if (isDefaultItem == true && hasBeenUsed == true)
        {
            Debug.Log("not able to Use the Item");
        }

    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    } 
}
