using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUIManager : Singleton<InGameUIManager>
{
    [SerializeField] private GameObject pauseUI;

    protected override void Awake()
    {
        base.Awake();

        DeactivatePauseUI();
    }

    void Update()
    {
        if (PlaerInputManager.Instance.ESCInput)
        {
            PlaerInputManager.Instance.UseESC();

            if (pauseUI.activeInHierarchy)
            {
                DeactivatePauseUI();
            }
            else
            {
                ActivatePauseUI();
            }

        }
    }

    public void ActivatePauseUI()
    {
        pauseUI.SetActive(true);
        GameManager.Instance.PauseGame();
    }

    public void DeactivatePauseUI()
    {
        pauseUI.SetActive(false);
        GameManager.Instance.ResumeGame();
    }
}
