using UnityEngine;
using System.Collections;
using System;
using Jacovone;
using UnityEngine.SceneManagement;

public class SceneTransition : PageEventBase
{
	public string SceneToLoad = "";
	private bool SceneNeedsToBeUnlocked = false;

    public override void ForceEvent()
    {
		SceneToLoad = SceneManager.GetSceneAt ((1 + SceneManager.GetActiveScene ().buildIndex) % SceneManager.sceneCountInBuildSettings).name;
		ProcessEvent ();
    }

    public override void ProcessEvent()
	{
		//Open Scene if you can
		if ((!SceneNeedsToBeUnlocked && EpicPrefs.GetInt(SceneToLoad, true) == 0) || (SceneNeedsToBeUnlocked && EpicPrefs.GetInt(SceneToLoad, true) == 1)) {
			if (SceneToLoad != "") {
				SceneManager.LoadSceneAsync (SceneToLoad);
			} else {
				LoadNextScene ();
			}
			return;
		}

		//Inform the player that they need to buy the chapter to countinue.
		//TODO: either open the store, or create a popup
		if (SceneNeedsToBeUnlocked)
		{
			
		}
    }
		
	public void LoadNextScene()
	{
		SceneManager.LoadSceneAsync((1 + SceneManager.GetActiveScene().buildIndex) % SceneManager.sceneCountInBuildSettings);
	}
}