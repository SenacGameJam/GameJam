using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour {

    public void Quit() {
        Application.Quit();
        Debug.Log("O jogo só fecha na build, no editor essa mensagem é enviada");
    }

}
