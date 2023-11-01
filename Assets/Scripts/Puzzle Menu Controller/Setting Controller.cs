 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingController : MonoBehaviour
{
    [SerializeField]
    MusicController musicController;
    [SerializeField]
    private Animator settingMenuAnimator;
    [SerializeField]
    private GameObject settingMenuPanel;
     public void OpenSettingPanel()
    {

        settingMenuAnimator.Play("SlideIn");
        settingMenuPanel.SetActive(true);
    }
    public void CloseSettingPanel()
    {
        StartCoroutine(CloseSetting());
    }

    IEnumerator CloseSetting()
    {
        settingMenuAnimator.Play("Slide out");
        yield return new WaitForSeconds(1f);
        settingMenuPanel.SetActive(false);

    }

    public void GetVolume(float volume)
    {
        musicController.SetMusicVolume(volume);
    }
}
