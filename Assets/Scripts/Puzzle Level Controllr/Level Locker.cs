using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelLocker : MonoBehaviour
{
    [SerializeField]
    PuzzleGameSaver puzzleGameSaver;
    [SerializeField]
    GameObject[] lockers;

    [SerializeField]
    private LevelStars levelStars;

    private bool[] candyLocks = new bool[5] {true,false,false,false,false};
    private bool[] transportLocks = new bool[5] { true, false, false, false, false };
    private bool[] fruitsLocks = new bool[5] { true, false, false, false, false };

    private string puzzleName;

    void GetLockes()
    {
        for (int i = 0; i < candyLocks.Length; i++)
        {

            candyLocks[i] = puzzleGameSaver.candyPuzzlevels[i];
            transportLocks[i] = puzzleGameSaver.transportPuzzleLevels[i];
            fruitsLocks[i] = puzzleGameSaver.fruitsPuzzleLevels[i];

        }
    }
    public void ActivateLockers()
    {
        foreach (GameObject locker in lockers)
        {
            locker.SetActive(true);
        }
    }
    public void CheckWichLevelsUnlocked(string puzzleName)
    {
        GetLockes();
        this.puzzleName = puzzleName;
        switch (this.puzzleName)
        {
            case "Candy Button":

                for (int i = 0; i < candyLocks.Length; i++)
                {

                    if (candyLocks[i])
                    {
                        lockers[i].SetActive(false);

                        levelStars.ActivateStars(i + 1, puzzleName);
                    }

                }
                break;
        
        
            case "Transport Button":

                for (int i = 0; i < transportLocks.Length; i++)
                {

                    if (transportLocks[i])
                    {
                        lockers[i].SetActive(false);
                        levelStars.ActivateStars(i+1, puzzleName);
                    }

                }
                break;
            case "Fruit Button":
                for (int i = 0; i < fruitsLocks.Length; i++)
                {

                    if (fruitsLocks[i])
                    {
                        lockers[i].SetActive(false);
                        levelStars.ActivateStars(i + 1, puzzleName);
                    }

                }


                break;
    }


}
    public bool[] GetSelectedPuzzleLocks()
    {
        switch (puzzleName)
        {
            case "Candy Button":
                return this.candyLocks;
            case "Transport Button":
                return this.transportLocks;
            case "Fruit Button":
                return this.fruitsLocks;
            default: return null;
        }
       
    }
}
