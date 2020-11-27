namespace apCaminhosMarte
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpRotas = new System.Windows.Forms.TabPage();
            this.lblMetodos = new System.Windows.Forms.Label();
            this.lsbMetodos = new System.Windows.Forms.ListBox();
            this.lblPeso = new System.Windows.Forms.Label();
            this.lsbPeso = new System.Windows.Forms.ListBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvMelhorCaminho = new System.Windows.Forms.DataGridView();
            this.Movimento1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCaminhos = new System.Windows.Forms.DataGridView();
            this.Movimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Movimento2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Movimento3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Movimento4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Movimento5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Movimento6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lsbDestino = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lsbOrigem = new System.Windows.Forms.ListBox();
            this.pbMapa = new System.Windows.Forms.PictureBox();
            this.tpArvore = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tpRotas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMelhorCaminho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaminhos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMapa)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpRotas);
            this.tabControl1.Controls.Add(this.tpArvore);
            this.tabControl1.Location = new System.Drawing.Point(2, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1326, 551);
            this.tabControl1.TabIndex = 0;
            // 
            // tpRotas
            // 
            this.tpRotas.Controls.Add(this.lblMetodos);
            this.tpRotas.Controls.Add(this.lsbMetodos);
            this.tpRotas.Controls.Add(this.lblPeso);
            this.tpRotas.Controls.Add(this.lsbPeso);
            this.tpRotas.Controls.Add(this.btnBuscar);
            this.tpRotas.Controls.Add(this.dgvMelhorCaminho);
            this.tpRotas.Controls.Add(this.dgvCaminhos);
            this.tpRotas.Controls.Add(this.label4);
            this.tpRotas.Controls.Add(this.label3);
            this.tpRotas.Controls.Add(this.label2);
            this.tpRotas.Controls.Add(this.lsbDestino);
            this.tpRotas.Controls.Add(this.label1);
            this.tpRotas.Controls.Add(this.lsbOrigem);
            this.tpRotas.Controls.Add(this.pbMapa);
            this.tpRotas.Location = new System.Drawing.Point(4, 22);
            this.tpRotas.Name = "tpRotas";
            this.tpRotas.Padding = new System.Windows.Forms.Padding(3);
            this.tpRotas.Size = new System.Drawing.Size(1318, 525);
            this.tpRotas.TabIndex = 0;
            this.tpRotas.Text = "Rotas entre cidades";
            this.tpRotas.UseVisualStyleBackColor = true;
            // 
            // lblMetodos
            // 
            this.lblMetodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMetodos.AutoSize = true;
            this.lblMetodos.Location = new System.Drawing.Point(1185, 101);
            this.lblMetodos.Name = "lblMetodos";
            this.lblMetodos.Size = new System.Drawing.Size(43, 13);
            this.lblMetodos.TabIndex = 15;
            this.lblMetodos.Text = "Método";
            // 
            // lsbMetodos
            // 
            this.lsbMetodos.FormattingEnabled = true;
            this.lsbMetodos.Items.AddRange(new object[] {
            "01 - Recursão",
            "02 - DiJkstra (menor)",
            "03 - Pilhas"});
            this.lsbMetodos.Location = new System.Drawing.Point(1180, 117);
            this.lsbMetodos.Name = "lsbMetodos";
            this.lsbMetodos.Size = new System.Drawing.Size(111, 43);
            this.lsbMetodos.TabIndex = 14;
            // 
            // lblPeso
            // 
            this.lblPeso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPeso.AutoSize = true;
            this.lblPeso.Location = new System.Drawing.Point(1062, 101);
            this.lblPeso.Name = "lblPeso";
            this.lblPeso.Size = new System.Drawing.Size(39, 13);
            this.lblPeso.TabIndex = 13;
            this.lblPeso.Text = "Critério";
            // 
            // lsbPeso
            // 
            this.lsbPeso.FormattingEnabled = true;
            this.lsbPeso.Items.AddRange(new object[] {
            "01 - Distância",
            "02 - Tempo",
            "03 - Preço"});
            this.lsbPeso.Location = new System.Drawing.Point(1060, 117);
            this.lsbPeso.Name = "lsbPeso";
            this.lsbPeso.Size = new System.Drawing.Size(111, 43);
            this.lsbPeso.TabIndex = 12;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Location = new System.Drawing.Point(1139, 180);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(89, 23);
            this.btnBuscar.TabIndex = 11;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // dgvMelhorCaminho
            // 
            this.dgvMelhorCaminho.AllowUserToAddRows = false;
            this.dgvMelhorCaminho.AllowUserToDeleteRows = false;
            this.dgvMelhorCaminho.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMelhorCaminho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMelhorCaminho.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Movimento1,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.dgvMelhorCaminho.Location = new System.Drawing.Point(1037, 448);
            this.dgvMelhorCaminho.Name = "dgvMelhorCaminho";
            this.dgvMelhorCaminho.ReadOnly = true;
            this.dgvMelhorCaminho.Size = new System.Drawing.Size(277, 71);
            this.dgvMelhorCaminho.TabIndex = 10;
            // 
            // Movimento1
            // 
            this.Movimento1.HeaderText = "Movimento";
            this.Movimento1.Name = "Movimento1";
            this.Movimento1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Movimento";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Movimento";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Movimento";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Movimento";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Movimento";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dgvCaminhos
            // 
            this.dgvCaminhos.AllowUserToAddRows = false;
            this.dgvCaminhos.AllowUserToDeleteRows = false;
            this.dgvCaminhos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCaminhos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCaminhos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Movimento,
            this.Movimento2,
            this.Movimento3,
            this.Movimento4,
            this.Movimento5,
            this.Movimento6});
            this.dgvCaminhos.Location = new System.Drawing.Point(1037, 238);
            this.dgvCaminhos.MultiSelect = false;
            this.dgvCaminhos.Name = "dgvCaminhos";
            this.dgvCaminhos.ReadOnly = true;
            this.dgvCaminhos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCaminhos.Size = new System.Drawing.Size(277, 181);
            this.dgvCaminhos.TabIndex = 9;
            this.dgvCaminhos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCaminhos_CellClick);
            this.dgvCaminhos.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvCaminhos_RowPrePaint);
            // 
            // Movimento
            // 
            this.Movimento.HeaderText = "Movimento";
            this.Movimento.Name = "Movimento";
            this.Movimento.ReadOnly = true;
            // 
            // Movimento2
            // 
            this.Movimento2.HeaderText = "Movimento";
            this.Movimento2.Name = "Movimento2";
            this.Movimento2.ReadOnly = true;
            // 
            // Movimento3
            // 
            this.Movimento3.HeaderText = "Movimento";
            this.Movimento3.Name = "Movimento3";
            this.Movimento3.ReadOnly = true;
            // 
            // Movimento4
            // 
            this.Movimento4.HeaderText = "Movimento";
            this.Movimento4.Name = "Movimento4";
            this.Movimento4.ReadOnly = true;
            // 
            // Movimento5
            // 
            this.Movimento5.HeaderText = "Movimento";
            this.Movimento5.Name = "Movimento5";
            this.Movimento5.ReadOnly = true;
            // 
            // Movimento6
            // 
            this.Movimento6.HeaderText = "Movimento";
            this.Movimento6.Name = "Movimento6";
            this.Movimento6.ReadOnly = true;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1034, 429);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Melhor caminho";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1034, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Caminhos encontrados:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1174, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Destino";
            // 
            // lsbDestino
            // 
            this.lsbDestino.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lsbDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsbDestino.FormattingEnabled = true;
            this.lsbDestino.ItemHeight = 16;
            this.lsbDestino.Items.AddRange(new object[] {
            "  00 - Acheron          ",
            "  01 - Arena           ",
            "  02 - Arrakeen       ",
            "  03 - Bakhuysen       ",
            "  04 - Bradbury ",
            "  05 - Burroughs       ",
            "  06 - Cairo            ",
            "  07 - Dumont",
            "  08 - Echus Overlook",
            "  09 - Esperança",
            "  10 - Gondor",
            "  11 - Lakefront",
            "  12 - Lowell",
            "  13 - Moria",
            "  14 - Nicosia",
            "  15 - Odesa",
            "  16 - Perseverança",
            "  17 - Rowan",
            "  18 - Senzeni Na",
            "  19 - Sheffield",
            "  20 - Temperança",
            "  21 - Tharsis",
            "  22 - Underhill"});
            this.lsbDestino.Location = new System.Drawing.Point(1177, 37);
            this.lsbDestino.Name = "lsbDestino";
            this.lsbDestino.Size = new System.Drawing.Size(114, 52);
            this.lsbDestino.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1057, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Origem";
            // 
            // lsbOrigem
            // 
            this.lsbOrigem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lsbOrigem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsbOrigem.FormattingEnabled = true;
            this.lsbOrigem.ItemHeight = 16;
            this.lsbOrigem.Items.AddRange(new object[] {
            "  00 - Acheron          ",
            "  01 - Arena           ",
            "  02 - Arrakeen       ",
            "  03 - Bakhuysen       ",
            "  04 - Bradbury ",
            "  05 - Burroughs       ",
            "  06 - Cairo            ",
            "  07 - Dumont",
            "  08 - Echus Overlook",
            "  09 - Esperança",
            "  10 - Gondor",
            "  11 - Lakefront",
            "  12 - Lowell",
            "  13 - Moria",
            "  14 - Nicosia",
            "  15 - Odesa",
            "  16 - Perseverança",
            "  17 - Rowan",
            "  18 - Senzeni Na",
            "  19 - Sheffield",
            "  20 - Temperança",
            "  21 - Tharsis",
            "  22 - Underhill"});
            this.lsbOrigem.Location = new System.Drawing.Point(1057, 37);
            this.lsbOrigem.Name = "lsbOrigem";
            this.lsbOrigem.Size = new System.Drawing.Size(114, 52);
            this.lsbOrigem.TabIndex = 1;
            // 
            // pbMapa
            // 
            this.pbMapa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbMapa.Image = ((System.Drawing.Image)(resources.GetObject("pbMapa.Image")));
            this.pbMapa.Location = new System.Drawing.Point(7, 7);
            this.pbMapa.Name = "pbMapa";
            this.pbMapa.Size = new System.Drawing.Size(1024, 512);
            this.pbMapa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMapa.TabIndex = 0;
            this.pbMapa.TabStop = false;
            this.pbMapa.Paint += new System.Windows.Forms.PaintEventHandler(this.pbMapa_Paint);
            // 
            // tpArvore
            // 
            this.tpArvore.Location = new System.Drawing.Point(4, 22);
            this.tpArvore.Name = "tpArvore";
            this.tpArvore.Padding = new System.Windows.Forms.Padding(3);
            this.tpArvore.Size = new System.Drawing.Size(1318, 525);
            this.tpArvore.TabIndex = 1;
            this.tpArvore.Text = "Árvore de Cidades";
            this.tpArvore.UseVisualStyleBackColor = true;
            this.tpArvore.Paint += new System.Windows.Forms.PaintEventHandler(this.tpArvore_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1329, 554);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Projeto 3 - busca de caminhos entre cidades";
            this.tabControl1.ResumeLayout(false);
            this.tpRotas.ResumeLayout(false);
            this.tpRotas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMelhorCaminho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaminhos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMapa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpRotas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lsbDestino;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lsbOrigem;
        private System.Windows.Forms.PictureBox pbMapa;
        private System.Windows.Forms.TabPage tpArvore;
        private System.Windows.Forms.DataGridView dgvCaminhos;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvMelhorCaminho;
        private System.Windows.Forms.DataGridViewTextBoxColumn Movimento1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Movimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Movimento2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Movimento3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Movimento4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Movimento5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Movimento6;
        private System.Windows.Forms.Label lblPeso;
        private System.Windows.Forms.Label lblMetodos;
        private System.Windows.Forms.ListBox lsbMetodos;
        private System.Windows.Forms.ListBox lsbPeso;
    }
}

