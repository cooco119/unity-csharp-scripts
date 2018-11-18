using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FontManager : MonoBehaviour {

public List<UIFont> fontList = new List<UIFont>();
	private Dictionary<string, UIFont> fontDict = new Dictionary<string, UIFont>();
	private static FontManager mInstance;

	void Awake(){
		mInstance = this;
		foreach(UIFont font in mInstance.fontList){
			mInstance.fontDict.Add(font.name, font);
			// Debug.Log(font.name);
		}
	}
	void Destroy(){
		mInstance = null;
	}
	
  public static UIFont FindFont(string fontName){
		// Debug.Log(string.Format("Font name passed : {0}", fontName));
		Dictionary<string,UIFont>.Enumerator e = mInstance.fontDict.GetEnumerator();
		KeyValuePair<string, UIFont> cur = new KeyValuePair<string, UIFont>();
		while (e.MoveNext()){
			cur = e.Current;
			// Debug.Log(string.Format("Key: {0}, value: {1}",cur.Key, cur.Value.name));
			if (cur.Key == fontName){
				return cur.Value;
			}
		}
		return null;
    // return mInstance.fontDict[fontName];
  }
}
