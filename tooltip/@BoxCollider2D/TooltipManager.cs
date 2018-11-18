using UnityEngine;
using System.Collections.Generic;

public class TooltipManager : UITooltip
{
    static protected TooltipManager myInstance;
    void Awake() { myInstance = this; }
    void OnDestroy() { myInstance = null; }
    protected Vector3 targetPos;
    
    protected override void SetText(string tooltipText)
    {
        
        base.SetText(tooltipText);
        // Transform rootTrans = transform.parent.transform;
        // rootTrans.
        Vector2 screen = NGUITools.screenSize;
        

        // Background 사이즈 조절
        Vector4 border = this.background.border;
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
        UIRoot root = NGUITools.FindActive<UIRoot>()[0];
        int height = root.activeHeight/2;
        float aspect = 16f/9f;
        int width = (int)(height * aspect);
        if (mPos.x + mSize.x > width) mPos.x = width - mSize.x;
        if (mPos.y - mSize.y < -height) mPos.y = -height + mSize.y;

        mTrans.localPosition = mPos;

        // Force-update all anchors below the tooltip
        if (tooltipRoot != null) tooltipRoot.BroadcastMessage("UpdateAnchors");
        else text.BroadcastMessage("UpdateAnchors");

    }

    static public void ShowTooltip(string text, Vector3 pos)
    {
        if (myInstance != null)
        {
            myInstance.targetPos = pos;
            myInstance.SetText(text);
        }
    }
}
