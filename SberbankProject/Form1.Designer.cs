namespace SberbankProject
{
    partial class mainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxWebSocketLogs = new System.Windows.Forms.TextBox();
            this.textBoxGsmLogs = new System.Windows.Forms.TextBox();
            this.labelWebSocketLogs = new System.Windows.Forms.Label();
            this.labelUartLogs = new System.Windows.Forms.Label();
            this.textBoxServerIP = new System.Windows.Forms.TextBox();
            this.labelServerIP = new System.Windows.Forms.Label();
            this.textBoxServerPort = new System.Windows.Forms.TextBox();
            this.labelServerPort = new System.Windows.Forms.Label();
            this.buttonSaveSettings = new System.Windows.Forms.Button();
            this.comboBoxSerialPort = new System.Windows.Forms.ComboBox();
            this.labelSerialPort = new System.Windows.Forms.Label();
            this.textBoxTimeOut = new System.Windows.Forms.TextBox();
            this.labelTimeOutSMS = new System.Windows.Forms.Label();
            this.buttonApplicationStart = new System.Windows.Forms.Button();
            this.buttonApplicationEnd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxWebSocketLogs
            // 
            this.textBoxWebSocketLogs.Location = new System.Drawing.Point(13, 259);
            this.textBoxWebSocketLogs.Multiline = true;
            this.textBoxWebSocketLogs.Name = "textBoxWebSocketLogs";
            this.textBoxWebSocketLogs.ReadOnly = true;
            this.textBoxWebSocketLogs.Size = new System.Drawing.Size(350, 340);
            this.textBoxWebSocketLogs.TabIndex = 1;
            // 
            // textBoxGsmLogs
            // 
            this.textBoxGsmLogs.Location = new System.Drawing.Point(398, 256);
            this.textBoxGsmLogs.Multiline = true;
            this.textBoxGsmLogs.Name = "textBoxGsmLogs";
            this.textBoxGsmLogs.ReadOnly = true;
            this.textBoxGsmLogs.Size = new System.Drawing.Size(350, 340);
            this.textBoxGsmLogs.TabIndex = 2;
            // 
            // labelWebSocketLogs
            // 
            this.labelWebSocketLogs.AutoSize = true;
            this.labelWebSocketLogs.Location = new System.Drawing.Point(10, 236);
            this.labelWebSocketLogs.Name = "labelWebSocketLogs";
            this.labelWebSocketLogs.Size = new System.Drawing.Size(148, 17);
            this.labelWebSocketLogs.TabIndex = 3;
            this.labelWebSocketLogs.Text = "Обмен по WebSocket";
            // 
            // labelUartLogs
            // 
            this.labelUartLogs.AutoSize = true;
            this.labelUartLogs.Location = new System.Drawing.Point(405, 236);
            this.labelUartLogs.Name = "labelUartLogs";
            this.labelUartLogs.Size = new System.Drawing.Size(161, 17);
            this.labelUartLogs.TabIndex = 4;
            this.labelUartLogs.Text = "Обмен с GSM модемом";
            // 
            // textBoxServerIP
            // 
            this.textBoxServerIP.Location = new System.Drawing.Point(13, 12);
            this.textBoxServerIP.Name = "textBoxServerIP";
            this.textBoxServerIP.Size = new System.Drawing.Size(137, 22);
            this.textBoxServerIP.TabIndex = 5;
            // 
            // labelServerIP
            // 
            this.labelServerIP.AutoSize = true;
            this.labelServerIP.Location = new System.Drawing.Point(156, 15);
            this.labelServerIP.Name = "labelServerIP";
            this.labelServerIP.Size = new System.Drawing.Size(121, 17);
            this.labelServerIP.TabIndex = 6;
            this.labelServerIP.Text = "IP адрес сервера";
            // 
            // textBoxServerPort
            // 
            this.textBoxServerPort.Location = new System.Drawing.Point(13, 41);
            this.textBoxServerPort.Name = "textBoxServerPort";
            this.textBoxServerPort.Size = new System.Drawing.Size(137, 22);
            this.textBoxServerPort.TabIndex = 7;
            // 
            // labelServerPort
            // 
            this.labelServerPort.AutoSize = true;
            this.labelServerPort.Location = new System.Drawing.Point(156, 44);
            this.labelServerPort.Name = "labelServerPort";
            this.labelServerPort.Size = new System.Drawing.Size(98, 17);
            this.labelServerPort.TabIndex = 8;
            this.labelServerPort.Text = "Сетевой порт";
            // 
            // buttonSaveSettings
            // 
            this.buttonSaveSettings.Location = new System.Drawing.Point(571, 12);
            this.buttonSaveSettings.Name = "buttonSaveSettings";
            this.buttonSaveSettings.Size = new System.Drawing.Size(177, 36);
            this.buttonSaveSettings.TabIndex = 9;
            this.buttonSaveSettings.Text = "Сохранить настройки";
            this.buttonSaveSettings.UseVisualStyleBackColor = true;
            this.buttonSaveSettings.Click += new System.EventHandler(this.buttonSaveSettings_Click);
            // 
            // comboBoxSerialPort
            // 
            this.comboBoxSerialPort.FormattingEnabled = true;
            this.comboBoxSerialPort.Location = new System.Drawing.Point(13, 98);
            this.comboBoxSerialPort.Name = "comboBoxSerialPort";
            this.comboBoxSerialPort.Size = new System.Drawing.Size(137, 24);
            this.comboBoxSerialPort.TabIndex = 10;
            // 
            // labelSerialPort
            // 
            this.labelSerialPort.AutoSize = true;
            this.labelSerialPort.Location = new System.Drawing.Point(156, 101);
            this.labelSerialPort.Name = "labelSerialPort";
            this.labelSerialPort.Size = new System.Drawing.Size(171, 17);
            this.labelSerialPort.TabIndex = 11;
            this.labelSerialPort.Text = "Последовательный порт";
            // 
            // textBoxTimeOut
            // 
            this.textBoxTimeOut.Location = new System.Drawing.Point(13, 70);
            this.textBoxTimeOut.Name = "textBoxTimeOut";
            this.textBoxTimeOut.Size = new System.Drawing.Size(137, 22);
            this.textBoxTimeOut.TabIndex = 12;
            // 
            // labelTimeOutSMS
            // 
            this.labelTimeOutSMS.AutoSize = true;
            this.labelTimeOutSMS.Location = new System.Drawing.Point(155, 73);
            this.labelTimeOutSMS.Name = "labelTimeOutSMS";
            this.labelTimeOutSMS.Size = new System.Drawing.Size(260, 17);
            this.labelTimeOutSMS.TabIndex = 13;
            this.labelTimeOutSMS.Text = "TimeOut для сообщения ( в секундах )";
            // 
            // buttonApplicationStart
            // 
            this.buttonApplicationStart.Location = new System.Drawing.Point(571, 56);
            this.buttonApplicationStart.Name = "buttonApplicationStart";
            this.buttonApplicationStart.Size = new System.Drawing.Size(177, 36);
            this.buttonApplicationStart.TabIndex = 14;
            this.buttonApplicationStart.Text = "Начать работу";
            this.buttonApplicationStart.UseVisualStyleBackColor = true;
            this.buttonApplicationStart.Click += new System.EventHandler(this.buttonApplicationStart_Click);
            // 
            // buttonApplicationEnd
            // 
            this.buttonApplicationEnd.Location = new System.Drawing.Point(571, 101);
            this.buttonApplicationEnd.Name = "buttonApplicationEnd";
            this.buttonApplicationEnd.Size = new System.Drawing.Size(177, 36);
            this.buttonApplicationEnd.TabIndex = 15;
            this.buttonApplicationEnd.Text = "Завершить работу";
            this.buttonApplicationEnd.UseVisualStyleBackColor = true;
            this.buttonApplicationEnd.Click += new System.EventHandler(this.buttonApplicationEnd_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 611);
            this.Controls.Add(this.buttonApplicationEnd);
            this.Controls.Add(this.buttonApplicationStart);
            this.Controls.Add(this.labelTimeOutSMS);
            this.Controls.Add(this.textBoxTimeOut);
            this.Controls.Add(this.labelSerialPort);
            this.Controls.Add(this.comboBoxSerialPort);
            this.Controls.Add(this.buttonSaveSettings);
            this.Controls.Add(this.labelServerPort);
            this.Controls.Add(this.textBoxServerPort);
            this.Controls.Add(this.labelServerIP);
            this.Controls.Add(this.textBoxServerIP);
            this.Controls.Add(this.labelUartLogs);
            this.Controls.Add(this.labelWebSocketLogs);
            this.Controls.Add(this.textBoxGsmLogs);
            this.Controls.Add(this.textBoxWebSocketLogs);
            this.Name = "mainForm";
            this.Text = "Автозаполнитель форм - сервер";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxWebSocketLogs;
        private System.Windows.Forms.TextBox textBoxGsmLogs;
        private System.Windows.Forms.Label labelWebSocketLogs;
        private System.Windows.Forms.Label labelUartLogs;
        private System.Windows.Forms.TextBox textBoxServerIP;
        private System.Windows.Forms.Label labelServerIP;
        private System.Windows.Forms.TextBox textBoxServerPort;
        private System.Windows.Forms.Label labelServerPort;
        private System.Windows.Forms.Button buttonSaveSettings;
        private System.Windows.Forms.ComboBox comboBoxSerialPort;
        private System.Windows.Forms.Label labelSerialPort;
        private System.Windows.Forms.TextBox textBoxTimeOut;
        private System.Windows.Forms.Label labelTimeOutSMS;
        private System.Windows.Forms.Button buttonApplicationStart;
        private System.Windows.Forms.Button buttonApplicationEnd;
    }
}

