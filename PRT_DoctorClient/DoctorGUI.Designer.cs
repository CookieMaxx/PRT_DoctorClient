namespace PRT_DoctorClient
{
    partial class DoctorGUI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnSend = new Button();
            btnConnect = new Button();
            checkSurveyQuestions = new CheckedListBox();
            checkMedication = new CheckedListBox();
            listPatient = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            lblPatientInfo = new Label();
            label1 = new Label();
            label2 = new Label();
            listServerCom = new ListView();
            bindingSource1 = new BindingSource(components);
            label3 = new Label();
            checkPatients = new CheckedListBox();
            label4 = new Label();
            label5 = new Label();
            btnRefresh = new Button();
            btnReset = new Button();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // btnSend
            // 
            btnSend.Location = new Point(12, 508);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(180, 80);
            btnSend.TabIndex = 0;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(198, 508);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(180, 80);
            btnConnect.TabIndex = 1;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // checkSurveyQuestions
            // 
            checkSurveyQuestions.FormattingEnabled = true;
            checkSurveyQuestions.Location = new Point(871, 43);
            checkSurveyQuestions.Name = "checkSurveyQuestions";
            checkSurveyQuestions.Size = new Size(327, 418);
            checkSurveyQuestions.TabIndex = 2;
            checkSurveyQuestions.SelectedIndexChanged += checkSurveyQuestions_SelectedIndexChanged;
            // 
            // checkMedication
            // 
            checkMedication.FormattingEnabled = true;
            checkMedication.Location = new Point(1204, 43);
            checkMedication.Name = "checkMedication";
            checkMedication.Size = new Size(327, 418);
            checkMedication.TabIndex = 3;
            checkMedication.SelectedIndexChanged += checkMedication_SelectedIndexChanged;
            // 
            // listPatient
            // 
            listPatient.AutoArrange = false;
            listPatient.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            listPatient.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listPatient.LabelWrap = false;
            listPatient.Location = new Point(12, 43);
            listPatient.Name = "listPatient";
            listPatient.Size = new Size(808, 418);
            listPatient.TabIndex = 4;
            listPatient.UseCompatibleStateImageBehavior = false;
            listPatient.SelectedIndexChanged += listPatient_SelectedIndexChanged;
            // 
            // lblPatientInfo
            // 
            lblPatientInfo.AutoSize = true;
            lblPatientInfo.Font = new Font("Segoe UI", 15F);
            lblPatientInfo.Location = new Point(12, 12);
            lblPatientInfo.Name = "lblPatientInfo";
            lblPatientInfo.Size = new Size(180, 28);
            lblPatientInfo.TabIndex = 5;
            lblPatientInfo.Text = "Patient Information";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(871, 12);
            label1.Name = "label1";
            label1.Size = new Size(163, 28);
            label1.TabIndex = 6;
            label1.Text = "Survey Questions";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(1204, 12);
            label2.Name = "label2";
            label2.Size = new Size(119, 28);
            label2.TabIndex = 7;
            label2.Text = "Medications";
            // 
            // listServerCom
            // 
            listServerCom.LabelWrap = false;
            listServerCom.Location = new Point(616, 508);
            listServerCom.MultiSelect = false;
            listServerCom.Name = "listServerCom";
            listServerCom.ShowGroups = false;
            listServerCom.Size = new Size(915, 166);
            listServerCom.Sorting = SortOrder.Descending;
            listServerCom.TabIndex = 9;
            listServerCom.UseCompatibleStateImageBehavior = false;
            listServerCom.SelectedIndexChanged += listServerCom_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F);
            label3.Location = new Point(616, 473);
            label3.Name = "label3";
            label3.Size = new Size(250, 28);
            label3.TabIndex = 10;
            label3.Text = "Server Communication Info";
            // 
            // checkPatients
            // 
            checkPatients.FormattingEnabled = true;
            checkPatients.Location = new Point(384, 508);
            checkPatients.Name = "checkPatients";
            checkPatients.Size = new Size(226, 166);
            checkPatients.TabIndex = 11;
            checkPatients.SelectedIndexChanged += checkPatients_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15F);
            label4.Location = new Point(517, 473);
            label4.Name = "label4";
            label4.Size = new Size(0, 28);
            label4.TabIndex = 12;
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15F);
            label5.Location = new Point(384, 473);
            label5.Name = "label5";
            label5.Size = new Size(80, 28);
            label5.TabIndex = 13;
            label5.Text = "Patients";
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(12, 594);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(180, 80);
            btnRefresh.TabIndex = 14;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(198, 594);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(180, 80);
            btnReset.TabIndex = 15;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // DoctorGUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1543, 684);
            Controls.Add(btnReset);
            Controls.Add(btnRefresh);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(checkPatients);
            Controls.Add(label3);
            Controls.Add(listServerCom);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblPatientInfo);
            Controls.Add(listPatient);
            Controls.Add(checkMedication);
            Controls.Add(checkSurveyQuestions);
            Controls.Add(btnConnect);
            Controls.Add(btnSend);
            Name = "DoctorGUI";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSend;
        private Button btnConnect;
        private CheckedListBox checkSurveyQuestions;
        private CheckedListBox checkMedication;
        private ListView listPatient;
        private Label lblPatientInfo;
        private Label label1;
        private Label label2;
        private ListView listServerCom;
        private BindingSource bindingSource1;
        private Label label3;
        private CheckedListBox checkPatients;
        private Label label4;
        private Label label5;
        private Button btnRefresh;
        private Button btnReset;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
    }
}
