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

    //1�y�[�W�ڂ���2�y�[�W�ڂɈړ�
    public void next_button()
    {
        SceneManager.LoadScene("asobikata2");
    }

    //2�y�[�W�ڂ���1�y�[�W�ڂɈړ� 
    public void back_button()
    {
        SceneManager.LoadScene("asobikata");
    }

    //2�y�[�W�ڂ���3�y�[�W�ڂɈړ�
    public void threepage_button()
    {
        SceneManager.LoadScene("itiran");
    }

    //3�y�[�W�ڂ���2�y�[�W�ڂɈړ�
    public void threepage_back()
    {
        SceneManager.LoadScene("asobikata2");
    }

    
}

