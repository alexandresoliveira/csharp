namespace NFESPLib.NFE.SP.PrefeituraSaoPaulo.Services.Interfaces
{
    using System.Runtime.InteropServices;

    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface IConsultaNFe
    {
        string conectar(int versaoSchema, string xml, string certificado);
    }
}
