namespace TesteDllNFe
{
    partial class FormPrincipal
    {
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboCertificado = new System.Windows.Forms.ComboBox();
            this.txaRequest = new System.Windows.Forms.RichTextBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.txaResponse = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboConsultas = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVersaoXML = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Escolha o certificado:";
            // 
            // cboCertificado
            // 
            this.cboCertificado.FormattingEnabled = true;
            this.cboCertificado.Location = new System.Drawing.Point(128, 5);
            this.cboCertificado.Name = "cboCertificado";
            this.cboCertificado.Size = new System.Drawing.Size(773, 21);
            this.cboCertificado.TabIndex = 1;
            // 
            // txaRequest
            // 
            this.txaRequest.Location = new System.Drawing.Point(16, 111);
            this.txaRequest.Name = "txaRequest";
            this.txaRequest.Size = new System.Drawing.Size(885, 151);
            this.txaRequest.TabIndex = 2;
            this.txaRequest.Text = "";
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(656, 268);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(245, 23);
            this.btnEnviar.TabIndex = 3;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // txaResponse
            // 
            this.txaResponse.Location = new System.Drawing.Point(16, 325);
            this.txaResponse.Name = "txaResponse";
            this.txaResponse.Size = new System.Drawing.Size(885, 155);
            this.txaResponse.TabIndex = 4;
            this.txaResponse.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Escolha a consulta:";
            // 
            // cboConsultas
            // 
            this.cboConsultas.FormattingEnabled = true;
            this.cboConsultas.Location = new System.Drawing.Point(128, 29);
            this.cboConsultas.Name = "cboConsultas";
            this.cboConsultas.Size = new System.Drawing.Size(773, 21);
            this.cboConsultas.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Versão do XML:";
            // 
            // txtVersaoXML
            // 
            this.txtVersaoXML.Location = new System.Drawing.Point(128, 54);
            this.txtVersaoXML.Name = "txtVersaoXML";
            this.txtVersaoXML.Size = new System.Drawing.Size(83, 20);
            this.txtVersaoXML.TabIndex = 8;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 498);
            this.Controls.Add(this.txtVersaoXML);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboConsultas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txaResponse);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.txaRequest);
            this.Controls.Add(this.cboCertificado);
            this.Controls.Add(this.label1);
            this.Name = "FormPrincipal";
            this.Text = "NFe Prefeitura São Paulo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboCertificado;
        private System.Windows.Forms.RichTextBox txaRequest;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.RichTextBox txaResponse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboConsultas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtVersaoXML;
    }
}

