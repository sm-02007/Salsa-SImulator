namespace SalsaSimulator.Models;

public class Build
{
    public int Id { get; set; }
    public string Slug { get; set; } = string.Empty;       // ej: "tropical-gourmet"
    public string Nombre { get; set; } = string.Empty;
    public string Emoji { get; set; } = string.Empty;
    public string Ingredientes { get; set; } = string.Empty; // descripción textual
    public string NotasSabor { get; set; } = string.Empty;
    public double Picante { get; set; }
    public int DiasFerrmentacion { get; set; }
    public string ResultadoEsperado { get; set; } = string.Empty;
    public bool EsPeligrosa { get; set; }

    // Composición de ajíes en JSON (se parsea en el servicio)
    // Formato: [{"nombre":"Habanero","porcentaje":40}, ...]
    public string ComposicionJson { get; set; } = "[]";
}
