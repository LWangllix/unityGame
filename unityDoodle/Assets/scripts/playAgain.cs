using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class playAgain : MonoBehaviour
{
    // Start is called before the first frame update

    private TMP_Text score;

    public void Start()
    {
        score = GameObject.Find("score").GetComponent<TMP_Text>();

    }

    void Update()
    {

        score.SetText("Score {0}", PlayerPrefs.GetInt("score"));
    }




    public void playAgainn()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
