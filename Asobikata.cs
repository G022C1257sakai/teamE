using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Asobikata : MonoBehaviour

{

    public string ReturnSceneName;
    public static string NowSceneName;
    public void change_button()
    {
        NowSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("asobikata");
    }


    public string getSceneName()
    {
        return NowSceneName;
    }
    public void sceneback()
    {

        ReturnSceneName = getSceneName();
        SceneManager.LoadScene(ReturnSceneName);
    }

    //1ページ目から2ページ目に移動
    public void next_button()
    {
        SceneManager.LoadScene("asobikata2");
    }

    //2ページ目から1ページ目に移動 
    public void back_button()
    {
        SceneManager.LoadScene("asobikata");
    }

    //2ページ目から3ページ目に移動
    public void threepage_button()
    {
        SceneManager.LoadScene("itiran");
    }

    //3ページ目から2ページ目に移動
    public void threepage_back()
    {
        SceneManager.LoadScene("asobikata2");
    }

    
}

