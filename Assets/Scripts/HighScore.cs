using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class HighScore : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;



    private void Awake()
    {
        entryContainer = transform.Find("highscoreEntryContainer");
        Debug.Log(entryContainer);
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");
        Debug.Log(entryTemplate);

        entryTemplate.gameObject.SetActive(false);
        //Debug.Log("TESTER");
        float templateHeight = 100f;
        for(int i = 0; i < 10; i++)
        {
            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(700, -templateHeight * i);
            entryTransform.gameObject.SetActive(true);

            entryTransform.Find("posText").GetComponent<Text>().text = "";
            entryTransform.Find("scoreText").GetComponent<Text>().text = "";
            entryTransform.Find("nameText").GetComponent<Text>().text = "";

        }
    }





}
