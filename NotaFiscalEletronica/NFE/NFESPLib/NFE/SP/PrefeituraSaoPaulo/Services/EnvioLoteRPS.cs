namespace NFESPLib.NFE.SP.PrefeituraSaoPaulo.Services
{
    using Assinatura;
    using Interfaces;
    using System;
    using System.Runtime.InteropServices;

    [ClassInterface(ClassInterfaceType.None)]
    public class EnvioLoteRPS : BaseServicePrefeituraSaoPaulo, IEnvioLoteRPS
    {

        public EnvioLoteRPS() : base() { }

        public string conectar(int versaoSchema, string xml, string thumbprint)
        {
            string retorno = "";
            try
            {
                LoadClient(thumbprint);
                xml = new AssinarRPS().assinarEmLote(xml, Certificado);
                retorno = new Assinar().AssinarComCertificado(xml, Certificado);
                retorno = LoteNFeClient.EnvioLoteRPS(versaoSchema, retorno);
            }
            catch (Exception error)
            {
                retorno = error.Message;
            }
            return retorno;
        }
    }
}
