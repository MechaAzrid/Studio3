﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLoad : MonoBehaviour
{
    [Header("Canvas Groups")]
    public Transform mainCanvas;
    public Transform instructionsCanvas;
    public Transform instructionsCanvas2;

    public bool loading;

    [Header("Particle Systems")]
    public ParticleSystem particleSys;
    public ParticleSystem particleSys2;
    public ParticleSystem particleSys3;

    public void LoadMenuSelect(string scene)
    {
        GameManager.instance.LoadScene(scene);
    }

    public void LoadGame()
    {
        StartCoroutine(LoadingGame());
    }

    public IEnumerator LoadingGame()
    {
        if (loading == true)
        {
            yield break;
        }

        loading = true;

        GameManager.instance.LoadGame();

        print("if it gets here.....");

        yield return new WaitForSeconds(3);



        GameManager.instance.LoadScene("MenuSelectionInventory");

        loading = false;
    }

    public void LoadInstructionsScene()
    {
        if (instructionsCanvas.gameObject.activeInHierarchy == false)
            //if the Instructions Canvas is inactive then when we press "Instructions" enable the canvas but disable the mainCanvas
        {
            instructionsCanvas.gameObject.SetActive(true);
            instructionsCanvas2.gameObject.SetActive(false);
            mainCanvas.gameObject.SetActive(false);
            particleSys.gameObject.SetActive(false);
            particleSys2.gameObject.SetActive(false);
            particleSys3.gameObject.SetActive(false);

        }

        else
        {
            instructionsCanvas.gameObject.SetActive(false);
            particleSys.gameObject.SetActive(true);
            particleSys2.gameObject.SetActive(true);
            particleSys3.gameObject.SetActive(true);
        }
    }

    public void LoadInstructionsSceneP2()
    {
        if (instructionsCanvas2.gameObject.activeInHierarchy == false)
        //if Instructions Canvas 2 is inactive then when we press "Next", we enable page 2 of the canvas but disable the previous canvas
        {
            instructionsCanvas2.gameObject.SetActive(true);
            instructionsCanvas.gameObject.SetActive(false);
            mainCanvas.gameObject.SetActive(false);
            particleSys.gameObject.SetActive(false);
            particleSys2.gameObject.SetActive(false);
            particleSys3.gameObject.SetActive(false);

        }

        else
        {
            instructionsCanvas2.gameObject.SetActive(false);
            particleSys.gameObject.SetActive(true);
            particleSys2.gameObject.SetActive(true);
            particleSys3.gameObject.SetActive(true);
        }
    }

    public void ReturnToMainScene()
    {
        if (mainCanvas.gameObject.activeInHierarchy == false)
        {
            mainCanvas.gameObject.SetActive(true);
            instructionsCanvas.gameObject.SetActive(false);
            instructionsCanvas2.gameObject.SetActive(false);
            particleSys.gameObject.SetActive(true);
            particleSys2.gameObject.SetActive(true);
            particleSys3.gameObject.SetActive(true);

        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
