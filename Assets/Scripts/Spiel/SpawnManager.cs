
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    #region private variables
    
    #endregion

    #region public variables
    public GameObject currentPlayer;
    public GameObject[] players;
    #endregion

    #region methods
    public void SetLocation(int newPlayerNumber)
    {
        //set location of clicked charackter in Inventory to current Player and enable the new Player while disabling the old Player
        Debug.Log("Setting the Location");
        if (newPlayerNumber == 0)
        {
            players[newPlayerNumber].transform.position = currentPlayer.transform.position;
            currentPlayer.SetActive(false);
            players[newPlayerNumber].SetActive(true);
            players[newPlayerNumber] = currentPlayer;
        }

        if (newPlayerNumber == 1)
        {

            players[newPlayerNumber].transform.position = currentPlayer.transform.position;
            currentPlayer.SetActive(false);
            players[newPlayerNumber].SetActive(true);
            players[newPlayerNumber] = currentPlayer;
        }
    }

    #endregion
}
