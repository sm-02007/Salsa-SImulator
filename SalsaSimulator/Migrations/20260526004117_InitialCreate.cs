using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SalsaSimulator.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ajies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    PaisRegion = table.Column<string>(type: "TEXT", nullable: false),
                    Picante = table.Column<double>(type: "REAL", nullable: false),
                    ScovilleEstimado = table.Column<string>(type: "TEXT", nullable: false),
                    PerfilSabor = table.Column<string>(type: "TEXT", nullable: false),
                    NotasAromaticas = table.Column<string>(type: "TEXT", nullable: false),
                    Frutalidad = table.Column<double>(type: "REAL", nullable: false),
                    Dulzor = table.Column<double>(type: "REAL", nullable: false),
                    Ahumado = table.Column<double>(type: "REAL", nullable: false),
                    Frescura = table.Column<double>(type: "REAL", nullable: false),
                    Complejidad = table.Column<double>(type: "REAL", nullable: false),
                    Persistencia = table.Column<double>(type: "REAL", nullable: false),
                    ColorPrincipal = table.Column<string>(type: "TEXT", nullable: false),
                    AporteSalsa = table.Column<string>(type: "TEXT", nullable: false),
                    FuncionIdeal = table.Column<string>(type: "TEXT", nullable: false),
                    FermentaBien = table.Column<bool>(type: "INTEGER", nullable: false),
                    DificultadConseguir = table.Column<string>(type: "TEXT", nullable: false),
                    CombinaCon = table.Column<string>(type: "TEXT", nullable: false),
                    RiesgoDominar = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ajies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Builds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Slug = table.Column<string>(type: "TEXT", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Emoji = table.Column<string>(type: "TEXT", nullable: false),
                    Ingredientes = table.Column<string>(type: "TEXT", nullable: false),
                    NotasSabor = table.Column<string>(type: "TEXT", nullable: false),
                    Picante = table.Column<double>(type: "REAL", nullable: false),
                    DiasFerrmentacion = table.Column<int>(type: "INTEGER", nullable: false),
                    ResultadoEsperado = table.Column<string>(type: "TEXT", nullable: false),
                    EsPeligrosa = table.Column<bool>(type: "INTEGER", nullable: false),
                    ComposicionJson = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Builds", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Ajies",
                columns: new[] { "Id", "Ahumado", "AporteSalsa", "ColorPrincipal", "CombinaCon", "Complejidad", "DificultadConseguir", "Dulzor", "FermentaBien", "Frescura", "Frutalidad", "FuncionIdeal", "Nombre", "NotasAromaticas", "PaisRegion", "PerfilSabor", "Persistencia", "Picante", "RiesgoDominar", "ScovilleEstimado" },
                values: new object[,]
                {
                    { 1, 2.0, "Frescura y picante base; excelente equilibrio", "Verde brillante", "Ajo, cilantro, limón, serrano, cebolla", 5.0, "Fácil", 3.0, true, 9.0, 4.0, "Base / Personalidad", "Jalapeño", "Hierba fresca, verde, pimiento", "México", "Verde fresco, herbáceo, vegetal con toque de calor moderado", 4.0, 4.0, "Bajo", "2,500–8,000" },
                    { 2, 1.0, "Picante limpio y fresco, estructura vegetal", "Verde oscuro", "Jalapeño, tomatillo, cilantro, ajo", 5.0, "Fácil", 2.0, true, 9.0, 3.0, "Picante / Base", "Serrano", "Verde intenso, herbáceo, limpio", "México", "Más intenso que jalapeño, limpio, fresco, ligeramente ácido", 5.0, 5.0, "Bajo", "10,000–23,000" },
                    { 3, 1.0, "Picante universal, fondo seco, sin complejidad dominante", "Rojo brillante", "Casi todo; ajo, vinagre, tomate", 4.0, "Fácil", 2.0, true, 5.0, 2.0, "Picante", "Cayena / Cayenne", "Terroso, seco, levemente frutal", "América del Sur", "Picante directo y limpio, algo terroso, moderado aroma", 6.0, 6.0, "Medio-bajo", "30,000–50,000" },
                    { 4, 1.0, "Carácter tropical poderoso; el rey del sabor habanero", "Naranja/Rojo", "Mango, piña, cítrico, zanahoria, ajo", 9.0, "Fácil", 6.0, true, 4.0, 9.0, "Personalidad / Picante", "Habanero", "Floral intenso, mango, cítrico, tropical", "Caribe/México", "Explosivo, tropical, floral, cítrico, fruta de la pasión", 9.0, 8.0, "Alto", "100,000–350,000" },
                    { 5, 1.0, "Sabor caribeño profundo, dulzor y fuego a la vez", "Naranja/Amarillo", "Mango, coco, jengibre, ajo, cebolla", 9.0, "Media", 7.0, true, 4.0, 9.0, "Personalidad", "Scotch Bonnet", "Fruta tropical, floral dulce, algo terroso", "Caribe", "Similar habanero pero más floral y frutal, dulzón, complejo", 8.0, 8.0, "Alto", "100,000–350,000" },
                    { 6, 1.0, "Sabor sudamericano único; profundidad frutal compleja", "Amarillo-naranja", "Papa, ajo, cebolla, lima, mariscos", 9.0, "Media", 6.0, true, 6.0, 7.0, "Personalidad / Aroma", "Ají Amarillo", "Fruta seca, floral suave, miel salvaje", "Perú", "Frutal único, floral, levemente terroso, sabor andino inconfundible", 6.0, 5.0, "Medio", "30,000–50,000" },
                    { 7, 2.0, "Cuerpo grueso, sabor profundo y complejidad", "Rojo/Naranja intenso", "Queso, ajo, cebolla, orégano, papa", 8.0, "Media", 5.0, true, 4.0, 6.0, "Base / Personalidad", "Rocoto", "Frutal maduro, especiado, levemente ahumado", "Perú/Bolivia", "Intenso, carnoso, frutal maduro, recuerda al morrón pero picante", 8.0, 7.0, "Medio", "50,000–250,000" },
                    { 8, 1.0, "Calor intenso y limpio, rápido", "Rojo/Verde", "Jengibre, limoncillo, ajo, soja, coco", 5.0, "Fácil", 2.0, true, 7.0, 3.0, "Picante", "Thai Chili / Bird's Eye", "Herbáceo, levemente floral, fresco", "Tailandia/Asia", "Picante rápido y punzante, algo herbáceo, limpio", 7.0, 7.0, "Medio", "50,000–100,000" },
                    { 9, 5.0, "Profundidad seca y terrosa; picante sostenido", "Rojo oscuro seco", "Ajo, tomate, cebolla, vinagre", 6.0, "Fácil", 2.0, true, 3.0, 2.0, "Picante / Fondo", "Chile de Árbol", "Terroso, tostado, algo ahumado", "México", "Seco, terroso, toque de nuez tostada, calor sostenido", 7.0, 7.0, "Medio", "15,000–65,000" },
                    { 10, 4.0, "Complejidad y color; sabor tipo mole", "Rojo oscuro", "Ancho, chipotle, ajo, comino, cacao", 8.0, "Fácil", 5.0, true, 2.0, 5.0, "Personalidad / Fondo", "Guajillo", "Frutal seco, arándano, toffee, tierra", "México", "Suave, frutal seco, arándano, té negro, sin picante dominante", 3.0, 3.0, "Bajo", "2,500–5,000" },
                    { 11, 3.0, "Profundidad, dulzor y cuerpo; base perfecta para salsas complejas", "Rojo-café oscuro", "Mulato, guajillo, chipotle, ajo, comino", 9.0, "Fácil", 7.0, true, 2.0, 6.0, "Base / Fondo", "Ancho (Poblano seco)", "Chocolate, pasas, fruta seca, tierra", "México", "Muy suave, dulce, uva pasa, chocolate, terroso profundo", 2.0, 2.0, "Bajo", "1,000–2,000" },
                    { 12, 10.0, "Ahumado potente y profundidad; sabor BBQ premium", "Rojo-café ahumado", "Ancho, ajo, cebolla, miel, tomate", 8.0, "Fácil", 5.0, true, 2.0, 3.0, "Aroma / Personalidad", "Chipotle (Jalapeño ahumado)", "Humo, madera, caramelo, cuero", "México", "Ahumado BBQ, dulce, terroso, carnoso, maple", 5.0, 4.0, "Medio-alto", "5,000–10,000" },
                    { 13, 1.0, "Picante extremo con algo de personalidad frutal", "Rojo/Naranja", "Mango, zanahoria, habanero, jengibre", 7.0, "Media", 3.0, true, 4.0, 5.0, "Picante extremo", "Ghost Pepper / Bhut Jolokia", "Floral lejano, tierra, algo frutal", "India", "Intenso, frutal, floral tardío pero BRUTAL calor", 10.0, 9.0, "Muy alto", "800,000–1,041,427" },
                    { 14, 1.0, "Picante máximo; muy poco más que eso", "Rojo brillante", "Con mucho habanero/mango para disimular", 5.0, "Difícil", 3.0, true, 2.0, 4.0, "Picante extremo", "Carolina Reaper", "Fruta apenas, luego solo fuego y dolor", "EE.UU.", "Picante nuclear, ligero dulzor frutal antes del apocalipsis", 10.0, 10.0, "Extremo", "1,400,000–2,200,000" },
                    { 15, 1.0, "Picante máximo con algo más de complejidad que el Reaper", "Rojo oscuro", "Habanero, frutas tropicales, zanahoria", 6.0, "Difícil", 3.0, true, 2.0, 4.0, "Picante extremo", "Trinidad Moruga Scorpion", "Floral brevísimo, luego fuego puro", "Trinidad", "Picante extremo, algo floral antes del desastre", 10.0, 10.0, "Extremo", "1,200,000–2,009,231" },
                    { 16, 1.0, "Frescura y calor suave; buen cuerpo jugoso", "Amarillo-naranja claro", "Ajo, cebolla, cilantro, limón", 5.0, "Fácil (Chile)", 4.0, true, 8.0, 5.0, "Base / Frescura", "Ají Cristal", "Fresco, agua de lluvia, leve fruta", "Chile", "Fresco, jugoso, levemente frutal, vegetal agradable", 3.0, 3.0, "Bajo", "5,000–30,000" },
                    { 17, 1.0, "Cuerpo y base sin dominar; buen volumen", "Rojo", "Todo tipo de ingredientes", 4.0, "Fácil (Chile)", 4.0, true, 6.0, 4.0, "Base", "Cacho de Cabra", "Vegetal suave, tierra liviana", "Chile", "Suave, carnoso, algo dulce, muy versátil", 3.0, 3.0, "Bajo", "5,000–15,000" },
                    { 18, 1.0, "Carácter chileno intenso y personalidad", "Rojo-naranja", "Ají cristal, ajo, cebolla, pimentón", 6.0, "Media (Chile)", 3.0, true, 5.0, 5.0, "Picante / Personalidad", "Putaparió", "Frutal breve, luego calor intenso", "Chile", "Intenso, directo, algo frutal y muy picante", 7.0, 7.0, "Medio-alto", "50,000–200,000" },
                    { 19, 1.0, "Cuerpo, dulzor y volumen; equilibra mezclas intensas", "Rojo/Amarillo/Verde", "Todo; excelente para bajar picante", 4.0, "Fácil", 8.0, true, 7.0, 5.0, "Base / Cuerpo", "Morrón / Bell Pepper", "Fruta dulce, vegetal, algo floral", "Mundial", "Dulce, carnoso, vegetal fresco, sin picante", 1.0, 0.0, "Ninguno", "0" },
                    { 20, 3.0, "Dulzor, color y cuerpo; similar al morrón", "Rojo/Amarillo", "Ajo, tomate, cebolla, hierbas", 5.0, "Fácil", 7.0, true, 5.0, 4.0, "Base", "Pimiento Español", "Dulce, ahumado suave, vegetal", "España", "Dulce suave, carnoso, algo ahumado en variedad pimentón", 2.0, 1.0, "Bajo", "500–1,000" },
                    { 21, 3.0, "Profundidad tipo mole; complejidad extrema", "Negro-café", "Mulato, ancho, achiote, ajo, comino", 10.0, "Media", 6.0, true, 2.0, 4.0, "Fondo / Complejidad", "Chihuacle Negro", "Cacao, mole, tierra húmeda, tabaco", "México", "Chocolate oscuro, terroso profundo, ciruela pasa", 3.0, 3.0, "Bajo", "1,000–4,000" },
                    { 22, 3.0, "Profundidad mole; complejidad sin picante", "Café-negro", "Chihuacle, ancho, chipotle, comino", 9.0, "Media", 5.0, true, 2.0, 4.0, "Fondo / Complejidad", "Mulato", "Chocolate amargo, tabaco, tierra", "México", "Similar ancho pero más chocolate y menos dulce, tabaco", 3.0, 3.0, "Bajo", "2,500–3,000" },
                    { 23, 2.0, "Complejidad seca; profundidad sin picar", "Café oscuro", "Guajillo, ancho, ajo, cebolla", 7.0, "Media", 5.0, true, 3.0, 4.0, "Fondo", "Pasilla", "Tierra, fruta seca, hierba seca", "México", "Terroso, uvas pasas, ciruela seca, especiado suave", 2.0, 2.0, "Bajo", "1,000–3,000" },
                    { 24, 1.0, "Picante fresco con más dulzor que jalapeño", "Rojo brillante", "Ajo, cebolla, cilantro, tomate", 5.0, "Fácil", 4.0, true, 7.0, 5.0, "Picante / Base", "Fresno", "Fruta madura, fresco, algo cítrico", "México/EE.UU.", "Similar jalapeño maduro, más frutal y dulce", 4.0, 5.0, "Bajo", "2,500–10,000" },
                    { 25, 1.0, "Dulzor, acidez natural y cuerpo", "Amarillo", "Casi todo; excelente base neutra", 4.0, "Fácil", 6.0, true, 7.0, 5.0, "Cuerpo / Dulzor", "Banana Pepper", "Frutal suave, ácido leve, banana", "EE.UU./Italia", "Dulce, ácido leve, afrutado, casi sin picante", 1.0, 1.0, "Ninguno", "0–500" },
                    { 26, 1.0, "Cuerpo y volumen sin alterar perfil", "Verde-amarillo", "Todo", 3.0, "Fácil", 6.0, true, 8.0, 4.0, "Base", "Cubanelle", "Frutal suave, vegetal fresco", "Europa/Caribe", "Dulce, carnoso, fresco, muy neutro", 1.0, 1.0, "Ninguno", "0–1,000" },
                    { 27, 6.0, "Color rojo y profundidad tipo pimentón de la vera", "Rojo oscuro seco", "Ajo, tomate, romero, pimentón", 7.0, "Media", 6.0, true, 3.0, 4.0, "Aroma / Fondo", "Ñora", "Pimentón ahumado, tierra dulce", "España", "Dulce ahumado, pimentón, profundidad mediterránea", 2.0, 2.0, "Bajo", "500–2,500" },
                    { 28, 2.0, "Complejidad mediterránea/oriental única", "Rojo óxido", "Ajo, limón, cordero, yogur, hierbas", 8.0, "Difícil", 5.0, true, 4.0, 5.0, "Personalidad / Aroma", "Aleppo", "Fruta seca, cuero, aceite, sal", "Siria/Turquía", "Frutal, aceite de oliva, cuero, sal, picante tardío", 4.0, 3.0, "Medio", "10,000" },
                    { 29, 7.0, "Umami y complejidad extrema; muy particular", "Café-negro-púrpura", "Ajo, cebolla caramelizada, berenjena, carne", 9.0, "Difícil", 7.0, true, 2.0, 5.0, "Aroma / Umami", "Urfa Biber", "Cacao, humo, tierra, aceite", "Turquía", "Ahumado, chocolate negro, pasas, aceite, umami profundo", 3.0, 3.0, "Bajo", "7,000–8,000" },
                    { 30, 1.0, "Color rojo profundo con poco picante", "Rojo brillante intenso", "Yogur, especias indias, jengibre, ajo", 4.0, "Difícil", 4.0, true, 4.0, 3.0, "Color / Aroma", "Kashmiri", "Suave, frutal leve, tierra", "India", "Suave, colorante intenso, algo frutal seco", 2.0, 3.0, "Bajo", "1,000–2,000" },
                    { 31, 1.0, "Carácter africano/portugués; picante cítrico", "Rojo", "Limón, ajo, cebolla, hierbas, aceite oliva", 6.0, "Media", 3.0, true, 7.0, 4.0, "Picante / Personalidad", "Piri Piri / African Bird", "Cítrico, herbáceo, levemente frutal", "África/Portugal", "Picante ácido, cítrico, limpio y directo", 7.0, 7.0, "Medio", "50,000–175,000" },
                    { 32, 2.0, "Sabor seco y profundo tipo asiático", "Rojo oscuro seco", "Comino, cilantro, ajo, jengibre", 6.0, "Difícil", 4.0, true, 4.0, 5.0, "Fondo / Picante", "Dundicut", "Frutal seco, tierra, algo dulce", "Pakistán", "Frutal, terroso, calor sostenido", 6.0, 7.0, "Medio", "55,000–65,000" },
                    { 33, 5.0, "Similar chile de árbol pero más oscuro y profundo", "Muy oscuro", "Ajo, tomate, cebolla, chipotle", 6.0, "Media", 2.0, true, 3.0, 2.0, "Fondo / Picante", "Árbol Negro", "Nuez, tostado, tierra oscura", "México", "Terroso oscuro, nuez tostada, algo ahumado", 6.0, 6.0, "Medio", "15,000–30,000" },
                    { 34, 1.0, "Acidez y frescura; carácter mediterráneo", "Rojo/Verde", "Aceitunas, ajo, vinagre, hierbas", 4.0, "Fácil", 4.0, true, 7.0, 3.0, "Acidez / Frescura", "Pepperoncini", "Ácido, briny, fresco, leve cítrico", "Italia/Grecia", "Ácido, levemente picante, fresco, en vinagre", 1.0, 1.0, "Bajo", "100–500" },
                    { 35, 1.0, "Jalapeño más suave; buen cuerpo", "Verde/Rojo", "Ajo, cebolla, tomate, cilantro", 4.0, "Fácil", 4.0, true, 7.0, 4.0, "Base", "Cuaresmeño", "Vegetal dulce, fresco, algo frutal", "México", "Similar jalapeño pero más suave, carnoso y dulzón", 3.0, 4.0, "Bajo", "5,000–15,000" },
                    { 36, 1.0, "Sabor tropical andino particular", "Amarillo-naranja", "Mango, piña, habanero, jengibre", 7.0, "Difícil", 6.0, true, 6.0, 8.0, "Personalidad / Aroma", "Amarillo Mango", "Mango, limón, floral tropical", "Perú", "Mango, cítrico, floral suave, tropical andino", 5.0, 5.0, "Medio", "25,000–40,000" }
                });

            migrationBuilder.InsertData(
                table: "Builds",
                columns: new[] { "Id", "ComposicionJson", "DiasFerrmentacion", "Emoji", "EsPeligrosa", "Ingredientes", "Nombre", "NotasSabor", "Picante", "ResultadoEsperado", "Slug" },
                values: new object[,]
                {
                    { 1, "[{\"nombre\":\"Habanero\",\"porcentaje\":40},{\"nombre\":\"Zanahoria\",\"porcentaje\":15},{\"nombre\":\"Cebolla morada\",\"porcentaje\":10}]", 5, "🌴", false, "Habanero 40% + Mango 20% + Piña 10% + Zanahoria 15% + Ajo 5% + Cebolla morada 10%", "Tropical Gourmet", "Tropical explosivo, frutal, dulce-picante, floral, naranja intenso", 7.0, "Naranja brillante, textura media, dulzor tropical equilibrado con calor habanero.", "tropical-gourmet" },
                    { 2, "[{\"nombre\":\"Jalapeño\",\"porcentaje\":40},{\"nombre\":\"Serrano\",\"porcentaje\":30},{\"nombre\":\"Tomate\",\"porcentaje\":15}]", 4, "🇲🇽", false, "Jalapeño 40% + Serrano 30% + Tomate verde 15% + Ajo 10% + Cilantro 5%", "Mexicana Verde", "Verde fresco, herbáceo, cítrico, limpio, vegetal", 5.0, "Verde brillante, textura semilíquida, frescura total.", "mexicana-verde" },
                    { 3, "[{\"nombre\":\"Cayena / Cayenne\",\"porcentaje\":30},{\"nombre\":\"Jalapeño\",\"porcentaje\":30},{\"nombre\":\"Zanahoria\",\"porcentaje\":20}]", 6, "🔴", false, "Cayena 30% + Jalapeño rojo 30% + Zanahoria 20% + Tomate 10% + Ajo 10%", "Roja Balanceada", "Rojo clásico, equilibrado, picante moderado, versátil", 5.0, "Rojo brillante, textura media, all-purpose.", "roja-balanceada" },
                    { 4, "[{\"nombre\":\"Habanero\",\"porcentaje\":35}]", 3, "🥭", false, "Habanero 35% + Mango 35% + Cebolla morada 15% + Lima 10% + Sal 5%", "Mango Habanero", "Frutal-tropical intenso, dulce y feroz al mismo tiempo", 8.0, "Naranja tropical, textura líquida-media, dulzor + calor extremo.", "mango-habanero" },
                    { 5, "[{\"nombre\":\"Chipotle (Jalapeño ahumado)\",\"porcentaje\":50},{\"nombre\":\"Ancho (Poblano seco)\",\"porcentaje\":20},{\"nombre\":\"Chile de Árbol\",\"porcentaje\":15}]", 7, "🔥", false, "Chipotle 50% + Ancho 20% + Chile de Árbol 15% + Ajo 10% + Miel 5%", "Ahumada BBQ", "Ahumado profundo, BBQ, dulzor caramelizado, terroso", 5.0, "Café-rojo oscuro, espesa, ahumado dominante.", "ahumada-bbq" },
                    { 6, "[{\"nombre\":\"Cayena / Cayenne\",\"porcentaje\":50},{\"nombre\":\"Jalapeño\",\"porcentaje\":20}]", 7, "🎷", false, "Cayena 50% + Jalapeño 20% + Vinagre blanco 20% + Sal 10%", "Estilo Louisiana", "Ácido, picante, limpio, directo — estilo Tabasco/Frank's", 6.0, "Rojo brillante, muy líquida, ácida y picante.", "louisiana" },
                    { 7, "[{\"nombre\":\"Serrano\",\"porcentaje\":40},{\"nombre\":\"Jalapeño\",\"porcentaje\":25}]", 3, "🟢", false, "Serrano 40% + Jalapeño 25% + Lima (jugo) 20% + Cebolla 10% + Ajo 5%", "Verde Cítrica", "Cítrico, fresco, verde, limpio con buena acidez", 5.0, "Verde-amarillo, líquida, refrescante.", "verde-citrica" },
                    { 8, "[{\"nombre\":\"Cayena / Cayenne\",\"porcentaje\":30},{\"nombre\":\"Jalapeño\",\"porcentaje\":20}]", 8, "🧄", false, "Cayena 30% + Jalapeño 20% + Ajo 30% + Vinagre manzana 15% + Cebolla 5%", "Garlic Bomb", "Ajo dominante, picante medio, acidez suave, aromática intensa", 5.0, "Rojo-dorado, media, sabor a ajo fermentado extremadamente aromático.", "garlic-bomb" },
                    { 9, "[{\"nombre\":\"Chipotle (Jalapeño ahumado)\",\"porcentaje\":25},{\"nombre\":\"Ancho (Poblano seco)\",\"porcentaje\":20},{\"nombre\":\"Chile de Árbol\",\"porcentaje\":15}]", 10, "🍄", false, "Chipotle 25% + Ancho 20% + Chile de Árbol 15% + Tomate 20% + Ajo 15% + Cebolla 5%", "Umami Profunda", "Umami profundo, terroso, ahumado, complejo como un mole", 4.0, "Café oscuro muy espesa, umami extremo.", "umami-profunda" },
                    { 10, "[{\"nombre\":\"Carolina Reaper\",\"porcentaje\":30},{\"nombre\":\"Ghost Pepper / Bhut Jolokia\",\"porcentaje\":30},{\"nombre\":\"Trinidad Moruga Scorpion\",\"porcentaje\":20},{\"nombre\":\"Habanero\",\"porcentaje\":20}]", 5, "☢️", true, "Carolina Reaper 30% + Ghost Pepper 30% + Trinidad Scorpion 20% + Habanero 20%", "Nuclear", "Solo picante. SOLO PICANTE.", 10.0, "Rojo intenso, líquida, picante más allá del dolor.", "nuclear" },
                    { 11, "[{\"nombre\":\"Carolina Reaper\",\"porcentaje\":40},{\"nombre\":\"Trinidad Moruga Scorpion\",\"porcentaje\":40},{\"nombre\":\"Chile de Árbol\",\"porcentaje\":20}]", 3, "😭", true, "Carolina Reaper 40% + Trinidad Scorpion 40% + Chile de árbol 20%", "Criminal de Guerra", "Destrucción total de papilas. No hay sabor, solo fuego eterno.", 10.0, "⚠️ PELIGRO BIOLÓGICO. Rojo sangre. Esta salsa es un arma.", "criminal-de-guerra" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ajies");

            migrationBuilder.DropTable(
                name: "Builds");
        }
    }
}
