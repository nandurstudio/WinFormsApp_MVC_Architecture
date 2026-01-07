<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormItemInput
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
		Label1 = New Label()
		Label2 = New Label()
		txtItemId = New TextBox()
		txtItemDesc = New TextBox()
		Label3 = New Label()
		Label4 = New Label()
		txtUnit = New TextBox()
		Label5 = New Label()
		txtSalesPrice = New TextBox()
		Label6 = New Label()
		txtMinStock = New TextBox()
		Label7 = New Label()
		cboItemCate = New ComboBox()
		btnSave = New Button()
		SuspendLayout()
		' 
		' Label1
		' 
		Label1.Font = New Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point)
		Label1.Location = New Point(14, 24)
		Label1.Margin = New Padding(4, 0, 4, 0)
		Label1.Name = "Label1"
		Label1.Size = New Size(363, 27)
		Label1.TabIndex = 0
		Label1.Text = "Add/Update Item"
		Label1.TextAlign = ContentAlignment.MiddleCenter
		' 
		' Label2
		' 
		Label2.AutoSize = True
		Label2.Font = New Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point)
		Label2.Location = New Point(37, 83)
		Label2.Margin = New Padding(4, 0, 4, 0)
		Label2.Name = "Label2"
		Label2.Size = New Size(53, 15)
		Label2.TabIndex = 1
		Label2.Text = "Item ID"
		Label2.TextAlign = ContentAlignment.MiddleLeft
		' 
		' txtItemId
		' 
		txtItemId.Location = New Point(137, 82)
		txtItemId.Margin = New Padding(4, 3, 4, 3)
		txtItemId.Name = "txtItemId"
		txtItemId.Size = New Size(205, 23)
		txtItemId.TabIndex = 2
		' 
		' txtItemDesc
		' 
		txtItemDesc.Location = New Point(137, 112)
		txtItemDesc.Margin = New Padding(4, 3, 4, 3)
		txtItemDesc.Name = "txtItemDesc"
		txtItemDesc.Size = New Size(205, 23)
		txtItemDesc.TabIndex = 4
		' 
		' Label3
		' 
		Label3.AutoSize = True
		Label3.Font = New Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point)
		Label3.Location = New Point(37, 113)
		Label3.Margin = New Padding(4, 0, 4, 0)
		Label3.Name = "Label3"
		Label3.Size = New Size(80, 15)
		Label3.TabIndex = 3
		Label3.Text = "Description"
		Label3.TextAlign = ContentAlignment.MiddleLeft
		' 
		' Label4
		' 
		Label4.AutoSize = True
		Label4.Font = New Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point)
		Label4.Location = New Point(37, 143)
		Label4.Margin = New Padding(4, 0, 4, 0)
		Label4.Name = "Label4"
		Label4.Size = New Size(63, 15)
		Label4.TabIndex = 5
		Label4.Text = "Category"
		Label4.TextAlign = ContentAlignment.MiddleLeft
		' 
		' txtUnit
		' 
		txtUnit.Location = New Point(137, 172)
		txtUnit.Margin = New Padding(4, 3, 4, 3)
		txtUnit.Name = "txtUnit"
		txtUnit.Size = New Size(205, 23)
		txtUnit.TabIndex = 8
		' 
		' Label5
		' 
		Label5.AutoSize = True
		Label5.Font = New Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point)
		Label5.Location = New Point(37, 173)
		Label5.Margin = New Padding(4, 0, 4, 0)
		Label5.Name = "Label5"
		Label5.Size = New Size(33, 15)
		Label5.TabIndex = 7
		Label5.Text = "Unit"
		Label5.TextAlign = ContentAlignment.MiddleLeft
		' 
		' txtSalesPrice
		' 
		txtSalesPrice.Location = New Point(137, 202)
		txtSalesPrice.Margin = New Padding(4, 3, 4, 3)
		txtSalesPrice.Name = "txtSalesPrice"
		txtSalesPrice.Size = New Size(205, 23)
		txtSalesPrice.TabIndex = 10
		' 
		' Label6
		' 
		Label6.AutoSize = True
		Label6.Font = New Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point)
		Label6.Location = New Point(37, 203)
		Label6.Margin = New Padding(4, 0, 4, 0)
		Label6.Name = "Label6"
		Label6.Size = New Size(80, 15)
		Label6.TabIndex = 9
		Label6.Text = "Sales Price"
		Label6.TextAlign = ContentAlignment.MiddleLeft
		' 
		' txtMinStock
		' 
		txtMinStock.Location = New Point(137, 232)
		txtMinStock.Margin = New Padding(4, 3, 4, 3)
		txtMinStock.Name = "txtMinStock"
		txtMinStock.Size = New Size(205, 23)
		txtMinStock.TabIndex = 12
		' 
		' Label7
		' 
		Label7.AutoSize = True
		Label7.Font = New Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point)
		Label7.Location = New Point(37, 233)
		Label7.Margin = New Padding(4, 0, 4, 0)
		Label7.Name = "Label7"
		Label7.Size = New Size(74, 15)
		Label7.TabIndex = 11
		Label7.Text = "Min. Stock"
		Label7.TextAlign = ContentAlignment.MiddleLeft
		' 
		' cboItemCate
		' 
		cboItemCate.DropDownStyle = ComboBoxStyle.DropDownList
		cboItemCate.FormattingEnabled = True
		cboItemCate.Location = New Point(137, 143)
		cboItemCate.Margin = New Padding(4, 3, 4, 3)
		cboItemCate.Name = "cboItemCate"
		cboItemCate.Size = New Size(205, 23)
		cboItemCate.TabIndex = 13
		' 
		' btnSave
		' 
		btnSave.Location = New Point(244, 263)
		btnSave.Margin = New Padding(4, 3, 4, 3)
		btnSave.Name = "btnSave"
		btnSave.Size = New Size(98, 31)
		btnSave.TabIndex = 14
		btnSave.Text = "Save"
		btnSave.UseVisualStyleBackColor = True
		' 
		' FormItemInput
		' 
		AutoScaleDimensions = New SizeF(7F, 15F)
		AutoScaleMode = AutoScaleMode.Font
		ClientSize = New Size(391, 313)
		Controls.Add(btnSave)
		Controls.Add(cboItemCate)
		Controls.Add(txtMinStock)
		Controls.Add(Label7)
		Controls.Add(txtSalesPrice)
		Controls.Add(Label6)
		Controls.Add(txtUnit)
		Controls.Add(Label5)
		Controls.Add(Label4)
		Controls.Add(txtItemDesc)
		Controls.Add(Label3)
		Controls.Add(txtItemId)
		Controls.Add(Label2)
		Controls.Add(Label1)
		Margin = New Padding(4, 3, 4, 3)
		Name = "FormItemInput"
		Text = "Add - Edit Item Form"
		ResumeLayout(False)
		PerformLayout()

	End Sub
	Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtItemId As System.Windows.Forms.TextBox
    Friend WithEvents txtItemDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtUnit As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSalesPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtMinStock As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboItemCate As System.Windows.Forms.ComboBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
End Class
