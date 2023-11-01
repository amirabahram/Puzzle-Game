using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFinished : MonoBehaviour
{
    [SerializeField]
    private GameObject gameFinishPanel;
    [SerializeField]
    private Animator gameFinishedAnim, star1Anim, star2Anim, star3Anim, textAnim;

    public void ShowGameFinishedPanel(int stars)
    {
        StartCoroutine(ShowPanel(stars));
    }
    public void CloseGameFinishedPanel()
    {
        gameFinishPanel.SetActive(false);
    }

    IEnumerator ShowPanel(int stars)
    {
        gameFinishPanel.SetActive(true);
        gameFinishedAnim.Play("FadeIn");
        yield return new WaitForSeconds(1.7f);
        switch (stars)
        {
            case 1:
                star1Anim.Play("FadeIn");
                yield return new WaitForSeconds(0.1f);

                textAnim.Play("FadeIn");
                break;
            case 2:
                star1Anim.Play("FadeIn");
                yield return new WaitForSeconds(0.1f);
                star2Anim.Play("FadeIn2");
                yield return new WaitForSeconds(0.1f);
                textAnim.Play("FadeIn");

                break;
            case 3:
                star1Anim.Play("FadeIn");
                yield return new WaitForSeconds(0.1f);
                star2Anim.Play("FadeIn2");
                yield return new WaitForSeconds(0.1f);
                star3Anim.Play("FadeIn3");
                yield return new WaitForSeconds(0.1f);
                textAnim.Play("FadeIn");

                break;
        }
    }
}
