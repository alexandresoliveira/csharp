namespace NFESPLib.NFE.SP.PrefeituraSaoPaulo.Assinatura
{
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Xml;

    public class AssinarRPS
    {

        public AssinarRPS() { }
        
        public string assinarEmLote(string xml, X509Certificate2 certificado)
        {

            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = false;
            doc.LoadXml(xml);

            XmlNodeList atributos = doc.ChildNodes.Item(0).ChildNodes;

            for ( int count = 0; count < atributos.Count; count++ )
            {
                if (!atributos.Item(count).Name.Equals("RPS"))
                    continue;

                XmlNode rpsNode = atributos.Item(count);

                string referencia = DefinirReferenciaParaAssinaturaRPS(rpsNode);

                string referenciaCriptografada = CriptografarReferencia(referencia, certificado);

                rpsNode.ChildNodes.Item(0).InnerText = referenciaCriptografada;
            }
            
            return doc.OuterXml;
        }

        public string assinar(string xml, X509Certificate2 certificado)
        {
            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = false;
            doc.LoadXml(xml);

            XmlNode rpsNode = doc.ChildNodes.Item(0).ChildNodes.Item(1);
            
            string referencia = DefinirReferenciaParaAssinaturaRPS(rpsNode);

            string referenciaCriptografada = CriptografarReferencia(referencia, certificado);

            rpsNode.ChildNodes.Item(0).InnerText = referenciaCriptografada;

            return doc.OuterXml;
        }

        private string DefinirReferenciaParaAssinaturaRPS(XmlNode rsp)
        {

            string InscricaoPrestador = "";
            string SerieRPS = "";
            string NumeroRPS = "";
            string DataEmissao = "";
            string StatusRPS = "";
            string TributacaoRPS = "";
            string ISSRetido = "";
            string ValorServicos = "";
            string ValorDeducoes = "";
            string CodigoServico = "";
            string CPFCNPJTomador = "";

            XmlNodeList rpsAtributos = rsp.ChildNodes;

            for (int count = 0; count < rpsAtributos.Count; count++)
            {

                XmlNode rpsElement = rpsAtributos.Item(count);

                if (!VerificarElemento(rpsElement.Name))
                    continue;

                if (rpsElement.Name.Equals("ChaveRPS"))
                {
                    XmlNodeList chaveRPS = rpsElement.ChildNodes;
                    for (int countChaveRPS = 0; countChaveRPS < chaveRPS.Count; countChaveRPS++)
                    {
                        XmlNode chaveRPSElement = chaveRPS.Item(countChaveRPS);

                        if (chaveRPSElement.Name.Equals("InscricaoPrestador"))
                            InscricaoPrestador = CompletarComZerosAEsquerda(chaveRPSElement.InnerText, 8);

                        if (chaveRPSElement.Name.Equals("SerieRPS"))
                            SerieRPS = CompletarComEspacosEmBrancoADireita(chaveRPSElement.InnerText, 5);

                        if (chaveRPSElement.Name.Equals("NumeroRPS"))
                            NumeroRPS = CompletarComZerosAEsquerda(chaveRPSElement.InnerText, 12);

                    }
                }

                if (rpsElement.Name.Equals("DataEmissao"))
                    DataEmissao += FormatarData(rpsElement.InnerText);

                if (rpsElement.Name.Equals("StatusRPS"))
                    StatusRPS += rpsElement.InnerText;

                if (rpsElement.Name.Equals("TributacaoRPS"))
                    TributacaoRPS += rpsElement.InnerText;

                if (rpsElement.Name.Equals("ISSRetido"))
                    ISSRetido += EUmISSRetido(rpsElement.InnerText);

                if (rpsElement.Name.Equals("ValorServicos"))
                {
                    string valor = rpsElement.InnerText.Replace(".", "").Replace(",", "");
                    ValorServicos += CompletarComZerosAEsquerda(valor, 15);
                }

                if (rpsElement.Name.Equals("ValorDeducoes"))
                {
                    string valor = rpsElement.InnerText.Replace(".", "").Replace(",", "");
                    ValorDeducoes += CompletarComZerosAEsquerda(valor, 15);
                }

                if (rpsElement.Name.Equals("CodigoServico"))
                    CodigoServico += CompletarComZerosAEsquerda(rpsElement.InnerText, 5);

                if (rpsElement.Name.Equals("CPFCNPJTomador"))
                    CPFCNPJTomador += FormatarCPFCNPJTomador(rpsElement.InnerText);

            }

            return  InscricaoPrestador +
                    SerieRPS +
                    NumeroRPS +
                    DataEmissao +
                    TributacaoRPS +
                    StatusRPS +
                    ISSRetido +
                    ValorServicos +
                    ValorDeducoes +
                    CodigoServico +
                    CPFCNPJTomador;
        }

        private string CriptografarReferencia(string referencia, X509Certificate2 certificado)
        {

            RSACryptoServiceProvider rsa = certificado.PrivateKey as RSACryptoServiceProvider;
            byte[] sAssinaturaByte = new ASCIIEncoding().GetBytes(referencia);
            RSAPKCS1SignatureFormatter rsaf = new RSAPKCS1SignatureFormatter(rsa);
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();

            byte[] hash = sha1.ComputeHash(sAssinaturaByte);

            rsaf.SetHashAlgorithm("SHA1");
            sAssinaturaByte = rsaf.CreateSignature(hash);

            return Convert.ToBase64String(sAssinaturaByte);
        }

        private string FormatarData(string value)
        {
            string valorFinal = "";
            valorFinal += value.Split('-')[0];
            valorFinal += value.Split('-')[1];
            valorFinal += value.Split('-')[2];
            return valorFinal;
        }

        private string EUmISSRetido(string issRetido)
        {
            return issRetido.ToLower().Equals("true") ? "S" : "N";
        }

        private string FormatarCPFCNPJTomador(string CPFCNPJTomador)
        {
            if (CPFCNPJTomador.Length <= 0)
                return 3 + "00000000000000";
            else if (CPFCNPJTomador.Length == 11)
                return 1 + CompletarComZerosAEsquerda(CPFCNPJTomador, 14);
            else
                return 2 + CPFCNPJTomador;
        }

        private string CompletarComEspacosEmBrancoADireita(string value, int maxPosicoes)
        {
            string espacos = "";
            for (int count = 0; count < (maxPosicoes - value.Length); count++)
                espacos += " ";
            return value + espacos;
        }

        private string CompletarComZerosAEsquerda(string value, int maxPosicoes)
        {
            string zeros = "";
            for (int cont = 0; cont < (maxPosicoes - value.Length);  cont++)
                zeros += "0";
            return zeros + value;
        }

        private bool VerificarElemento(string Nome)
        {
            List<string> TagsValidasParaAAssinatura = new List<string>();

            TagsValidasParaAAssinatura.Add("ChaveRPS");
            TagsValidasParaAAssinatura.Add("DataEmissao");
            TagsValidasParaAAssinatura.Add("StatusRPS");
            TagsValidasParaAAssinatura.Add("TributacaoRPS");
            TagsValidasParaAAssinatura.Add("ValorServicos");
            TagsValidasParaAAssinatura.Add("ValorDeducoes");
            TagsValidasParaAAssinatura.Add("CodigoServico");
            TagsValidasParaAAssinatura.Add("ISSRetido");
            TagsValidasParaAAssinatura.Add("CPFCNPJTomador");

            return TagsValidasParaAAssinatura.Contains(Nome);
        }

    }

}
