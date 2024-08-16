
using UnityEngine;
using UnityEngine.UI;
public class ItemSlot : MonoBehaviour
{
    #region private variables
    Items item;
    #endregion

    #region public variables
    public Image icon;
    public Button removeButton;
    #endregion

    #region methods
    public void AddCharacter(Items newCharacter)
    {
        item = newCharacter;
        icon.sprite = item.icon;
        icon.enabled = true;
        
    }

    public void ClearSlot ()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        
    }

    public void UseCharacter()
    {
        if (item != null)
        {
            item.Use();
        }
    }
    #endregion
}
