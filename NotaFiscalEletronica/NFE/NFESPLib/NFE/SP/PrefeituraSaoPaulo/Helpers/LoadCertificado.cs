namespace NFESPLib.NFE.SP.PrefeituraSaoPaulo.Helpers
{

    using System;
    using System.Security.Cryptography.X509Certificates;

    public class LoadCertificado
    {

        public LoadCertificado() { }

        public X509Certificate2 FindCert(string thumbprint)
        {
            X509Store store = new X509Store("My");
            store.Open(OpenFlags.ReadOnly);
            X509Certificate2 cert = null;
            foreach (X509Certificate2 mCert in store.Certificates)

            {
                if (mCert.Thumbprint.Equals(thumbprint))
                {
                    cert = mCert;
                    break;
                }
            }
            store.Close();

            if (cert == null)
                throw new Exception("Não foi possível encontrar o certificado com o thumbprint enviado (" + thumbprint + ").");

            return cert;
        }

    }
}
