using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FundButton : UIButton
{
    public FundingPage fundPage;
    public TabButton fundButton;
    public UISprite targetSprite;
    public string unSelectedSprite;
    public string selectedSprite;

    protected override void OnClick()
    {
        base.OnClick();
        fundButton.GetComponentInParent<TabManager>().OnTabSelected(fundButton, fundPage);
        fundPage.OnTabSelected(this, targetSprite);
    }
    public void OnSelected(bool selected)
    {
        if (selected)
        {
            normalSprite = selectedSprite;
        }
        else
        {
            normalSprite = unSelectedSprite;
        }
    }

    public void SetEnabled(bool enabled)
    {
        if (enabled)
        {

        }
        else
        {

        }
        this.isEnabled = enabled;
    }
}
