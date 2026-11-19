namespace OrdersDeliveryCalc
{
    partial class MainForm
    {
        private readonly TextBox recipientBox = new TextBox();
        private readonly TextBox weightBox = new TextBox();
        private readonly TextBox distanceBox = new TextBox();

        private readonly RadioButton economyButton = new RadioButton();
        private readonly RadioButton standardButton = new RadioButton();
        private readonly RadioButton expressButton = new RadioButton();

        private readonly CheckBox fragileBox = new CheckBox();
        private readonly CheckBox addressBox = new CheckBox();

        private readonly ListBox shipmentList = new ListBox();

        private readonly Label turnoverLabel = new Label();
        private readonly Label averageLabel = new Label();

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Text = "Куриерски пратки - Ивайло Абаджиев F117505";
            ClientSize = new Size(660, 475);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            AutoScaleMode = AutoScaleMode.Font;
            Font = new Font("Segoe UI", 10);

            AddInput("Име на получател", recipientBox, 18);
            AddInput("Тегло (кг)", weightBox, 54);
            AddInput("Растояние (км)", distanceBox, 90);

            GroupBox serviceGroup = new GroupBox();
            serviceGroup.Text = "Тип услуга";
            serviceGroup.SetBounds(16, 128, 628, 64);
            AddOption(serviceGroup, economyButton, "Икономична (4.00 лв)", 12, 26);
            AddOption(serviceGroup, standardButton, "Стандартна (6.00 лв)", 215, 26);
            AddOption(serviceGroup, expressButton, "Експресна (10.00 лв)", 420, 26);
            economyButton.Checked = true;
            Controls.Add(serviceGroup);

            AddOption(this, fragileBox, "Чупливо състояние", 18, 204);
            AddOption(this, fragileBox, "Доставка до адрес", 250, 204);

            Button acceptButton = new Button();
            acceptButton.Text = "Приеми пратка";
            acceptButton.SetBounds(16, 236, 160, 34);
            acceptButton.Click += AcceptShipment;
            Controls.Add(acceptButton);
            AcceptButton = acceptButton;

            Label listLabel = new Label();
            listLabel.Text = "Приети пратки";
            listLabel.AutoSize = true;
            listLabel.Location = new Point(16, 282);
            Controls.Add(listLabel);

            shipmentList.SetBounds(16, 306, 628, 105);
            shipmentList.HorizontalScrollbar = true;
            Controls.Add(shipmentList);

            turnoverLabel.AutoSize = true;
            turnoverLabel.Location = new Point(16, 419);
            averageLabel.AutoSize = true;
            averageLabel.Location = new Point(16, 445);
            Controls.Add(turnoverLabel);
            Controls.Add(averageLabel);

        }

        private void AddInput(string caption, TextBox input, int top)
        {
            Label label = new Label();
            label.Text = caption;
            label.AutoSize = true;
            label.Location = new Point(16, top + 4);
            input.SetBounds(180, top, 290, 20);
            Controls.Add(label);
            Controls.Add(input);
        }

        private static void AddOption(Control parent, ButtonBase option, string caption, int x, int y)
        {
            option.Text = caption;
            option.AutoSize = true;
            option.Location = new Point(x, y);
            parent.Controls.Add(option);
        }

        #endregion
    }
}