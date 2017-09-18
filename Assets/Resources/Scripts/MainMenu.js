#pragma strict 
var SceneManager:UnityEngine.SceneManagement.SceneManager;

function Start () {
	
}

function Update () {
	
}

function StartGame(){
	SceneManager.LoadScene('main');
}

function Config(){
	
}

function Quit(){
	//if(Application.isEditor)
	//	UnityEditor.EditorApplication.isPlaying = false;
	//else
	Application.Quit();
}