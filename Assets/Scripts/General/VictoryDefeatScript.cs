using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryDefeatScript : MonoBehaviour {

    [SerializeField]
    private float m_gameDuration;
    public float GameDuration
    {
        get { return m_gameDuration; }
        set { m_gameDuration = value; }
    }

    public int gameState; // 0 : Nothing; 1 : Win; 2 : Loose

	// Use this for initialization
	void Start () {
        Invoke("Loose", GameDuration);
	}

    void Loose()
    {
        gameState = 2;
        Invoke("ReloadGame", 5.0f);
    }

    void ReloadGame()
    {
        SceneManager.LoadScene(0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Player"))
        {
            gameState = 1;
            Invoke("ReloadGame", 5.0f);
        }
    }

    private void OnGUI()
    {
        if(gameState == 1)
        {
            GUI.Label(new Rect(Screen.width * 0.05f, Screen.height * 0.05f, Screen.width * 0.2f, Screen.height * 0.10f), "WIN");
        }
        if (gameState == 2)
        {
            GUI.Label(new Rect(Screen.width * 0.05f, Screen.height * 0.05f, Screen.width * 0.2f, Screen.height * 0.10f), "LOOSE");
        }
    }

    // Update is called once per frame
    void Update () {
        transform.Rotate(new Vector3(1.0f, 1.0f, 1.0f), 5.0f * Time.deltaTime);
	}
}
