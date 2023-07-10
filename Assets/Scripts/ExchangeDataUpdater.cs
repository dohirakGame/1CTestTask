using TMPro;
using UnityEngine;

public class ExchangeDataUpdater : MonoBehaviour
{
	[Header("Текстовые поля валют в окне обмена валют"), Space]
	[SerializeField] private TextMeshProUGUI _coinCurrencyCount;
	[SerializeField] private TextMeshProUGUI _creditCurrencyCount;

	[Header("Текстовые поля для стоимости обмена"), Space]
	[SerializeField] private TextMeshProUGUI _coinToCreditRate;
	[SerializeField] private TextMeshProUGUI _resultCreditRate;
	[SerializeField] private TMP_InputField _inputField;

	private void Update()
	{
		DataUpdate();
	}

	public void Conversion()
	{
		string count = _inputField.text;

		if (_inputField.text.Contains("-"))
		{
			_inputField.text = _inputField.text.Replace("-", "");
		}
		else
		{
			if (count != "")
			{
				int resultRate = int.Parse(count) * GameModel.CoinToCreditRate;
				_resultCreditRate.text = resultRate.ToString();
			}
			else
			{
				_resultCreditRate.text = "0";
			}
		}
	}

	public void ClearInputField()
	{
		_inputField.text = "";
	}

	private void DataUpdate()
	{
		_coinCurrencyCount.text = $" {GameModel.CoinCount}";
		_creditCurrencyCount.text = $" {GameModel.CreditCount}";
		_coinToCreditRate.text = $" {GameModel.CoinToCreditRate}";
	}
}
