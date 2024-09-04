namespace ResultsForm
{
    partial class ResultsForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewQuery1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewQuery2 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PanelResults = new System.Windows.Forms.Panel();
            this.PanelResults1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQuery2)).BeginInit();
            this.PanelResults.SuspendLayout();
            this.PanelResults1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewQuery1
            // 
            this.dataGridViewQuery1.AllowUserToAddRows = false;
            this.dataGridViewQuery1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewQuery1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewQuery1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewQuery1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewQuery1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewQuery1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewQuery1.Enabled = false;
            this.dataGridViewQuery1.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewQuery1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewQuery1.Name = "dataGridViewQuery1";
            this.dataGridViewQuery1.ReadOnly = true;
            this.dataGridViewQuery1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridViewQuery1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewQuery1.Size = new System.Drawing.Size(423, 524);
            this.dataGridViewQuery1.TabIndex = 1;
            // 
            // dataGridViewQuery2
            // 
            this.dataGridViewQuery2.AllowUserToAddRows = false;
            this.dataGridViewQuery2.AllowUserToDeleteRows = false;
            this.dataGridViewQuery2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewQuery2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewQuery2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewQuery2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewQuery2.Enabled = false;
            this.dataGridViewQuery2.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewQuery2.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewQuery2.Name = "dataGridViewQuery2";
            this.dataGridViewQuery2.ReadOnly = true;
            this.dataGridViewQuery2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewQuery2.Size = new System.Drawing.Size(640, 524);
            this.dataGridViewQuery2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(93, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Resultados Globales";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(593, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(218, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "Resultados x Sucursal";
            // 
            // PanelResults
            // 
            this.PanelResults.AutoScroll = true;
            this.PanelResults.Controls.Add(this.dataGridViewQuery2);
            this.PanelResults.Location = new System.Drawing.Point(444, 30);
            this.PanelResults.Name = "PanelResults";
            this.PanelResults.Size = new System.Drawing.Size(640, 524);
            this.PanelResults.TabIndex = 4;
            // 
            // PanelResults1
            // 
            this.PanelResults1.Controls.Add(this.dataGridViewQuery1);
            this.PanelResults1.Location = new System.Drawing.Point(12, 30);
            this.PanelResults1.Name = "PanelResults1";
            this.PanelResults1.Size = new System.Drawing.Size(423, 524);
            this.PanelResults1.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1136, 90);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 32);
            this.button1.TabIndex = 6;
            this.button1.Text = "Generar XML";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonGenerateExcel_Click);
            // 
            // ResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1281, 554);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PanelResults1);
            this.Controls.Add(this.PanelResults);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ResultsForm";
            this.Text = "Resultados de Consultas";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQuery2)).EndInit();
            this.PanelResults.ResumeLayout(false);
            this.PanelResults1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewQuery1;
        private System.Windows.Forms.DataGridView dataGridViewQuery2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel PanelResults;
        private System.Windows.Forms.Panel PanelResults1;
        private System.Windows.Forms.Button button1;
    }
}

