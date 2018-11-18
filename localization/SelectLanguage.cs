using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLanguage : MonoBehaviour {

	public string lan = "";
	void OnClick(){
		Localization.language = lan;
	}
}
