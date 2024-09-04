using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace UtilitiesDB
{
    public class Program
    {
        /// <summary>
        /// Main entry point of the application.
        /// This method reads a configuration file, connects to multiple servers, executes two queries, 
        /// combines the results, and displays them in a form.
        /// </summary>
        /// <param name="args">Command-line arguments (not used)</param>
       [STAThread]
        static void Main(string[] args)
        {
            // Leer archivo de configuración
            var configFile = "Prod.json";
            var configJson = System.IO.File.ReadAllText(configFile);
            var config = System.Text.Json.JsonSerializer.Deserialize<Config>(configJson);

            // Crear una tabla de resultados combinada
            var combinedResultsQuery1 = new DataTable();
            var combinedResultsQuery2 = new DataTable();

            // Conectar a cada servidor y ejecutar queries
            foreach (var serverEntry in config.Servers)
            {
                var parts = serverEntry.Split('|');
                if (parts.Length != 2)
                {
                    Console.WriteLine($"Formato de servidor no válido: {serverEntry}");
                    continue;
                }

                var server = parts[0];
                var storeName = parts[1];
                Console.WriteLine($"Conectando a {server}...");

                try
                {
                    // Establecer conexión
                    var connectionString = $"Server={server};Database={config.Database};User ID={config.User};Password={config.Password};";
                    var resultsQuery1 = new DataTable();
                    var resultsQuery2 = new DataTable();

                    using (var connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();

                        // Ejecutar la primera consulta
                        string query1 = "SELECT YEAR(FECHA_ENVIADO) AS Year, COUNT(*) AS Total_Registros FROM trabajos WHERE YEAR(FECHA_ENVIADO) IN (2023, 2024) GROUP BY YEAR(FECHA_ENVIADO) ORDER BY YEAR(FECHA_ENVIADO) DESC;";
                        using (var command1 = new MySqlCommand(query1, connection))
                        using (var reader1 = command1.ExecuteReader())
                        {
                            resultsQuery1.Load(reader1);
                        }

                        // Ejecutar la segunda consulta
                        string query2 = "SELECT YEAR(FECHA_ENVIADO) AS Year, MONTH(FECHA_ENVIADO) AS Mes, COUNT(*) AS Total_Registros FROM trabajos WHERE YEAR(FECHA_ENVIADO) IN (2023, 2024) GROUP BY YEAR(FECHA_ENVIADO), MONTH(FECHA_ENVIADO) ORDER BY YEAR(FECHA_ENVIADO) DESC, MONTH(FECHA_ENVIADO) DESC;";
                        using (var command2 = new MySqlCommand(query2, connection))
                        using (var reader2 = command2.ExecuteReader())
                        {
                            resultsQuery2.Load(reader2);
                        }
                    }

                    // Agregar la columna del nombre de la tienda
                    resultsQuery1.Columns.Add("Sucursal", typeof(string));
                    resultsQuery2.Columns.Add("Sucursal", typeof(string));

                    foreach (DataRow row in resultsQuery1.Rows)
                    {
                        row["Sucursal"] = storeName;
                    }

                    foreach (DataRow row in resultsQuery2.Rows)
                    {
                        row["Sucursal"] = storeName;
                    }

                    // Mover la columna "Sucursal" a la primera posición
                    resultsQuery1.Columns["Sucursal"].SetOrdinal(0);
                    resultsQuery2.Columns["Sucursal"].SetOrdinal(0);

                    // Combinar resultados
                    combinedResultsQuery1.Merge(resultsQuery1);
                    combinedResultsQuery2.Merge(resultsQuery2);
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"MySqlException: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
            }

            // Mostrar resultados en un formulario
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ResultsForm.ResultsForm(combinedResultsQuery1, combinedResultsQuery2));
        }
    }
}
