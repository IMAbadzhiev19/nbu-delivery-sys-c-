using System.Globalization;

namespace OrdersDeliveryCalc;

public partial class MainForm : Form
{
    private readonly List<(double Weight, double Price)> shipments = new List<(double Weight, double Price)>();

    public MainForm()
    {
        InitializeComponent();
    }

    private void AcceptShipment(object sender, EventArgs e)
    {
        string recipient = recipientBox.Text.Trim();
        if (recipient.Length == 0)
        {
            ShowInputError("Въведете името на полуател", recipientBox);
            return;
        }

        if (!TryReadPositiveNumber(weightBox.Text, out double weight))
        {
            ShowInputError("Въведете положително тегло в килограмите", weightBox);
            return;
        }

        if (!TryReadPositiveNumber(distanceBox.Text, out double distance))
        {
            ShowInputError("Въведете положително разстояние в километри", distanceBox);
            return;
        }

        double basePrice = ShippingPriceCalculator.EconomyRate;
        if (standardButton.Checked)
        {
            basePrice = ShippingPriceCalculator.StandardRate;
        }
        else if (expressButton.Checked)
        {
            basePrice = ShippingPriceCalculator.ExpressRate;
        }

        double price = ShippingPriceCalculator.CalculatePrice(basePrice, weight, distance, addressBox.Checked, fragileBox.Checked);
        if (!double.IsFinite(price))
        {
            MessageBox.Show(this, "Въведените стойности са твърде големи", "Невалидни данни");
            return;
        }

        shipments.Add((weight, price));
        shipmentList.Items.Add($"{shipments.Count}, {recipient} | {weight:G}:kg | {price:F2} lv.");
        UpdateStatistics();
    }

    private void ShowInputError(string message, TextBox input)
    {
        MessageBox.Show(this, message, "Невалидни данни", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        input.Focus();
    }

    private static bool TryReadPositiveNumber(string text, out double value)
    {
        return double.TryParse(text.Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture, out value) && double.IsFinite(value) && value > 0;
    }

    private void UpdateStatistics()
    {
        double turnover = 0;
        double totalWeight = 0;
        foreach (var shipment in shipments)
        {
            turnover += shipment.Price;
            totalWeight += shipment.Weight;
        }

        double average = shipments.Count == 0 ? 0 : totalWeight / shipments.Count;
        turnoverLabel.Text = $"Общ оборот: {turnover:F2} лв";
        averageLabel.Text = $"Средно тегло на пратка: {average:F2} кг";
    }
}
