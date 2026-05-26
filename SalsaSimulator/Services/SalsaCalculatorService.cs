using SalsaSimulator.Models;

namespace SalsaSimulator.Services;

public class SalsaCalculatorService
{
    public PerfilSalsa Calcular(RecetaInput input, List<Aji> catalogoAjies)
    {
        // ─── 1. Construir la mezcla de ajíes ponderada por gramos ───
        var totalGramos = input.Ajies
            .Where(a => !string.IsNullOrEmpty(a.Nombre) && a.Gramos > 0)
            .Sum(a => a.Gramos);

        var mezcla = input.Ajies
            .Where(a => !string.IsNullOrEmpty(a.Nombre) && a.Gramos > 0)
            .Select(a => new
            {
                Aji = catalogoAjies.FirstOrDefault(c =>
                    string.Equals(c.Nombre, a.Nombre, StringComparison.OrdinalIgnoreCase)),
                Peso = totalGramos > 0 ? a.Gramos / totalGramos : 0
            })
            .Where(x => x.Aji != null)
            .ToList();

        // ─── 2. Atributos base ponderados de los ajíes ───
        double picante = mezcla.Sum(x => x.Aji!.Picante * x.Peso);
        double frutalidad = mezcla.Sum(x => x.Aji!.Frutalidad * x.Peso);
        double dulzor = mezcla.Sum(x => x.Aji!.Dulzor * x.Peso);
        double ahumado = mezcla.Sum(x => x.Aji!.Ahumado * x.Peso);
        double frescura = mezcla.Sum(x => x.Aji!.Frescura * x.Peso);
        double complejidad = mezcla.Sum(x => x.Aji!.Complejidad * x.Peso);
        double persistencia = mezcla.Sum(x => x.Aji!.Persistencia * x.Peso);

        // ─── 3. Modificadores por ingredientes extra ───

        // Dulzor: miel, azúcar, mango, piña, zanahoria, manzana
        double totalMasa = Math.Max(totalGramos, 1);
        double aporteDulzor =
            (input.Miel / totalMasa * 15) +
            (input.Azucar / totalMasa * 12) +
            (input.Mango / totalMasa * 8) +
            (input.Pina / totalMasa * 7) +
            (input.Zanahoria / totalMasa * 4) +
            (input.Manzana / totalMasa * 5);
        dulzor = Math.Min(10, dulzor + aporteDulzor);

        // Frutalidad: mango, piña, manzana
        double aporteFrutal =
            (input.Mango / totalMasa * 10) +
            (input.Pina / totalMasa * 8) +
            (input.Manzana / totalMasa * 6);
        frutalidad = Math.Min(10, frutalidad + aporteFrutal);

        // Acidez: vinagre, limón, tomate
        double acidez =
            (input.VinagreBlanco / totalMasa * 10) +
            (input.VinagreManzana / totalMasa * 8) +
            (input.Limon / totalMasa * 9) +
            (input.Tomate / totalMasa * 3);
        acidez = Math.Min(10, acidez);

        // Umami: tomate, ajo, cebolla, morrón, fermentación larga
        double umami =
            (input.Tomate / totalMasa * 6) +
            (input.Ajo / totalMasa * 8) +  // dientes → efecto fuerte
            (input.CebollaBlanca / totalMasa * 3) +
            (input.CebollaMorada / totalMasa * 3) +
            (input.Morron / totalMasa * 4);
        // La fermentación larga sube el umami
        umami += input.DiasFerrmentacion switch
        {
            >= 14 => 2.5,
            >= 8 => 1.5,
            >= 4 => 0.5,
            _ => 0
        };
        umami = Math.Min(10, umami);

        // Frescura: se reduce con días de fermentación y temperatura alta
        frescura -= input.DiasFerrmentacion * 0.15;
        frescura -= Math.Max(0, (input.TemperaturaC - 25) * 0.1);
        frescura = Math.Clamp(frescura, 0, 10);

        // Complejidad: sube con más ajíes distintos, especias y fermentación
        int ajiesDistintos = mezcla.Count;
        complejidad += ajiesDistintos * 0.3;
        complejidad += input.Especias * 0.4;
        complejidad += input.DiasFerrmentacion switch
        {
            >= 10 => 1.5,
            >= 5 => 0.8,
            _ => 0
        };
        complejidad = Math.Min(10, complejidad);

        // Picante: la sal alta y temperatura alta aceleran la extracción
        if (input.SalPorcentaje > 3) picante = Math.Min(10, picante + 0.3);
        if (input.TemperaturaC > 30) picante = Math.Min(10, picante + 0.2);

        // ─── 4. Ferocidad (combinación de picante + persistencia) ───
        double ferocidad = Math.Min(10, (picante * 0.7) + (persistencia * 0.3));

        // ─── 5. Balance ───
        // Un balance perfecto = todos los atributos parejos, sin extremos
        var atributos = new[] { picante, dulzor, acidez, frutalidad, umami, frescura };
        double promedio = atributos.Average();
        double desviacion = atributos.Average(a => Math.Abs(a - promedio));
        double balance = Math.Max(0, 10 - desviacion * 1.5);

        // ─── 6. Color esperado ───
        string color = DeterminarColor(mezcla.Select(x => x.Aji!).ToList(),
                                       mezcla.Select(x => x.Peso).ToList(),
                                       input);

        // ─── 7. Textura estimada ───
        string textura = DeterminarTextura(input, totalMasa);

        // ─── 8. Predicción textual ───
        string prediccion = GenerarPrediccion(picante, dulzor, acidez,
                                              frutalidad, ahumado, umami,
                                              complejidad, input.DiasFerrmentacion);

        // ─── 9. Recomendaciones ───
        var recomendaciones = GenerarRecomendaciones(input, picante, acidez,
                                                     dulzor, ahumado, balance,
                                                     mezcla.Count);

        return new PerfilSalsa
        {
            Picante = Math.Round(picante, 1),
            Dulzor = Math.Round(dulzor, 1),
            Acidez = Math.Round(acidez, 1),
            TropicalFrutal = Math.Round(frutalidad, 1),
            Umami = Math.Round(umami, 1),
            Complejidad = Math.Round(complejidad, 1),
            Frescura = Math.Round(frescura, 1),
            Ahumado = Math.Round(ahumado, 1),
            Ferocidad = Math.Round(ferocidad, 1),
            Balance = Math.Round(balance, 1),
            Persistencia = Math.Round(persistencia, 1),
            ColorEsperado = color,
            TexturaEstimada = textura,
            PrediccionTextual = prediccion,
            Recomendaciones = recomendaciones
        };
    }

