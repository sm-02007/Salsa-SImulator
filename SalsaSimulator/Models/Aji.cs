namespace SalsaSimulator.Models;

public class Aji
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string PaisRegion { get; set; } = string.Empty;
    public double Picante { get; set; }          // 0-10
    public string ScovilleEstimado { get; set; } = string.Empty;
    public string PerfilSabor { get; set; } = string.Empty;
    public string NotasAromaticas { get; set; } = string.Empty;
    public double Frutalidad { get; set; }       // 0-10
    public double Dulzor { get; set; }           // 0-10
    public double Ahumado { get; set; }          // 0-10
    public double Frescura { get; set; }         // 0-10
    public double Complejidad { get; set; }      // 0-10
    public double Persistencia { get; set; }     // 0-10
    public string ColorPrincipal { get; set; } = string.Empty;
    public string AporteSalsa { get; set; } = string.Empty;
    public string FuncionIdeal { get; set; } = string.Empty;
    public bool FermentaBien { get; set; }
    public string DificultadConseguir { get; set; } = string.Empty;
    public string CombinaCon { get; set; } = string.Empty;
    public string RiesgoDominar { get; set; } = string.Empty;
}
