using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FundingPage : TabPage
{
    public List<UISprite> sprites;
    public List<FundButton> fundButtons;
	public FundButton initialButton;
	public GameObject lastMonth;
	public GameObject history;

	private FundButton currentButton; // retain Fund subpage selection state

	void Awake()
	{
		currentButton = initialButton;
	}

	void Start()
	{
		OnTabSelected(currentButton, currentButton.targetSprite);
	}

    public void OnTabSelected(FundButton selectedButton, UISprite selectedSprite)
    {
		currentButton = selectedButton;
        // 선택된 fundButton만 on, 나머지는 off
        foreach (var fundButton in fundButtons)
        {
            if (fundButton == selectedButton)
            {
                fundButton.OnSelected(true);
            }
            else
            {
                fundButton.OnSelected(false);
            }
        }
        // 선택된 TabPage 제외하고 나머지는 Close
        foreach (var sprite in sprites)
        {
            if (sprite == selectedSprite)
            {
                sprite.gameObject.SetActive(true);
            }
            else
            {
                sprite.gameObject.SetActive(false);
            }
        }
    }

	public override void Open()
	{
		base.Open();
		if (currentButton != null)
		{
			if (currentButton.isEnabled)
			{
				currentButton.OnSelected(true);
			}
			else // opened by pressing Fund button, but last opened button is disabled -> open any other enabled sprite
			{
				foreach (var fundButton in fundButtons)
				{
					if (fundButton != currentButton && fundButton.isEnabled)
					{
						OnTabSelected(fundButton, fundButton.targetSprite);
						break;
					}
				}
			}
		}
		lastMonth.SetActive(DataManager.GetInstance().GameData.turn != 0);
		history.SetActive(DataManager.GetInstance().GameData.turn != 0);
	}
	public override void Close()
	{
		base.Close();
		if (currentButton != null)
			currentButton.OnSelected(false);
	}
}
