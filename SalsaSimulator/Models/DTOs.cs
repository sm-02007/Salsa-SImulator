namespace SalsaSimulator.Models;

// ─────────────────────────────────────────────
// Lo que manda el formulario al servicio
// ─────────────────────────────────────────────
public class RecetaInput
{
    // Hasta 10 ajíes con sus gramos
    public List<AjiInput> Ajies { get; set; } = new();

    // Ingredientes extra (en gramos o ml salvo donde se indica)
    public double Ajo { get; set; }              // dientes
    public double CebollaBlanca { get; set; }   // g
    public double CebollaMorada { get; set; }   // g
    public double Zanahoria { get; set; }       // g
    public double Mango { get; set; }           // g
    public double Pina { get; set; }            // g
    public double Manzana { get; set; }         // g
    public double Tomate { get; set; }          // g
    public double Morron { get; set; }          // g
    public double Miel { get; set; }            // g
    public double Azucar { get; set; }          // g
    public double VinagreBlanco { get; set; }   // ml
    public double VinagreManzana { get; set; }  // ml
    public double Limon { get; set; }           // ml
    public int Especias { get; set; }           // nivel 0-5

    // Fermentación
    public double SalPorcentaje { get; set; } = 2.0;
    public int DiasFerrmentacion { get; set; } = 5;
    public double TemperaturaC { get; set; } = 25.0;
}

public class AjiInput
{
    public string Nombre { get; set; } = string.Empty;
    public double Gramos { get; set; }
}

// ─────────────────────────────────────────────
// Lo que devuelve el servicio de cálculo
// ─────────────────────────────────────────────
public class PerfilSalsa
{
    // Atributos 0-10
    public double Picante { get; set; }
    public double Dulzor { get; set; }
    public double Acidez { get; set; }
    public double TropicalFrutal { get; set; }
    public double Umami { get; set; }
    public double Complejidad { get; set; }
    public double Frescura { get; set; }
    public double Ahumado { get; set; }
    public double Ferocidad { get; set; }
    public double Balance { get; set; }
    public double Persistencia { get; set; }

    // Predicciones adicionales
    public string ColorEsperado { get; set; } = string.Empty;
    public string TexturaEstimada { get; set; } = string.Empty;
    public string PrediccionTextual { get; set; } = string.Empty;

    // Recomendaciones del motor de reglas
    public List<Recomendacion> Recomendaciones { get; set; } = new();
}

public class Recomendacion
{
    public string Tipo { get; set; } = string.Empty;  // "ok", "warning", "sugerencia"
    public string Mensaje { get; set; } = string.Empty;
}