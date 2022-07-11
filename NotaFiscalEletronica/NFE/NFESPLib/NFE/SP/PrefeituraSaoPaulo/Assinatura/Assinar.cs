namespace NFESPLib.NFE.SP.PrefeituraSaoPaulo.Assinatura
{

    using System;
    using System.Security.Cryptography.X509Certificates;
    using System.Security.Cryptography.Xml;
    using System.Xml;

    public class Assinar
    {

        public Assinar() { }

        public string AssinarComCertificado(string textXML, X509Certificate2 certificado)
        {
            try
            {
                string xmlString = textXML;

                XmlDocument doc = new XmlDocument();
                doc.PreserveWhitespace = false;
                doc.LoadXml(xmlString);

                Reference reference = new Reference();
                reference.Uri = "";

                XmlDocument documentoNovo = new XmlDocument();
                documentoNovo.LoadXml(doc.OuterXml);

                SignedXml signedXml = new SignedXml(documentoNovo);

                signedXml.SigningKey = certificado.PrivateKey;

                XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
                reference.AddTransform(env);

                XmlDsigC14NTransform c14 = new XmlDsigC14NTransform();
                reference.AddTransform(c14);

                signedXml.AddReference(reference);

                KeyInfo keyInfo = new KeyInfo();

                keyInfo.AddClause(new KeyInfoX509Data(certificado));

                signedXml.KeyInfo = keyInfo;
                signedXml.ComputeSignature();

                XmlElement xmlDigitalSignature = signedXml.GetXml();

                XmlNode sign = doc.ImportNode(xmlDigitalSignature, true);
                doc.ChildNodes.Item(0).AppendChild(sign);

                XmlDocument XMLDoc = new XmlDocument();
                XMLDoc.PreserveWhitespace = false;
                XMLDoc = doc;

                return XMLDoc.OuterXml;

            } catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }
    }
}
