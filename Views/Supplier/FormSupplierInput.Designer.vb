<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormSupplierInput
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Label1 = New Label()
        Label2 = New Label()
        txtSupplierName = New TextBox()
        Label3 = New Label()
        txtContact = New TextBox()
        Label4 = New Label()
        txtPhone = New TextBox()
        Label5 = New Label()
        txtEmail = New TextBox()
        Label6 = New Label()
        txtAddress = New TextBox()
        Label7 = New Label()
        txtCity = New TextBox()
        btnSave = New Button()
        btnCancel = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.Font = New Font("Microsoft Sans Serif", 14.0F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.Location = New Point(14, 24)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(520, 27)
        Label1.TabIndex = 0
        Label1.Text = "Add/Update Supplier"
        Label1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Microsoft Sans Serif", 9.0F, FontStyle.Bold, GraphicsUnit.Point)
        Label2.Location = New Point(37, 70)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(105, 15)
        Label2.TabIndex = 1
        Label2.Text = "Nama Supplier"
        ' 
        ' txtSupplierName
        ' 
        txtSupplierName.Font = New Font("Microsoft Sans Serif", 10.0F, FontStyle.Regular, GraphicsUnit.Point)
        txtSupplierName.Location = New Point(37, 95)
        txtSupplierName.Margin = New Padding(4, 3, 4, 3)
        txtSupplierName.Name = "txtSupplierName"
        txtSupplierName.Size = New Size(460, 23)
        txtSupplierName.TabIndex = 2
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Microsoft Sans Serif", 9.0F, FontStyle.Bold, GraphicsUnit.Point)
        Label3.Location = New Point(37, 130)
        Label3.Margin = New Padding(4, 0, 4, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(102, 15)
        Label3.TabIndex = 3
        Label3.Text = "Contact Person"
        ' 
        ' txtContact
        ' 
        txtContact.Font = New Font("Microsoft Sans Serif", 10.0F, FontStyle.Regular, GraphicsUnit.Point)
        txtContact.Location = New Point(37, 155)
        txtContact.Margin = New Padding(4, 3, 4, 3)
        txtContact.Name = "txtContact"
        txtContact.Size = New Size(460, 23)
        txtContact.TabIndex = 4
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Microsoft Sans Serif", 9.0F, FontStyle.Bold, GraphicsUnit.Point)
        Label4.Location = New Point(37, 190)
        Label4.Margin = New Padding(4, 0, 4, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(60, 15)
        Label4.TabIndex = 5
        Label4.Text = "Telepon"
        ' 
        ' txtPhone
        ' 
        txtPhone.Font = New Font("Microsoft Sans Serif", 10.0F, FontStyle.Regular, GraphicsUnit.Point)
        txtPhone.Location = New Point(37, 215)
        txtPhone.Margin = New Padding(4, 3, 4, 3)
        txtPhone.Name = "txtPhone"
        txtPhone.Size = New Size(220, 23)
        txtPhone.TabIndex = 6
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Microsoft Sans Serif", 9.0F, FontStyle.Bold, GraphicsUnit.Point)
        Label5.Location = New Point(277, 190)
        Label5.Margin = New Padding(4, 0, 4, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(41, 15)
        Label5.TabIndex = 7
        Label5.Text = "Email"
        ' 
        ' txtEmail
        ' 
        txtEmail.Font = New Font("Microsoft Sans Serif", 10.0F, FontStyle.Regular, GraphicsUnit.Point)
        txtEmail.Location = New Point(277, 215)
        txtEmail.Margin = New Padding(4, 3, 4, 3)
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(220, 23)
        txtEmail.TabIndex = 8
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Microsoft Sans Serif", 9.0F, FontStyle.Bold, GraphicsUnit.Point)
        Label6.Location = New Point(37, 250)
        Label6.Margin = New Padding(4, 0, 4, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(52, 15)
        Label6.TabIndex = 9
        Label6.Text = "Alamat"
        ' 
        ' txtAddress
        ' 
        txtAddress.Font = New Font("Microsoft Sans Serif", 10.0F, FontStyle.Regular, GraphicsUnit.Point)
        txtAddress.Location = New Point(37, 275)
        txtAddress.Margin = New Padding(4, 3, 4, 3)
        txtAddress.Multiline = True
        txtAddress.Name = "txtAddress"
        txtAddress.Size = New Size(460, 60)
        txtAddress.TabIndex = 10
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Microsoft Sans Serif", 9.0F, FontStyle.Bold, GraphicsUnit.Point)
        Label7.Location = New Point(37, 350)
        Label7.Margin = New Padding(4, 0, 4, 0)
        Label7.Name = "Label7"
        Label7.Size = New Size(36, 15)
        Label7.TabIndex = 11
        Label7.Text = "Kota"
        ' 
        ' txtCity
        ' 
        txtCity.Font = New Font("Microsoft Sans Serif", 10.0F, FontStyle.Regular, GraphicsUnit.Point)
        txtCity.Location = New Point(37, 375)
        txtCity.Margin = New Padding(4, 3, 4, 3)
        txtCity.Name = "txtCity"
        txtCity.Size = New Size(220, 23)
        txtCity.TabIndex = 12
        ' 
        ' btnSave
        ' 
        btnSave.Font = New Font("Microsoft Sans Serif", 9.0F, FontStyle.Regular, GraphicsUnit.Point)
        btnSave.Location = New Point(323, 420)
        btnSave.Margin = New Padding(4, 3, 4, 3)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(88, 31)
        btnSave.TabIndex = 13
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = True
        ' 
        ' btnCancel
        ' 
        btnCancel.Font = New Font("Microsoft Sans Serif", 9.0F, FontStyle.Regular, GraphicsUnit.Point)
        btnCancel.Location = New Point(419, 420)
        btnCancel.Margin = New Padding(4, 3, 4, 3)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(88, 31)
        btnCancel.TabIndex = 14
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = True
        ' 
        ' FormSupplierInput
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(534, 471)
        Controls.Add(btnCancel)
        Controls.Add(btnSave)
        Controls.Add(txtCity)
        Controls.Add(Label7)
        Controls.Add(txtAddress)
        Controls.Add(Label6)
        Controls.Add(txtEmail)
        Controls.Add(Label5)
        Controls.Add(txtPhone)
        Controls.Add(Label4)
        Controls.Add(txtContact)
        Controls.Add(Label3)
        Controls.Add(txtSupplierName)
        Controls.Add(Label2)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.FixedDialog
        Margin = New Padding(4, 3, 4, 3)
        MaximizeBox = False
        MinimizeBox = False
        Name = "FormSupplierInput"
        StartPosition = FormStartPosition.CenterParent
        Text = "Add - Edit Supplier Form"
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSupplierName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtContact As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPhone As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
