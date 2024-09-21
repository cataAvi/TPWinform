
namespace TPWinforms
{
    partial class sumarImagen
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
            this.btCargar = new System.Windows.Forms.Button();
            this.tbURLImag = new System.Windows.Forms.TextBox();
            this.lblUrlImagen = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btSalir
            // 
            this.btSalir.Location = new System.Drawing.Point(275, 134);
            this.btSalir.Name = "btSalir";
            this.btSalir.Size = new System.Drawing.Size(90, 32);
            this.btSalir.TabIndex = 7;
            this.btSalir.Text = "Salir";
            this.btSalir.UseVisualStyleBackColor = true;
            this.btSalir.Click += new System.EventHandler(this.btSalir_Click);
            // 
            // btCargar
            // 
            this.btCargar.Location = new System.Drawing.Point(158, 134);
            this.btCargar.Name = "btCargar";
            this.btCargar.Size = new System.Drawing.Size(90, 32);
            this.btCargar.TabIndex = 6;
            this.btCargar.Text = "Cargar";
            this.btCargar.UseVisualStyleBackColor = true;
            this.btCargar.Click += new System.EventHandler(this.btCargar_Click);
            // 
            // tbURLImag
            // 
            this.tbURLImag.Location = new System.Drawing.Point(158, 69);
            this.tbURLImag.Name = "tbURLImag";
            this.tbURLImag.Size = new System.Drawing.Size(194, 22);
            this.tbURLImag.TabIndex = 5;
            // 
            // lblUrlImagen
            // 
            this.lblUrlImagen.AutoSize = true;
            this.lblUrlImagen.Location = new System.Drawing.Point(48, 74);
            this.lblUrlImagen.Name = "lblUrlImagen";
            this.lblUrlImagen.Size = new System.Drawing.Size(90, 17);
            this.lblUrlImagen.TabIndex = 4;
            this.lblUrlImagen.Text = "URL Imagen:";
            // 
            // sumarImagen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 262);
            this.Controls.Add(this.btSalir);
            this.Controls.Add(this.btCargar);
            this.Controls.Add(this.tbURLImag);
            this.Controls.Add(this.lblUrlImagen);
            this.Name = "sumarImagen";
            this.Text = "sumarImagen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btSalir;
        private System.Windows.Forms.Button btCargar;
        private System.Windows.Forms.TextBox tbURLImag;
        private System.Windows.Forms.Label lblUrlImagen;
    }
}