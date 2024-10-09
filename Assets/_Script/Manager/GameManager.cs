using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonPersistant<GameManager>
{
    public bool IsGamePaused { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        IsGamePaused = false;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        IsGamePaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        IsGamePaused = false;
    }
}
