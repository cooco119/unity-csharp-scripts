using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DisplayTooltip : MonoBehaviour
{
    public string key = "";

    void OnTooltip(bool state)
    {
        string finalText = "";
        string path = "tooltips";
        TextAsset csvFile = Resources.Load<TextAsset>(path) as TextAsset;
        // bool isLoaded = Localization.LoadCSV(csvFile);

        // targetPos를 해당 gameobject의 local에서 계산 후 world position으로 변환
        BoxCollider2D targetBox = GetComponent<BoxCollider2D>();
        Transform targetTrans = this.transform;
        Vector3 pos = new Vector3();
        pos.x = targetBox.size.x / 2 + targetBox.offset.x;
        pos.y = -targetBox.size.y / 2 + targetBox.offset.y;
        pos = transform.TransformPoint(pos);

        //// For debug //
        //
        ///* Get gameobject tree path */
        //GameObject curObj = this.gameObject;
        //var sb = new System.Text.StringBuilder();
        //int i = 0;
        //string tree = "";
        //string curName = curObj.name;
        //sb.Append(curName);
        //while (curName != "UI Root/" || i != 10)
        //{
        //    i++;
        //    if (curObj.transform.parent != null)
        //    {
        //        curObj = curObj.transform.parent.gameObject;
        //        curName = curObj.name;
        //        curName = string.Format("{0}/", curName);
        //        sb.Insert(0, curName);
        //    }
        //    else
        //    {
        //
        //        break;
        //    }
        //}
        //tree = sb.ToString();
        //
        ///* Display values */
        //Debug.Log(string.Format("Target Position in its Local Coordinate({0})\nX: {1}, Y: {2}", tree, pos.x, pos.y));
        //Debug.Log(string.Format("Target Position in its World Coordinate after transform.TransformPosition({0})\nX: {1}, Y: {2}", tree, pos.x, pos.y));
        //
        //// End debug //

        if (true)
        {
            //Debug.Log("CSV Loaded!");

            finalText = Localization.Get(key);
        }

        if (!state)
        {
            finalText = "";
        }

        if (finalText != "")
        {
            // text와 position 같이 parameter로 전달
            TooltipManager.ShowTooltip(finalText, pos);
            //UITooltip.Show(finalText);
        }
        else
        {
            //Debug.Log("Error loading tooltip text");
        }
    }
}
