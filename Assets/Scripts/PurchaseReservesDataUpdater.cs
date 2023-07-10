using TMPro;
using UnityEngine;

public class PurchaseReservesDataUpdater : MonoBehaviour
{
    [Header("Текстовые поля на кнопках с ценой"), Space]
    [SerializeField] private TextMeshProUGUI _coinPriceText;
    [SerializeField] private TextMeshProUGUI _creditPriceText;

    [Header("Текстовые поля для отображения количества резервов"), Space]
    [SerializeField] private TextMeshProUGUI _medpackCount;
    [SerializeField] private TextMeshProUGUI _armorPlateCount;

    private string _selectedReserveType;

	public static string SelectedReserveType;

	public void SelectReserveType(string type)
	{
		_selectedReserveType = type;
		SelectedReserveType = _selectedReserveType;
	}

	private void Update()
	{
        DataUpdate();
	}

    private void DataUpdate()
    {
        ReservesCountUpdate();

        switch (_selectedReserveType)
        {
            case "Medpack":
				if (!GameModel.ConsumablesPrice.TryGetValue(GameModel.ConsumableTypes.Medpack, out var consumableMedpackConfig))
				{
					Debug.Log("Consumable config not found!");
				}
				else
				{
					_coinPriceText.text = consumableMedpackConfig.CoinPrice.ToString();
					_creditPriceText.text = consumableMedpackConfig.CreditPrice.ToString();
				}
				break;
            case "ArmorPlate":
				if (!GameModel.ConsumablesPrice.TryGetValue(GameModel.ConsumableTypes.ArmorPlate, out var consumableArmorPlateConfig))
				{
					Debug.Log("Consumable config not found!");
				}
				else
				{
					_coinPriceText.text = consumableArmorPlateConfig.CoinPrice.ToString();
					_creditPriceText.text = consumableArmorPlateConfig.CreditPrice.ToString();
				}
				break;
			default:
				_coinPriceText.text = "0";
				_creditPriceText.text = "0";
				break;
        }
    }

	private void ReservesCountUpdate()
    {
		_medpackCount.text = $"{GameModel.GetConsumableCount(GameModel.ConsumableTypes.Medpack)}";
		_armorPlateCount.text = $" {GameModel.GetConsumableCount(GameModel.ConsumableTypes.ArmorPlate)}";
	}
}
