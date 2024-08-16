using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    #region Singolton

    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("MORE THEN ONE INSTANCE OF CHARACTER INVENTORY FOUND!!");
            return;
        }
        instance = this;
    }

    #endregion

    #region public variables
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 10;
    public List<Items> Items = new List<Items>();
    #endregion

    #region methods
    public bool Add (Items item)
    {
        if (item.isDefaultItem == false)
        {
            if (Items.Count >= space)
            {
                Debug.Log("Not enough room.");
                return false;
            }
            Items.Add(item);

            if (onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }
            
        }
        return true;
    }

    public void Remove (Items item)
    {
        Items.Remove(item);
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
    #endregion
}
