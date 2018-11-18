using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFont : MonoBehaviour {
	public string style = "";
	void Awake(){
	}
	void OnEnable(){
		OnLocalize();
	}
	void OnLocalize(){
		string key = Localization.language;
		UILabel mlabel = GetComponent<UILabel>();
		UIFont mFont = mlabel.bitmapFont;
		string fontName = "";

		if (key == "English"){
				fontName = "OpenSans";
			if (style == "Bold"){
				fontName += "_Bold";
			}
			else if (style == "SemiBold"){
				fontName += "_Semibold";
			}
		}
		else if (key == "Korean"){
			fontName = "NanumBarunGothic";
			if (style == "SemiBold"){
				fontName += "Bold";
			}
		}
		mlabel.bitmapFont = FontManager.FindFont(fontName);
	}

}
