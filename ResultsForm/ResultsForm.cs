using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace ResultsForm
{
    public partial class ResultsForm : Form
    {
        private DataTable query1Results;
        private DataTable query2Results;

        /// <summary>
        /// Initializes a new instance of the ResultsForm class.
        /// </summary>
        /// <param name="query1Results">The results of the first query.</param>
        /// <param name="query2Results">The results of the second query.</param>
        public ResultsForm(DataTable query1Results, DataTable query2Results)
        {
            InitializeComponent();

            this.query1Results = query1Results;
            this.query2Results = query2Results;

            // Configura el DataGridView para la primera consulta
            DisplayQuery1Results(query1Results);

            // Configura el DataGridView para la segunda consulta
            DisplayQuery2Results(query2Results);

        }

        /// <summary>
        /// Displays the results of Query 1 in a DataGridView within a Panel.
        /// 
        /// This method takes a DataTable as input, which contains the results of Query 1.
        /// It then processes the data to create a new DataTable with the desired columns
        /// and rows, and finally displays the results in a DataGridView within a Panel.
        /// 
        /// <param name="query1Results">The DataTable containing the results of Query 1.</param>

        private void DisplayQuery1Results(DataTable query1Results)
        {
            // Limpiar cualquier DataGridView existente en el Panel
            PanelResults1.Controls.Clear();

            // Crear un nuevo DataTable para almacenar los resultados con las columnas especificadas
            var resultsTable = new DataTable();
            resultsTable.Columns.Add("Nombre Tienda", typeof(string));
            resultsTable.Columns.Add("CantidadAño2023", typeof(int));
            resultsTable.Columns.Add("CantidadAño2024", typeof(int));

            // Obtener los nombres únicos de las tiendas
            var storeNames = query1Results.AsEnumerable()
                .Select(row => row.Field<string>("Sucursal"))
                .Distinct()
                .ToList();

            // Iterar sobre cada tienda
            foreach (var storeName in storeNames)
            {
                // Filtrar los resultados para la tienda actual
                var filteredResults = query1Results.AsEnumerable()
                    .Where(row => row.Field<string>("Sucursal") == storeName)
                    .ToList();

                // Inicializar contadores para los años
                int count2023 = 0;
                int count2024 = 0;

                // Contar los registros para cada año
                foreach (var row in filteredResults)
                {
                    int year = Convert.ToInt32(row["Year"]); // Usa Convert.ToInt32 para evitar InvalidCastException
                    int totalRegistros = Convert.ToInt32(row["Total_Registros"]); // Usa Convert.ToInt32 para evitar InvalidCastException

                    if (year == 2023)
                    {
                        count2023 += totalRegistros;
                    }
                    else if (year == 2024)
                    {
                        count2024 += totalRegistros;
                    }
                }

                // Agregar una fila al DataTable para la tienda actual
                resultsTable.Rows.Add(storeName, count2023, count2024);
            }

            // Crear un nuevo DataGridView para mostrar los resultados
            var dataGridView = new DataGridView
            {
                DataSource = resultsTable,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                Dock = DockStyle.Top,
                Height = 200, // Ajusta la altura según tus necesidades
                Margin = new Padding(0, 10, 0, 10), // Margen entre DataGridView
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                Font = new Font("Arial", 10) // Usa una fuente que soporte caracteres especiales
            };

            // Agregar el DataGridView al Panel
            PanelResults1.Controls.Add(dataGridView);

            // Agregar un divisor (Panel) entre los DataGridView
            var separator = new Panel
            {
                BackColor = Color.Gray, // Color del divisor
                Height = 2, // Altura del divisor
                Dock = DockStyle.Top,
                Margin = new Padding(0, 0, 0, 10) // Margen inferior del divisor
            };

            PanelResults1.Controls.Add(separator);

            // Actualizar el tamaño del Panel si es necesario
            PanelResults1.AutoScroll = true;
        }

        /// <summary>
        /// Displays the results of Query 2 in a series of DataGridViews, one for each unique store.
        /// </summary>
        /// <param name="query2Results">A DataTable containing the results of Query 2.</param>

        private void DisplayQuery2Results(DataTable query2Results)
        {
            // Limpiar cualquier DataGridView existente en el Panel
            PanelResults.Controls.Clear();

            // Obtener los nombres únicos de las tiendas
            var storeNames = query2Results.AsEnumerable()
                .Select(row => row.Field<string>("Sucursal"))
                .Distinct()
                .ToList();

            int yOffset = 10; // Offset vertical para posicionar los DataGridView

            foreach (var storeName in storeNames)
            {
                // Crear un nuevo DataGridView para cada tienda
                var dataGridView = new DataGridView
                {
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                    Dock = DockStyle.Top,
                    Height = 200, // Ajusta la altura según tus necesidades
                    Margin = new Padding(0, 0, 0, 0), // Margen entre DataGridView
                    AllowUserToAddRows = false,
                    AllowUserToDeleteRows = false,
                    Font = new Font("Arial", 10),
                };

                // Filtrar los resultados para la tienda actual
                var filteredResults = query2Results.AsEnumerable()
                    .Where(row => row.Field<string>("Sucursal") == storeName)
                    .CopyToDataTable();

                // Asignar los resultados filtrados al DataGridView
                dataGridView.DataSource = filteredResults;

                // Agregar el DataGridView al Panel
                PanelResults.Controls.Add(dataGridView);

                // Agregar un divisor (Panel) entre los DataGridView
                var separator = new Panel
                {
                    BackColor = Color.Gray, // Color del divisor
                    Height = 2, // Altura del divisor
                    Dock = DockStyle.Top,
                    Margin = new Padding(0, 0, 0, 10) // Margen inferior del divisor
                };

                PanelResults.Controls.Add(separator);

                // Actualizar el offset para el siguiente DataGridView
                yOffset += dataGridView.Height + separator.Height + 10; // Agregar margen adicional si es necesario
            }

            // Actualizar el tamaño del Panel si es necesario
            PanelResults.AutoScroll = true;
        }

        /// <summary>
        /// Generates an Excel report based on the provided query results.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        private void buttonGenerateExcel_Click(object sender, EventArgs e)
        {
            // Create a new Excel workbook
            using (var workbook = new XLWorkbook())
            {
                // Add a worksheet for RegistrosXAño
                var worksheetRegistrosXAño = workbook.Worksheets.Add("RegistrosXAño");

                // Set the header row
                worksheetRegistrosXAño.Cell(1, 1).Value = "Sucursal";
                worksheetRegistrosXAño.Cell(1, 2).Value = "Datos2023";
                worksheetRegistrosXAño.Cell(1, 3).Value = "Datos2024";

                // Create a dictionary to store the results
                var results = new Dictionary<int, int[]>();

                // Iterate over the query1Results DataTable
                for (int i = 0; i < query1Results.Rows.Count; i++)
                {
                    int sucursal = Convert.ToInt32(query1Results.Rows[i]["Sucursal"]);
                    int year = Convert.ToInt32(query1Results.Rows[i]["Year"]);
                    int totalRegistros = Convert.ToInt32(query1Results.Rows[i]["Total_Registros"]);

                    if (!results.ContainsKey(sucursal))
                    {
                        results[sucursal] = new int[2] { 0, 0 };
                    }

                    if (year == 2023)
                    {
                        results[sucursal][0] = totalRegistros;
                    }
                    else if (year == 2024)
                    {
                        results[sucursal][1] = totalRegistros;
                    }
                }

                // Add the data to the worksheet
                int rowIndex = 2;
                foreach (var result in results)
                {
                    worksheetRegistrosXAño.Cell(rowIndex, 1).Value = result.Key;
                    worksheetRegistrosXAño.Cell(rowIndex, 2).Value = result.Value[0];
                    worksheetRegistrosXAño.Cell(rowIndex, 3).Value = result.Value[1];
                    rowIndex++;
                }

                // Add a worksheet for RegistrosxSucursal
                var worksheetRegistrosxSucursal = workbook.Worksheets.Add("RegistrosxSucursal");

                // Create a dictionary to store the results
                var sucursalResults = new Dictionary<int, List<(int, int, int)>>();

                // Iterate over the query2Results DataTable
                for (int i = 0; i < query2Results.Rows.Count; i++)
                {
                    int sucursal = Convert.ToInt32(query2Results.Rows[i]["Sucursal"]);
                    int year = Convert.ToInt32(query2Results.Rows[i]["Year"]);
                    int mes = Convert.ToInt32(query2Results.Rows[i]["Mes"]);
                    int totalRegistros = Convert.ToInt32(query2Results.Rows[i]["Total_Registros"]);

                    if (!sucursalResults.ContainsKey(sucursal))
                    {
                        sucursalResults[sucursal] = new List<(int, int, int)>();
                    }

                    sucursalResults[sucursal].Add((year, mes, totalRegistros));
                }

                // Add the data to the worksheet
                int sucursalRowIndex = 1;
                foreach (var sucursalResult in sucursalResults)
                {
                    int sucursal = sucursalResult.Key;
                    var yearResults = sucursalResult.Value;

                    // Add the sucursal header
                    worksheetRegistrosxSucursal.Cell(sucursalRowIndex, 1).Value = $"Sucursal {sucursal}";
                    worksheetRegistrosxSucursal.Cell(sucursalRowIndex, 1).Style.Font.Bold = true;
                    sucursalRowIndex++;

                    // Add the year headers
                    worksheetRegistrosxSucursal.Cell(sucursalRowIndex, 1).Value = "Año";
                    worksheetRegistrosxSucursal.Cell(sucursalRowIndex, 2).Value = "Mes";
                    worksheetRegistrosxSucursal.Cell(sucursalRowIndex, 3).Value = "Total_Registros";
                    worksheetRegistrosxSucursal.Cell(sucursalRowIndex, 1).Style.Font.Bold = true;
                    worksheetRegistrosxSucursal.Cell(sucursalRowIndex, 2).Style.Font.Bold = true;
                    worksheetRegistrosxSucursal.Cell(sucursalRowIndex, 3).Style.Font.Bold = true;
                    sucursalRowIndex++;

                    // Add the year data
                    foreach (var yearResult in yearResults.OrderBy(y => y.Item1))
                    {
                        int year = yearResult.Item1;
                        int mes = yearResult.Item2;
                        int totalRegistro = yearResult.Item3;

                        worksheetRegistrosxSucursal.Cell(sucursalRowIndex, 1).Value = year;
                        worksheetRegistrosxSucursal.Cell(sucursalRowIndex, 2).Value = mes;
                        worksheetRegistrosxSucursal.Cell(sucursalRowIndex, 3).Value = totalRegistro;
                        sucursalRowIndex++;
                    }

                    // Add a blank row for separation
                    sucursalRowIndex++;
                }

                // Save the workbook to a file
                workbook.SaveAs("C:\\Reports\\Results_" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx");
            }
        }
    }
}
