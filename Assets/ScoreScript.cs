using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{

    public static int score1, score2;
    public Text textS1, textS2, nilaiMaksText;
    public int nilaiMaksimal;

    public static string lastPaddle;

    // Start is called before the first frame update
    void Start()
    {
        score1 = 0;
        score2 = 0;
        nilaiMaksText.text = "Nilai Maksimal : " + nilaiMaksimal.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        nilaiMaksText.text = "Nilai Maksimal : " + nilaiMaksimal.ToString();
        textS1.text = score1.ToString();
        textS2.text = score2.ToString();

        if(score1 >= nilaiMaksimal || score2 >= nilaiMaksimal)
        {
            SceneManager.LoadScene("MainMenu");
        }

        Debug.Log(lastPaddle);
    }
}
