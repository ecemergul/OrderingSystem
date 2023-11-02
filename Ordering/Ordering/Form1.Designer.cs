using System;

namespace Ordering
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.txtProductID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonInsert = new System.Windows.Forms.Button();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPiece = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.btnSelectUsers = new System.Windows.Forms.Button();
            this.btnSelectProducts = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvData
            // 
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(76, 240);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersWidth = 62;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(509, 206);
            this.dgvData.TabIndex = 0;
            this.dgvData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellClick);
            // 
            // txtUserID
            // 
            this.txtUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtUserID.Location = new System.Drawing.Point(76, 139);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(159, 26);
            this.txtUserID.TabIndex = 1;
            // 
            // txtProductID
            // 
            this.txtProductID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtProductID.Location = new System.Drawing.Point(256, 139);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.Size = new System.Drawing.Size(145, 26);
            this.txtProductID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(73, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(252, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Product ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(73, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "User ID";
            // 
            // buttonInsert
            // 
            this.buttonInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonInsert.Location = new System.Drawing.Point(160, 171);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new System.Drawing.Size(145, 50);
            this.buttonInsert.TabIndex = 4;
            this.buttonInsert.Text = "Order";
            this.buttonInsert.UseVisualStyleBackColor = true;
            this.buttonInsert.Click += new System.EventHandler(this.buttonInsert_Click);
            // 
            // buttonSelect
            // 
            this.buttonSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonSelect.Location = new System.Drawing.Point(620, 391);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(179, 72);
            this.buttonSelect.TabIndex = 4;
            this.buttonSelect.Text = "Load Orders";
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(368, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(201, 52);
            this.label4.TabIndex = 2;
            this.label4.Text = "Ordering";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // txtPiece
            // 
            this.txtPiece.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtPiece.Location = new System.Drawing.Point(419, 139);
            this.txtPiece.Name = "txtPiece";
            this.txtPiece.Size = new System.Drawing.Size(150, 26);
            this.txtPiece.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(420, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Pieces";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonDelete.Location = new System.Drawing.Point(358, 171);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(144, 50);
            this.buttonDelete.TabIndex = 6;
            this.buttonDelete.Text = "Delete Order";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // btnSelectUsers
            // 
            this.btnSelectUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSelectUsers.Location = new System.Drawing.Point(620, 171);
            this.btnSelectUsers.Name = "btnSelectUsers";
            this.btnSelectUsers.Size = new System.Drawing.Size(179, 71);
            this.btnSelectUsers.TabIndex = 7;
            this.btnSelectUsers.Text = "Load Users";
            this.btnSelectUsers.UseVisualStyleBackColor = true;
            this.btnSelectUsers.Click += new System.EventHandler(this.btnSelectUsers_Click);
            // 
            // btnSelectProducts
            // 
            this.btnSelectProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSelectProducts.Location = new System.Drawing.Point(620, 281);
            this.btnSelectProducts.Name = "btnSelectProducts";
            this.btnSelectProducts.Size = new System.Drawing.Size(179, 72);
            this.btnSelectProducts.TabIndex = 7;
            this.btnSelectProducts.Text = "Load Products";
            this.btnSelectProducts.UseVisualStyleBackColor = true;
            this.btnSelectProducts.Click += new System.EventHandler(this.btnSelectProducts_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 505);
            this.Controls.Add(this.btnSelectProducts);
            this.Controls.Add(this.btnSelectUsers);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonSelect);
            this.Controls.Add(this.buttonInsert);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPiece);
            this.Controls.Add(this.txtProductID);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.dgvData);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void label5_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        

        #endregion

        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.TextBox txtProductID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonInsert;
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPiece;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button btnSelectUsers;
        private System.Windows.Forms.Button btnSelectProducts;
    }
}

