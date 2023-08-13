namespace TiendaProductos.Services.IServices
{
    public interface ITokenProviderService
    {
        void SetToken(string token);

        string? GetToken();

        void ClearToken();
    }
}
