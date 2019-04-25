using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    [Tooltip("List of Canister Doors for the WAD. Uses Door scripts as the basis so it requires this.")]
    [SerializeField]
    private List<Door> puzzleDoors;

    /// <summary>
    /// Checks if all the doors are open
    /// </summary>
    /// <returns>Returns true if alldoors are open or false if any are closed</returns>
    private bool CheckIfAllDoorsAreOpen()
    {
        bool areAllDoorsOpen = true;
        foreach (var item in puzzleDoors)
        {
            if(!item.IsOpen)
            {
                areAllDoorsOpen = false;
                break;
            }
        }
        return areAllDoorsOpen;
    }
}
