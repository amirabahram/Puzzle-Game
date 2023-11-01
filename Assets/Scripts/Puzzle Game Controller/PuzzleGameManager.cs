using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleGameManager : MonoBehaviour
{
    [SerializeField]
    private PuzzleGameSaver saver;
    [SerializeField]
    private GameFinished gameFinished;
    [SerializeField]
    private List<Button> buttons = new List<Button>();
    [SerializeField]
    private List<Animator> puzzleButtonAnimators = new List<Animator>();
    [SerializeField]
    private List<Sprite> gamePuzzleSprites = new List<Sprite>();

    private Sprite puzzleBackgroundImage;
    private int level;
    private string selectedPuzzle;
    private bool firstGuess, secondGuess;
    private string firstGuessName, secondGuessName;
    private int firstGuessIndex, secondGuessIndex;
    private int guessCount, correctGuess, gameGuess;
    
    public void PickAPuzzle()
    {

        if (!firstGuess)
        {
            firstGuess = true;
            int btnNum = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            firstGuessIndex = btnNum;
            StartCoroutine(TurnUpPuzzle(puzzleButtonAnimators[btnNum], buttons[btnNum], gamePuzzleSprites[btnNum]));
            firstGuessName = gamePuzzleSprites[btnNum].name;
        }else if(!secondGuess) {
         secondGuess = true;
            int btnNum = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            secondGuessIndex = btnNum;
            StartCoroutine(TurnUpPuzzle(puzzleButtonAnimators[btnNum], buttons[btnNum], gamePuzzleSprites[btnNum]));
            secondGuessName = gamePuzzleSprites[btnNum].name;
            StartCoroutine(CheckIfSelectedPuzzlesMatch());
            guessCount++;
        }

    }
    public List<Animator> ResetGameplay()
    {
        firstGuess = secondGuess = false;
        guessCount = correctGuess = 0;
        return puzzleButtonAnimators;
        
    }
    IEnumerator CheckIfSelectedPuzzlesMatch()
    {
        yield return new WaitForSeconds(1.7f);
        if (firstGuessName.Equals(secondGuessName))
        {
            puzzleButtonAnimators[firstGuessIndex].Play("FadeOut");
            puzzleButtonAnimators[secondGuessIndex].Play("FadeOut");
            CheckIfGameIsFinished();
        }
        else
        {
            StartCoroutine(TurnBackPuzzle(puzzleButtonAnimators[firstGuessIndex],
                buttons[firstGuessIndex], puzzleBackgroundImage));
            StartCoroutine(TurnBackPuzzle(puzzleButtonAnimators[secondGuessIndex],
                buttons[secondGuessIndex], puzzleBackgroundImage));
            
        }
        yield return new WaitForSeconds(0.7f);
        firstGuess = secondGuess = false;
        
    }
    void CheckIfGameIsFinished()
    {
        correctGuess++;
        if (correctGuess == gameGuess) CheckHowManyGuess();
    }
    void CheckHowManyGuess()
    {
        int howManyGuess = 0;
        switch (level)
        {
            case 1: howManyGuess = 5; break;
            case 2: howManyGuess = 10; break;
            case 3: howManyGuess = 3;break;
            case 4: howManyGuess = 4;break;
            case 5: howManyGuess = 5;break;
        }
        if (guessCount < howManyGuess) {
            gameFinished.ShowGameFinishedPanel(3);
            saver.Save(level, selectedPuzzle, 3);
        }
        else if(guessCount<(howManyGuess+5)){
         gameFinished.ShowGameFinishedPanel(2);
            saver.Save(level, selectedPuzzle, 2);
        }
        else
        {
            gameFinished.ShowGameFinishedPanel(1);
            saver.Save(level, selectedPuzzle, 1);
        }
    }
    IEnumerator TurnUpPuzzle(Animator anim,Button btn,Sprite sprite)
    {
        anim.Play("TurnUp");
        yield return new WaitForSeconds(0.5f);
        btn.image.sprite = sprite;

    }
    IEnumerator TurnBackPuzzle(Animator anim, Button btn, Sprite sprite)
    {
        anim.Play("TurnBack");
        yield return new WaitForSeconds(0.5f);
        btn.image.sprite = sprite;
    }
    void AddListeners()
    {
        foreach (Button btn in buttons)
        {
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(() => PickAPuzzle());
        }
    }
    public void SetBackgroundImage(Sprite image)
    {
        this.puzzleBackgroundImage = image;
    }
    public void SetupButtonsAndAnimators(List<Button> buttons,List<Animator> animators)
    {
        this.buttons = buttons;
        this.puzzleButtonAnimators = animators;
        gameGuess = buttons.Count / 2;
        AddListeners();

    }

    public void SetPuzzleSprites(List<Sprite> puzzleSprites)
    {
        this.gamePuzzleSprites = puzzleSprites;
    }
    public void SetLevel(int level)
    {
        this.level = level;
    }
    public void SetSelectedPuzzle(string selectedPuzzle)
    {
        this.selectedPuzzle = selectedPuzzle;
    }
}
