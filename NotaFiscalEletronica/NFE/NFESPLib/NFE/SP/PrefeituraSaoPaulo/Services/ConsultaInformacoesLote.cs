namespace NFESPLib.NFE.SP.PrefeituraSaoPaulo.Services
{
    using Assinatura;
    using Interfaces;
    using System;
    using System.Runtime.InteropServices;

    [ClassInterface(ClassInterfaceType.None)]
    public class ConsultaInformacoesLote : BaseServicePrefeituraSaoPaulo, IConsultaInformacoesLote
    {

        public ConsultaInformacoesLote() : base() { }

        public string conectar(int versaoSchema, string xml, string thumbprint)
        {
            string retorno = "";
            try
            {
                LoadClient(thumbprint);
                retorno = new Assinar().AssinarComCertificado(xml, Certificado);
                retorno = LoteNFeClient.ConsultaInformacoesLote(versaoSchema, retorno);
            }
            catch (Exception error)
            {
                retorno = error.Message;
            }
            return retorno;
        }
    }
}
