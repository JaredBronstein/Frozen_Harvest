using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puzzle : InteractiveObject
{
    [Tooltip("List of Canister Doors for the WAD. Uses Door scripts as the basis so it requires this.")]
    [SerializeField]
    private List<Door> puzzleDoors;

    [Tooltip("List of Levers for the WAD. Uses Lever scripts as the basis so it requires this.")]
    [SerializeField]
    private List<Lever> puzzleLevers;

    [Tooltip("The scene the game goes to when it's complete.")]
    [SerializeField]
    private string gameSceneName;

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

    /// <summary>
    /// Checks if all Levers are in their correct positions
    /// </summary>
    /// <returns>Returns true if the levers are all in the correct place, otherwise returns false</returns>
    private bool CheckIfAllLeversAreCorrect()
    {
        bool areAllLeversCorrect = true;
        foreach (var item in puzzleLevers)
        {
            if(!item.IsLeverCorrect)
            {
                areAllLeversCorrect = false;
                break;
            }
        }
        return areAllLeversCorrect;
    }

    public override void InteractWith()
    {
        base.InteractWith();
        if(CheckIfAllDoorsAreOpen() && CheckIfAllLeversAreCorrect())
        {
            SceneManager.LoadScene(gameSceneName);
        }
    }
}
