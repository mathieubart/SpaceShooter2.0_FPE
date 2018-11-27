using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour 
{
	[SerializeField]
	private GameObject m_LoadingScreen;
	 
	private static LevelManager m_Instance;
	public static LevelManager Instance
	{
		get {return m_Instance;}
	}

	private void Awake()
	{
		if(m_Instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			m_Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		m_LoadingScreen.SetActive(false);
	}

	public void ChangeLevel(string i_Scene)
	{
		StartLoading();
		SceneManager.LoadScene(i_Scene);

		//Add the fct OnLoadingDone in the Unity's SceneLoaded events.
		SceneManager.sceneLoaded += OnLoadingDone;
	}

    //Play Loading Screen Animation
    private void StartLoading()
	{
		m_LoadingScreen.SetActive(true);
	}

	private void OnLoadingDone(Scene i_Scene, LoadSceneMode i_Mode)
	{
		//Remove the fct from Unity's OnLoadingDone event.
		SceneManager.sceneLoaded -= OnLoadingDone;

		//Stop Animation Loading Screen
		m_LoadingScreen.SetActive(false);
	}

}