    // ─────────────────────────────────────────────────────────────
    // HELPERS
    // ─────────────────────────────────────────────────────────────

    private string DeterminarColor(List<Aji> ajies, List<double> pesos, RecetaInput input)
    {
        // Color dominante por peso
        var dominante = ajies
            .Zip(pesos, (a, p) => (a.ColorPrincipal, p))
            .OrderByDescending(x => x.p)
            .FirstOrDefault();

        string colorBase = dominante.ColorPrincipal ?? "Rojo";

        // Modificadores
        if (input.Mango > 50 || input.Pina > 50)
            colorBase = "Naranja-amarillo tropical";
        if (input.Tomate > 100)
            colorBase = "Rojo tomate";

        return colorBase;
    }

    private string DeterminarTextura(RecetaInput input, double totalMasa)
    {
        double liquidos = input.VinagreBlanco + input.VinagreManzana + input.Limon;
        double ratio = liquidos / Math.Max(totalMasa, 1);

        return ratio switch
        {
            > 0.5 => "Muy líquida (tipo Louisiana)",
            > 0.3 => "Líquida",
            > 0.1 => "Semi-espesa",
            _ => "Espesa / pasta"
        };
    }

    private string GenerarPrediccion(double picante, double dulzor, double acidez,
                                     double frutalidad, double ahumado, double umami,
                                     double complejidad, int dias)
    {
        var partes = new List<string>();

        partes.Add(picante switch
        {
            >= 9 => "🔥 Picante nuclear — no apta para corazones débiles",
            >= 7 => "🌶 Picante intenso con mucho carácter",
            >= 5 => "Picante moderado, agradable para la mayoría",
            >= 3 => "Calor suave, accesible",
            _ => "Sin picante relevante"
        });

        if (dulzor >= 6) partes.Add("dulzor notable que equilibra el fuego");
        if (acidez >= 6) partes.Add("acidez vibrante y refrescante");
        if (frutalidad >= 7) partes.Add("notas frutales y tropicales prominentes");
        if (ahumado >= 6) partes.Add("fondo ahumado tipo BBQ");
        if (umami >= 6) partes.Add("profundidad umami que engancha");

        if (complejidad >= 8)
            partes.Add($"Complejidad alta — esta salsa va a sorprender");
        else if (complejidad >= 5)
            partes.Add("Perfil de sabor equilibrado y redondo");

        if (dias >= 10)
            partes.Add($"La fermentación de {dias} días va a aportar acidez y profundidad extra");
        else if (dias >= 4)
            partes.Add($"{dias} días de fermentación — buen equilibrio de frescura y profundidad");

        return string.Join(". ", partes) + ".";
    }

