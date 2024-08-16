using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Player", menuName = "Inventory/Player")]
public class PlayersItem :Items
{
    #region private variables
    bool hasUsed = false;
    #endregion

    #region public variables
    public int playerNumber;

    #endregion


    #region methods
    public override void Use()
    {
        FindObjectOfType<SpawnManager>().SetLocation(playerNumber);
        
        base.Use();

    }
    #endregion
}
