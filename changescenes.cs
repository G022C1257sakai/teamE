using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 1/11�X�V

public class changescenes : MonoBehaviour
{
    public static string NowSceneName;
    public static string ReturnSceneName;

    public void change_button()
    {
        SceneManager.LoadScene("optionScene");
    }

    //�ԎD
    public void change_game()
    {
        SceneManager.LoadScene("Game");
    }

    //�I�v�V�����ւ̑J��
    public void change_option()
    {
        NowSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("optionScene");

    }
    //�I�v�V��������̑J��
    public void change_return()
    {
        //�A�N�e�B�u�V�[���̖��O�����o��
        ReturnSceneName = getSceneName();
        //�A�N�e�B�u�V�[���̌ďo
        SceneManager.LoadScene(ReturnSceneName);
    }


    //�A�N�e�B�u�V�[���̖��O�ۑ�
    public static string getSceneName()
    {
        return NowSceneName;
    }


}
