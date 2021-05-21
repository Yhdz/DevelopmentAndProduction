using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public int points = 10321;
    public int lives = 6;
    public float magic = 0.8f;

    public Transform StatsPanel;
    public Image MagicImages;
    public Text MagicText;
    public Text PointsText;
    public Transform TextInfoPanel;
    public Transform GameOverPanel;
    public Transform CountDownPanel;

    // Start is called before the first frame update
    void Start()
    {
        // initialize panel states
        TextInfoPanel.gameObject.SetActive(false);
        GameOverPanel.gameObject.SetActive(false);
        CountDownPanel.gameObject.SetActive(true);

        // Start Countdown
        StartCoroutine(RunCountDown());
    }

    private IEnumerator RunCountDown()
    {
        Text countdownText = CountDownPanel.GetChild(0).GetComponent<Text>();

        countdownText.text = "3";
        yield return new WaitForSeconds(1);

        countdownText.text = "2";
        yield return new WaitForSeconds(1);

        countdownText.text = "1";
        yield return new WaitForSeconds(1);

        CountDownPanel.gameObject.SetActive(false);
        TextInfoPanel.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // clamp input variables
        points = Mathf.Clamp(points, 0, 99999);
        lives = Mathf.Clamp(lives, 0, 6);
        magic = Mathf.Clamp(magic, 0f, 1f);

        // update lives bar
        for (int i = 0; i < StatsPanel.childCount; i++)
        {
            if (i < lives)
            {
                StatsPanel.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                StatsPanel.GetChild(i).gameObject.SetActive(false);
            }
        }

        // update number of points visuals
        PointsText.text = points.ToString();

        // update magic bar
        RectTransform rt = MagicImages.rectTransform;
        rt.sizeDelta = new Vector2(183 * magic, rt.sizeDelta.y);

        // update magic bar text
        MagicText.text = Mathf.CeilToInt(magic * 100.0f).ToString() + "%";

        // show game over screen if no lives left
        if (lives <= 0)
        {
            GameOverPanel.gameObject.SetActive(true);
        }
        else
        {
            GameOverPanel.gameObject.SetActive(false);
        }
    }

    public void OnPressContinueButton()
    {
        TextInfoPanel.gameObject.SetActive(false);
    }
}
