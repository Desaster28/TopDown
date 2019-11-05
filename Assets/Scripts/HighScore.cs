using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using CodeMonkey.Utils;

public class HighScore : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> highscoreEntryTransformList;


    private void Awake()
    {
        entryContainer = transform.Find("highscoreEntryContainer");
        Debug.Log(entryContainer);
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");
        Debug.Log(entryTemplate);

        entryTemplate.gameObject.SetActive(false);
        //Debug.Log("TESTER");
        //float templateHeight = 100f;
        //for(int i = 0; i < 10; i++)
        // {
        //    Transform entryTransform = Instantiate(entryTemplate, entryContainer);
        //   RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        //   entryRectTransform.anchoredPosition = new Vector2(700, -templateHeight * i);
        //  entryTransform.gameObject.SetActive(true);

        /// entryTransform.Find("posText").GetComponent<Text>().text = "";
        // entryTransform.Find("scoreText").GetComponent<Text>().text = "";
        // entryTransform.Find("nameText").GetComponent<Text>().text = "";

        //}
        //}
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        if (highscores == null)
        {
            // there's no stored table, initialize
            Debug.Log("initializing table with default values...");
            AddHighscoreEntry(897621, "tester1");
            AddHighscoreEntry(872931, "dtester2");
            AddHighscoreEntry(785123, "tester3");
            AddHighscoreEntry(542024, "tester4");
            AddHighscoreEntry(68245, "atester1235");
            // reload
            jsonString = PlayerPrefs.GetString("highscoretable");
            highscores = JsonUtility.FromJson<Highscores>(jsonString);
        }
        // AddHighscoreEntry(102200000, "Tester123");

        // Sort entry list by Score
        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
            {
                if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                {
                    // Swap
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
            }
        }

        highscoreEntryTransformList = new List<Transform>();
        int count = 0;
        while (count < 10)
        {
            foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
            {
                if (count >= 10) { break; }
                CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
                count++;
            }
        }
        //FOR CLEARING ALL SCORE
        //RemoveAllHighscore();
        gameObject.SetActive(false);
    }
    public void Show(){
        gameObject.SetActive(true);
    }
    public void Hide(){
        gameObject.SetActive(false);    
    }
    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 100f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(700, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default:
                rankString = rank + "TH"; break;

            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }

        entryTransform.Find("posText").GetComponent<Text>().text = rankString;

        int score = highscoreEntry.score;

        entryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();

        string name = highscoreEntry.name;
        entryTransform.Find("nameText").GetComponent<Text>().text = name;

        // Set background visible odds and evens, easier to read
        //entryTransform.Find("background").gameObject.SetActive(rank % 2 == 1);

        // Highlight First
        //if (rank == 1)
        //{
        //    entryTransform.Find("posText").GetComponent<Text>().color = Color.green;
        //    entryTransform.Find("scoreText").GetComponent<Text>().color = Color.green;
        //    entryTransform.Find("nameText").GetComponent<Text>().color = Color.green;
        //}

        // Set tropy
        //switch (rank)
        //{
        //    default:
        //        entryTransform.Find("trophy").gameObject.SetActive(false);
        //        break;
        //    case 1:
        //        entryTransform.Find("trophy").GetComponent<Image>().color = UtilsClass.GetColorFromString("FFD200");
        //        break;
        //    case 2:
        //        entryTransform.Find("trophy").GetComponent<Image>().color = UtilsClass.GetColorFromString("C6C6C6");
        //        break;
        //    case 3:
        //        entryTransform.Find("trophy").GetComponent<Image>().color = UtilsClass.GetColorFromString("B76F56");
        //        break;

        //}

        transformList.Add(entryTransform);
    }
    private void RemoveAllHighscore()
    {
        //string jsonString = PlayerPrefs.GetString("highscoreTable");
        //Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        //Debug.Log(highscores);
        //int count = 0; 
        //while (count < 16)
        //{
        //    Debug.Log("INSIDE WHILE " + highscores);
        //    highscores.highscoreEntryList.Remove();
        //    count++;
        //}
        //Debug.Log(highscores);
        PlayerPrefs.DeleteKey("highscoreTable");
    }
    public void AddHighscoreEntry(int score, string name)
    {
        // Create HighscoreEntry
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };

        // Load saved Highscores
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        if (highscores == null)
        {
            // There's no stored table, initialize
            highscores = new Highscores()
            {
                highscoreEntryList = new List<HighscoreEntry>()
            };
        }

        // Add new entry to Highscores
        highscores.highscoreEntryList.Add(highscoreEntry);
        // Save updated Highscores
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }

    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }

    /*
     * Represents a single High score entry
     * */
    [System.Serializable]
    private class HighscoreEntry
    {
        public int score;
        public string name;
    }





}
