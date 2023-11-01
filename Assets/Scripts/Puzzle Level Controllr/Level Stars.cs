using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStars : MonoBehaviour
{
    [SerializeField]
    PuzzleGameSaver gameSaver;
    [SerializeField]
    GameObject[] level1Stars, level2Stars,level3Stars,level4Stars,level5Stars;
    private int[] candyStars=new int[5];
    private int[] transportStars=new int[5];
    private int[] fruitsStars=new int[5];

    void GetStars()
    {
        for (int i = 0; i < candyStars.Length; i++)
        {
            candyStars[i] = gameSaver.candyPuzzlevelsStars[i];
            transportStars[i] = gameSaver.transportPuzzleLevelsStars[i];
            fruitsStars[i] = gameSaver.fruitsPuzzleLevelsStars[i];

        }
    }
    public void DeActiveStars()
    {
        for(int i = 0;i < level1Stars.Length; i++)
        {
            level1Stars[i].SetActive(false);
            level2Stars[i].SetActive(false);
            level3Stars[i].SetActive(false);
            level4Stars[i].SetActive(false);
            level5Stars[i].SetActive(false);
        }
    }
    public void ActivateStars(int level,  string puzzleName)
    {
        GetStars();
        switch (puzzleName)
        {
            case "Candy Button":
                ActivateStars(level, candyStars[level-1]);
                break;
            case "Transport Button":
                ActivateStars(level, transportStars[level - 1]);
                break;
            case "Fruit Button":
                ActivateStars(level, fruitsStars[level - 1]);
                break;

        }
    }
    void ActivateStars(int level,int stars)
    {
        
        switch (level)
        {
            case 1:
                for (int i = 0; i < stars; i++) 
                {
                    level1Stars[i].SetActive(true);
                }
                
                break;
            case 2:
                for (int i = 0; i < stars; i++)
                {
                    level2Stars[i].SetActive(true);
                }
                break;
            case 3:
                for (int i = 0; i < stars; i++)
                {
                    level3Stars[i].SetActive(true);
                }
                break;
           case 4:
                for (int i = 0; i < stars; i++)
                {
                    level4Stars[i].SetActive(true);
                }
                break;
            case 5:
                for (int i = 0; i < stars; i++)
                {
                    level5Stars[i].SetActive(true);
                }
                break;


        }
    }

}
