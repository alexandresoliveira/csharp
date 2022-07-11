namespace NFESPLib.NFE.SP.PrefeituraSaoPaulo.Services.Interfaces
{
    using System.Runtime.InteropServices;

    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface ICancelamentoNFe
    {
        string conectar(int versaoSchema, string xml, string certificado);
    }
}
