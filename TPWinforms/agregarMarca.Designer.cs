
namespace TPWinforms
{
    partial class agregarMarca
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btSalir = new System.Windows.Forms.Button();
            this.btAgregar = new System.Windows.Forms.Button();
            this.tbMarca = new System.Windows.Forms.TextBox();
            this.lbMarca = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btSalir
            // 
            this.btSalir.Location = new System.Drawing.Point(256, 182);
            this.btSalir.Name = "btSalir";
            this.btSalir.Size = new System.Drawing.Size(124, 30);
            this.btSalir.TabIndex = 7;
            this.btSalir.Text = "Salir";
            this.btSalir.UseVisualStyleBackColor = true;
            this.btSalir.Click += new System.EventHandler(this.btSalir_Click);
            // 
            // btAgregar
            // 
            this.btAgregar.Location = new System.Drawing.Point(112, 182);
            this.btAgregar.Name = "btAgregar";
            this.btAgregar.Size = new System.Drawing.Size(124, 30);
            this.btAgregar.TabIndex = 6;
            this.btAgregar.Text = "Realizar";
            this.btAgregar.UseVisualStyleBackColor = true;
            this.btAgregar.Click += new System.EventHandler(this.btAgregar_Click);
            // 
            // tbMarca
            // 
            this.tbMarca.Location = new System.Drawing.Point(220, 103);
            this.tbMarca.Name = "tbMarca";
            this.tbMarca.Size = new System.Drawing.Size(160, 22);
            this.tbMarca.TabIndex = 5;
            // 
            // lbMarca
            // 
            this.lbMarca.AutoSize = true;
            this.lbMarca.Location = new System.Drawing.Point(109, 106);
            this.lbMarca.Name = "lbMarca";
            this.lbMarca.Size = new System.Drawing.Size(105, 17);
            this.lbMarca.TabIndex = 4;
            this.lbMarca.Text = "Nombre Marca:";
            // 
            // agregarMarca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 352);
            this.Controls.Add(this.btSalir);
            this.Controls.Add(this.btAgregar);
            this.Controls.Add(this.tbMarca);
            this.Controls.Add(this.lbMarca);
            this.Name = "agregarMarca";
            this.Text = "Alta Marca";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btSalir;
        private System.Windows.Forms.Button btAgregar;
        private System.Windows.Forms.TextBox tbMarca;
        private System.Windows.Forms.Label lbMarca;
    }
}