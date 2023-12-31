using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupPuzzleGame : MonoBehaviour
{
    [SerializeField]
    private PuzzleGameManager puzzleGameManager;
    private Sprite[] candyImges, transportImages, fruitImages;
    [SerializeField]
    private List<Sprite> gamePuzzles = new List<Sprite>();
    private List<Button> puzzleButtons = new List<Button>();
    private List<Animator> puzzleButtonsAnimators = new List<Animator>();
    private int level;
    private string selectedPuzzle;
    private int looper;


    private void Awake()
    {
        candyImges = Resources.LoadAll<Sprite>("Game Assets/Candy");
        transportImages = Resources.LoadAll<Sprite>("Game Assets/Transport");
        fruitImages = Resources.LoadAll<Sprite>("Game Assets/Fruits");

    }
    void PrepareGameSprites()
    {
        gamePuzzles.Clear();
        gamePuzzles = new List<Sprite>();
        int index = 0;
        switch (level)
        {
            case 1:
                looper = 6;
                break;
            case 2:
                looper = 12;
                break;
            case 3:
                looper = 18;
                break;
            case 4:
                looper = 24;
                break;
            case 5:
                looper = 30;
                break;
        }
        switch (selectedPuzzle)
        {
            case "Candy Button":
                for(int i = 0; i < looper; i++)
                {
                    if (index == looper/2) index = 0;
                    gamePuzzles.Add(candyImges[index]);
                    index ++;
                }
                break;
            case "Transport Button":
                for (int i = 0; i < looper; i++)
                {
                    if (index == looper / 2) index = 0;
                    gamePuzzles.Add(transportImages[index]);
                    index++;
                }
                break;
            case "Fruit Button":
                for (int i = 0; i < looper; i++)
                {
                    if (index == looper / 2) index = 0;
                    gamePuzzles.Add(fruitImages[index]);
                    index++;
                }
                break;
        }
        Shuffle(gamePuzzles);
    }
    void Shuffle(List<Sprite> list)
    {
        for(int i=0; i<list.Count; i++)
        {
            int randomIndex = Random.Range(0, list.Count);
            Sprite temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
    public void SetLevelAndPuzzle(int level,string selectedPuzzle)
    {
        this.level = level;
        this.selectedPuzzle = selectedPuzzle;
        PrepareGameSprites();
        puzzleGameManager.SetPuzzleSprites(this.gamePuzzles);
    }
    public void SetPuzzleButtonsAndAnimators(List<Button> puzzleButtons,List<Animator> puzzleButtonsAnimators)
    {
        this.puzzleButtons = puzzleButtons;
        this.puzzleButtonsAnimators = puzzleButtonsAnimators;
        puzzleGameManager.SetupButtonsAndAnimators(puzzleButtons, puzzleButtonsAnimators);
    }
}
