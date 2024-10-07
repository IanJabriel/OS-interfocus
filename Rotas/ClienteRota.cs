namespace ApiCrud.Rotas
{
    public static class ClienteRota
    {
        public static void RotasClientes(WebApplication app)
        {
            app.MapGet("Clientes", () => "Olá clientes");
        }
    }
}
