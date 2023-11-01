using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LoadPuzzleGame : MonoBehaviour
{
    [SerializeField]
    LevelStars levelStars;
    [SerializeField]
    private LevelLocker levelLocker;
    [SerializeField]
    private PuzzleGameManager gameManager;
    [SerializeField]
    private GameFinished gameFinished;
    [SerializeField]
    private LayoutPuzzleButtons layoutPuzzleButtons;
    [SerializeField]
    private GameObject puzzleLevelSelectPanel;
    [SerializeField]
    private Animator puzzleLevelSelectAnim;
    [SerializeField]
    private GameObject puzzleGamePanel1, puzzleGamePanel2, puzzleGamePanel3, puzzleGamePanel4, puzzleGamePanel5;
    [SerializeField]
    private Animator puzzleGamePanelAnim1, puzzleGamePanelAnim2, puzzleGamePanelAnim3, puzzleGamePanelAnim4, puzzleGamePanelAnim5;

    private int puzzlelevel;
    private string puzzle;

    private List<Animator> anims;

    public void LoadPuzzle(int levelNume, string puzzle)
    {
        this.puzzlelevel = levelNume;
        this.puzzle = puzzle;

        layoutPuzzleButtons.LayoutButtons(puzzlelevel,puzzle);

        switch (puzzlelevel)
        {
            case 1:
                StartCoroutine(LoadPuzzleCoRoutine(puzzleGamePanel1, puzzleGamePanelAnim1));
                break;
            case 2:
                StartCoroutine(LoadPuzzleCoRoutine(puzzleGamePanel2, puzzleGamePanelAnim2));
                break;
            case 3:
                StartCoroutine(LoadPuzzleCoRoutine(puzzleGamePanel3, puzzleGamePanelAnim3));
                break;
            case 4:
                StartCoroutine(LoadPuzzleCoRoutine(puzzleGamePanel4, puzzleGamePanelAnim4));
                break;
            case 5:
                StartCoroutine(LoadPuzzleCoRoutine(puzzleGamePanel5, puzzleGamePanelAnim5));
                break;
        }
    }
    public void BackFromPuzzleToLevelMenu()
    {
        gameFinished.CloseGameFinishedPanel();
        anims = gameManager.ResetGameplay();
        levelStars.DeActiveStars();
        levelLocker.ActivateLockers();
        levelLocker.CheckWichLevelsUnlocked(puzzle);

        switch (puzzlelevel)
        {
            case 1:
                StartCoroutine(LoadLevelSelectCoroutine(puzzleGamePanel1, puzzleGamePanelAnim1));
                break;
            case 2:
                StartCoroutine(LoadLevelSelectCoroutine(puzzleGamePanel2, puzzleGamePanelAnim2));
                break;
            case 3:
                StartCoroutine(LoadLevelSelectCoroutine(puzzleGamePanel3, puzzleGamePanelAnim3));
                break;
            case 4:
                StartCoroutine(LoadLevelSelectCoroutine(puzzleGamePanel4, puzzleGamePanelAnim4));
                break;
            case 5:
                StartCoroutine(LoadLevelSelectCoroutine(puzzleGamePanel5, puzzleGamePanelAnim5));
                break;
        }

    }
    IEnumerator LoadPuzzleCoRoutine(GameObject puzzleGamePanel,Animator puzzleGamePanelAnime) {
        puzzleGamePanel.SetActive(true);
        puzzleGamePanelAnime.Play("SlideIn");
        puzzleLevelSelectAnim.Play("SlideOut");
        yield return new WaitForSeconds(1f);

        puzzleLevelSelectPanel.SetActive(false);

        
    }

    IEnumerator LoadLevelSelectCoroutine(GameObject puzzleGamePanel, Animator puzzleGamePanelAnime)
    {
        puzzleLevelSelectPanel.SetActive(true);
        puzzleLevelSelectAnim.Play("SlideIn");
        puzzleGamePanelAnime.Play("SlideOut");
        yield return new WaitForSeconds(1f);
        foreach (var anim in anims)
        {
            anim.Play("Idle");
        }
        yield return new WaitForSeconds(0.5f);
        puzzleGamePanel.SetActive(false);
    }
}
