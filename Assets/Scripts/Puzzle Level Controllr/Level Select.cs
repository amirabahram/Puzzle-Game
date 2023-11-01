using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    [SerializeField]
    LevelLocker levelLocker;
    [SerializeField]
    private PuzzleGameManager puzzleGameManager;
    [SerializeField]
    private LoadPuzzleGame loadPuzzleGame;
    [SerializeField]
    private GameObject puzzleSelectPanel, levelSelectPanel;

    [SerializeField]
    private Animator puzzleAnimator, levelAnimator;

    private bool[] selectedLevelLocks;

    private string selectedpuzzle;
    public void BackToPuzzle()
    {
        StartCoroutine(BackToPuzzleSelect());
    }
    public void SelectLevel()
    {
        int levelNum = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        selectedLevelLocks = levelLocker.GetSelectedPuzzleLocks();
        if (selectedLevelLocks[levelNum-1])
        {
            puzzleGameManager.SetLevel(levelNum);
            loadPuzzleGame.LoadPuzzle(levelNum, selectedpuzzle);
        }


    }
    IEnumerator BackToPuzzleSelect()
    {
        puzzleSelectPanel.SetActive(true);
        puzzleAnimator.Play("SlideIn");
        levelAnimator.Play("SlideOut");
        yield return new WaitForSeconds(1f);
        levelSelectPanel.SetActive(false);

    }
    public  void SetSelectedPuzzleName(string selectedpuzzle)
    {
        this.selectedpuzzle = selectedpuzzle;
    }
}
