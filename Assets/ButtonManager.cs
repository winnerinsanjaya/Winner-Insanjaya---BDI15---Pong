using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goToScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
        Debug.Log("Created by Winner Insanjaya - BDI15");
    }
}
