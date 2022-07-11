namespace NFESPLib.NFE.SP.PrefeituraSaoPaulo.Services
{
    using NFEPrefeituraSaoPauloService;
    using System.ServiceModel;
    using System.Security.Cryptography.X509Certificates;
    using Helpers;

    public class BaseServicePrefeituraSaoPaulo
    {

        public BaseServicePrefeituraSaoPaulo() { }

        public void LoadClient(string certificado)
        {

            Certificado = new LoadCertificado().FindCert(certificado);

            BasicHttpsBinding binding = new BasicHttpsBinding();
            binding.Name = "LoteNFeSoapHttps";
            binding.Security.Mode = BasicHttpsSecurityMode.Transport;
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate;

            EndpointAddress endpoitAddress = new EndpointAddress("https://nfe.prefeitura.sp.gov.br/ws/lotenfe.asmx");

            LoteNFeClient = new LoteNFeSoapClient(remoteAddress: endpoitAddress, binding: binding);
            LoteNFeClient.Endpoint.Binding = binding;
            LoteNFeClient.ChannelFactory.Credentials.ClientCertificate.Certificate = Certificado;
        }

        public LoteNFeSoapClient LoteNFeClient { get; set; }
        public X509Certificate2 Certificado { get; set; }

    }
}
