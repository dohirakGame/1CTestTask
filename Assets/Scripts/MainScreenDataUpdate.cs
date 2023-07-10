using TMPro;
using UnityEngine;

public class MainScreenDataUpdate : MonoBehaviour
{
	[Header("��������� ���� ��� ������ �� ������� ������"), Space]
	[SerializeField] private TextMeshProUGUI _coinCurrencyCount;
	[SerializeField] private TextMeshProUGUI _creditCurrencyCount;

	[Header("��������� ���� ��� ���������� �������� �� ������� ������"), Space]
	[SerializeField] private TextMeshProUGUI _medpackCurrencyCount;
	[SerializeField] private TextMeshProUGUI _armorPlateCurrencyCount;

	private void Update()
	{
		GameModel.Update();
		DataUpdate();
	}

	private void DataUpdate()
	{
		BalanceCountUpdate();
		ReservesCountUpdate();
	}

	private void BalanceCountUpdate()
	{
		_coinCurrencyCount.text = $" {GameModel.CoinCount}";
		_creditCurrencyCount.text = $" {GameModel.CreditCount}";
	}

	private void ReservesCountUpdate()
	{
		_medpackCurrencyCount.text = $" {GameModel.GetConsumableCount(GameModel.ConsumableTypes.Medpack)}";
		_armorPlateCurrencyCount.text = $" {GameModel.GetConsumableCount(GameModel.ConsumableTypes.ArmorPlate)}";
	}
}
