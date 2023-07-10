using System;
using TMPro;
using UnityEngine;

public class ButtonsController : MonoBehaviour
{
	public void ConvertCoin(TMP_InputField inputField)
	{
		if (inputField.text != "")
		{
			int count = int.Parse(inputField.text);
			GameModel.ConvertCoinToCredit(count);
		}
	}

	public void BuyConsumableForCredit()
	{
		switch (PurchaseReservesDataUpdater.SelectedReserveType)
		{
			case "Medpack":
				GameModel.BuyConsumableForSilver(GameModel.ConsumableTypes.Medpack);
				break;
			case "ArmorPlate":
				GameModel.BuyConsumableForSilver(GameModel.ConsumableTypes.ArmorPlate);
				break;
		}
	}

	public void BuyConsumableForCoin()
	{
		switch (PurchaseReservesDataUpdater.SelectedReserveType)
		{
			case "Medpack":
				GameModel.BuyConsumableForGold(GameModel.ConsumableTypes.Medpack);
				break;
			case "ArmorPlate":
				GameModel.BuyConsumableForGold(GameModel.ConsumableTypes.ArmorPlate);
				break;
		}
	}

	public void SelectConsumableType(string type)
	{
		FindObjectOfType<PurchaseReservesDataUpdater>().SelectReserveType(type);
	}
	public void TogglePanel(GameObject panel)
	{
		panel.SetActive(!panel.activeSelf);
	}
}
