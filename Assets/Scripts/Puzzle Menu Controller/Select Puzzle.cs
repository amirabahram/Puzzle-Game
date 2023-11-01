using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SelectPuzzle : MonoBehaviour
{
    [SerializeField]
    LevelStars levelStars;
    [SerializeField]
    private LevelLocker levelLocker;

    [SerializeField]
    private PuzzleGameManager puzzleGameManager;
    [SerializeField]
    private LevelSelect levelSelect;
    [SerializeField]
    private GameObject selectPuzzleMenuPanel,puzzleLevelMenu;
    [SerializeField]
    private Animator selectPuzzleMenuAnim,puzzleLevelMenuAnim;
    [SerializeField]
    private string selectPuzzleName;


    public void SelectedPuzzle()
    {
        selectPuzzleName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        puzzleGameManager.SetSelectedPuzzle(selectPuzzleName);
        levelStars.DeActiveStars();
        levelLocker.ActivateLockers();
        levelLocker.CheckWichLevelsUnlocked(selectPuzzleName);
        levelSelect.SetSelectedPuzzleName(selectPuzzleName);
        StartCoroutine(ShowLevelPanel());

    }

    IEnumerator ShowLevelPanel()
    {
        puzzleLevelMenu.SetActive(true);
        
        puzzleLevelMenuAnim.Play("SlideOut");
        puzzleLevelMenuAnim.Play("SlideIn");
        yield return new WaitForSeconds(1f);
        selectPuzzleMenuPanel.SetActive(false);





    }
}
