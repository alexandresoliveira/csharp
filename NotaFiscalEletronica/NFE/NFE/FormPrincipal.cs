namespace TesteDllNFe
{
    using NFESPLib.NFE.SP.PrefeituraSaoPaulo.Services;
    using System;
    using System.Security.Cryptography.X509Certificates;
    using System.Windows.Forms;

    public partial class FormPrincipal : Form
    {
        
        public FormPrincipal()
        {
            InitializeComponent();
            CarregarListaDeCertificados();
            CarregarConsultas();
        }

        private void CarregarConsultas()
        {
            cboConsultas.Items.Clear();

            cboConsultas.Items.Add(new ConsultaComboBoxItem(0, "Consulta CNPJ"));
            cboConsultas.Items.Add(new ConsultaComboBoxItem(1, "Cancelamento NFe"));
            cboConsultas.Items.Add(new ConsultaComboBoxItem(2, "Consulta Informacoes Lote"));
            cboConsultas.Items.Add(new ConsultaComboBoxItem(3, "Consulta Lote"));
            cboConsultas.Items.Add(new ConsultaComboBoxItem(4, "Consulta NFe"));
            cboConsultas.Items.Add(new ConsultaComboBoxItem(5, "Consulta NFe Emitidas"));
            cboConsultas.Items.Add(new ConsultaComboBoxItem(6, "Consulta NFe Recebidas"));
            cboConsultas.Items.Add(new ConsultaComboBoxItem(7, "Envio Lote RPS"));
            cboConsultas.Items.Add(new ConsultaComboBoxItem(8, "Envio RPS"));
            cboConsultas.Items.Add(new ConsultaComboBoxItem(9, "Teste Envio Lote RPS"));

            cboConsultas.DisplayMember = "Name";
            cboConsultas.ValueMember = "Value";
        }

        private void CarregarListaDeCertificados()
        {
            X509Store store = new X509Store("My");
            store.Open(OpenFlags.ReadOnly);
            foreach (X509Certificate2 mCert in store.Certificates)
            {
                cboCertificado.Items.Add(mCert);
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {

            X509Certificate2 certificado = cboCertificado.SelectedItem as X509Certificate2;
            if (certificado == null)
            {
                MessageBox.Show("Escolha um certificado.", "Certificado Inválido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            ConsultaComboBoxItem item = cboConsultas.SelectedItem as ConsultaComboBoxItem;
            if (item == null)
            {
                MessageBox.Show("Escolha uma consulta.", "Consulta Inválida!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            switch (item.Value)
            {
                case 0:
                    txaResponse.Text = new ConsultaCNPJ().conectar(1, txaRequest.Text, certificado.Thumbprint);
                    break;
                case 1:
                    txaResponse.Text = new CancelamentoNFe().conectar(1, txaRequest.Text, certificado.Thumbprint);
                    break;
                case 2:
                    txaResponse.Text = new ConsultaInformacoesLote().conectar(1, txaRequest.Text, certificado.Thumbprint);
                    break;
                case 3:
                    txaResponse.Text = new ConsultaLote().conectar(1, txaRequest.Text, certificado.Thumbprint);
                    break;
                case 4:
                    txaResponse.Text = new ConsultaNFe().conectar(1, txaRequest.Text, certificado.Thumbprint);
                    break;
                case 5:
                    txaResponse.Text = new ConsultaNFeEmitidas().conectar(1, txaRequest.Text, certificado.Thumbprint);
                    break;
                case 6:
                    txaResponse.Text = new ConsultaNFeRecebidas().conectar(1, txaRequest.Text, certificado.Thumbprint);
                    break;
                case 7:
                    txaResponse.Text = new EnvioLoteRPS().conectar(1, txaRequest.Text, certificado.Thumbprint);
                    break;
                case 8:
                    txaResponse.Text = new EnvioRPS().conectar(1, txaRequest.Text, certificado.Thumbprint);
                    break;
                case 9:
                    txaResponse.Text = new TesteEnvioLoteRPS().conectar(1, txaRequest.Text, certificado.Thumbprint);
                    break;
                default:
                    MessageBox.Show("Escolha uma consulta.", "Consulta Inválida!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
            }
        }

    }
}
