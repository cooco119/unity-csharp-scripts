using UnityEngine;
using System.Collections.Generic;

public class TooltipManager : UITooltip
{
    static protected TooltipManager myInstance;
    void Awake() { myInstance = this; }
    void OnDestroy() { myInstance = null; }
    protected Vector3 targetPos;

    protected void Set(string tooltipText, Vector3 pos)
    {
        targetPos = pos;
        myInstance.SetText(tooltipText);
    }

    protected override void SetText(string tooltipText)
    {
        
        base.SetText(tooltipText);

        // Background 사이즈 조절
        Vector4 border = background.border;
        mSize.x += border.x + border.z - border.x * 2f;
        mSize.y += border.y + border.w;
        background.width = Mathf.RoundToInt(mSize.x);
        background.height = Mathf.RoundToInt(mSize.y);

        // target의 world position을 그대로 대입
        mTrans.position = targetPos;
        mPos = mTrans.localPosition;
        mPos.x = Mathf.Round(mPos.x);
        mPos.y = Mathf.Round(mPos.y);

        // Local position에서 screen을 벗어나지 못하게 조정
        if (mPos.x + mSize.x > Screen.width) mPos.x = Screen.width - mSize.x;
        if (mPos.y - mSize.y < -Screen.height) mPos.y = -Screen.height + mSize.y;
        //Debug.Log(string.Format("Tooltip position in its local coordintate(UI Root/Camera/Tooltip)\nX: {0}, Y: {1}", mPos.x, mPos.y));

        mTrans.localPosition = mPos;

        // Force-update all anchors below the tooltip
        if (tooltipRoot != null) tooltipRoot.BroadcastMessage("UpdateAnchors");
        else text.BroadcastMessage("UpdateAnchors");

    }

    static public void ShowTooltip(string text, Vector3 pos) { if (mInstance != null) myInstance.Set(text, pos); }
}
