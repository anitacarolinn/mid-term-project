using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public DisappearUI disappearUI;
    public Player player;
    public StarManager starManager;
    public CanvasGroup StageClear;
    public CanvasGroup YouHaveDied;
    public SoundEffectPlayer soundEffect;

    public void stageClear()
    {
        disappearUI.disappearUIbutton();
        Time.timeScale = 0;
        soundEffect.stageClearSE();
        player.enabled = false;
        StageClear.alpha = 1f;
        StageClear.interactable = true;
        StartCoroutine(Fade(StageClear, 1f, 0.3f));

        if (Star_PointSystem.ScoreNum > 35) //to decide stars given 
        {
            starManager.show3stars();
            starManager.StatementText.text = "Excellent";
        }
        else if (Star_PointSystem.ScoreNum > 20)
        {
            starManager.show2stars();
            starManager.StatementText.text = "Great Work";
        }
        else
        {
            starManager.show1stars();
            starManager.StatementText.text = "Try Harder";
        }
    }

    public void youHaveDied()
    {
        disappearUI.disappearUIbutton();
        Time.timeScale = 0;
        player.enabled = false;
        YouHaveDied.alpha = 1f;
        YouHaveDied.interactable = true; 
        StartCoroutine(Fade(YouHaveDied, 1f, 0.3f));

    }

    private IEnumerator Fade(CanvasGroup canvasGroup, float to, float delay)
    {
        yield return new WaitForSeconds(delay);

        float elapsed = 0f;
        float duration = 0.5f;
        float from = canvasGroup.alpha;

        while (elapsed < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = to;
    }

    public void NewGame()
    {
        disappearUI.showUIbutton();
        Time.timeScale = 1;
        Star_PointSystem.ScoreNum = 0;
        YouHaveDied.alpha = 0f;
        StageClear.alpha = 0f;
    }

}
