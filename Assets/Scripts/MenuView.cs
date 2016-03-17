using UnityEngine;
using System.Collections;

public class MenuView : MonoBehaviour {

	public string title;
	public Texture2D background;
	public Texture2D scrollBar;
	public GameView game;
	public Font menuFont;

	TextAsset[] maps;
	GUIStyle titleStyle, levelStyle;
	int topLevel = 0;
	int currentLevel = 0;
	Vector2 scrollPosition = Vector2.zero;

	void Start () 
	{
		topLevel = PlayerPrefs.GetInt("level");

		maps = Resources.LoadAll<TextAsset>("Maps");

		titleStyle = new GUIStyle();
		titleStyle.font = menuFont;
		titleStyle.fontSize = Screen.width / 4; //140
		titleStyle.normal.textColor = Color.white;
		titleStyle.alignment = TextAnchor.UpperCenter;
		titleStyle.padding = new RectOffset(0, 0, Screen.height / 8, Screen.height / 24);

		levelStyle = new GUIStyle();
		levelStyle.font = menuFont;
		levelStyle.fontSize = Screen.width / 10; //60
		levelStyle.normal.textColor = Color.white;
		levelStyle.alignment = TextAnchor.UpperCenter;
		levelStyle.padding = new RectOffset(0, 0, Screen.height / 48, Screen.height / 48);
	}

	public void NextLevel ()
	{
		if(currentLevel == topLevel && topLevel < maps.Length)
		{
			topLevel++;
			PlayerPrefs.SetInt("level", topLevel);
		}
	}
	
	void OnGUI () 
	{
		// lay out the level selection screen
		GUI.skin.verticalScrollbarThumb.normal.background = scrollBar;

		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), background);

		GUILayout.BeginVertical(GUILayout.Width(Screen.width));

			GUILayout.Label(title, titleStyle);
			
			scrollPosition = GUILayout.BeginScrollView(scrollPosition);

			for(int i = 0; i < maps.Length; i++)
			{
				if(i <= topLevel)
					GUI.color = Color.white;
				else
					GUI.color = Color.gray;

				if(GUILayout.Button("< LEVEL " + (i + 1) + " >", levelStyle))
				{
					if(i <= topLevel)
					{
						gameObject.SetActive(false);
						game.CreateLevel(i + 1);
						currentLevel = i;
					}
				}
			}

			GUILayout.EndScrollView();

		GUILayout.EndVertical();
	}

	void Update()
	{
		// detect touch drag
		if(Input.touchCount > 0)
		{
			if (Input.touches[0].phase == TouchPhase.Moved)
				scrollPosition.y += Input.touches[0].deltaPosition.y;
		}
	}
}