    private List<Recomendacion> GenerarRecomendaciones(RecetaInput input, double picante,
        double acidez, double dulzor, double ahumado, double balance, int cantAjies)
    {
        var lista = new List<Recomendacion>();

        // Picante sin dulzor
        if (picante >= 8 && dulzor < 4)
            lista.Add(new Recomendacion
            {
                Tipo = "sugerencia",
                Mensaje = "🍯 El picante es muy alto y no hay dulzor que lo equilibre. Considerá agregar mango, zanahoria o miel."
            });

        // Demasiado ácida
        if (acidez >= 8 && dulzor < 3)
            lista.Add(new Recomendacion
            {
                Tipo = "warning",
                Mensaje = "⚠️ La acidez es muy alta. Un poco de miel o azúcar va a redondear el perfil."
            });

        // Sal fuera de rango seguro
        if (input.SalPorcentaje < 1.5)
            lista.Add(new Recomendacion
            {
                Tipo = "warning",
                Mensaje = "🧂 Sal muy baja (< 1.5%). La fermentación puede ser insegura. Recomendado: 2-3%."
            });
        if (input.SalPorcentaje > 5)
            lista.Add(new Recomendacion
            {
                Tipo = "warning",
                Mensaje = "🧂 Sal muy alta (> 5%). Va a dominar el sabor e inhibir la fermentación."
            });

        // Temperatura de fermentación
        if (input.TemperaturaC > 35)
            lista.Add(new Recomendacion
            {
                Tipo = "warning",
                Mensaje = "🌡️ Temperatura muy alta. Riesgo de fermentación no controlada. Mejor entre 18-28°C."
            });
        if (input.TemperaturaC < 15)
            lista.Add(new Recomendacion
            {
                Tipo = "sugerencia",
                Mensaje = "🌡️ Temperatura baja — la fermentación va a ser muy lenta. Considerá subir a 20°C+."
            });

        // Fermentación muy larga con ajíes frescos
        if (input.DiasFerrmentacion > 14 && cantAjies > 0)
            lista.Add(new Recomendacion
            {
                Tipo = "sugerencia",
                Mensaje = "📅 Fermentación muy larga. Revisá el frasco diariamente para evitar exceso de acidez o moho."
            });

        // Balance
        if (balance >= 7)
            lista.Add(new Recomendacion
            {
                Tipo = "ok",
                Mensaje = "⚖️ Buen balance general — la salsa tiene un perfil redondo."
            });
        else if (balance < 4)
            lista.Add(new Recomendacion
            {
                Tipo = "sugerencia",
                Mensaje = "⚖️ El perfil está desbalanceado. Intentá agregar un ingrediente que contrarreste el atributo dominante."
            });

        // Muy pocos ingredientes
        if (cantAjies == 1 && input.Ajo == 0 && input.CebollaBlanca == 0)
            lista.Add(new Recomendacion
            {
                Tipo = "sugerencia",
                Mensaje = "🧄 Con un solo ají la salsa puede ser muy plana. Agregá ajo, cebolla o algún extra para darle profundidad."
            });

        if (lista.Count == 0)
            lista.Add(new Recomendacion
            {
                Tipo = "ok",
                Mensaje = "✅ La receta se ve bien. ¡A fermentar!"
            });

        return lista;
    }
}