<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormCategoryInput
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
		txtCategoryDesc = New TextBox()
		btnSave = New Button()
		lblWarning = New Label()
		SuspendLayout()
		' 
		' Label1
		' 
		Label1.Font = New Font("Microsoft Sans Serif", 14.0F, FontStyle.Regular, GraphicsUnit.Point)
		Label1.Location = New Point(14, 24)
		Label1.Margin = New Padding(4, 0, 4, 0)
		Label1.Name = "Label1"
		Label1.Size = New Size(420, 27)
		Label1.TabIndex = 0
		Label1.Text = "Add/Update Category"
		Label1.TextAlign = ContentAlignment.MiddleCenter
		' 
		' Label2
		' 
		Label2.AutoSize = True
		Label2.Font = New Font("Microsoft Sans Serif", 9.0F, FontStyle.Bold, GraphicsUnit.Point)
		Label2.Location = New Point(37, 83)
		Label2.Margin = New Padding(4, 0, 4, 0)
		Label2.Name = "Label2"
		Label2.Size = New Size(148, 15)
		Label2.TabIndex = 1
		Label2.Text = "Category Description"
		Label2.TextAlign = ContentAlignment.MiddleLeft
		' 
		' txtCategoryDesc
		' 
		txtCategoryDesc.Font = New Font("Microsoft Sans Serif", 10.0F, FontStyle.Regular, GraphicsUnit.Point)
		txtCategoryDesc.Location = New Point(37, 108)
		txtCategoryDesc.Margin = New Padding(4, 3, 4, 3)
		txtCategoryDesc.Name = "txtCategoryDesc"
		txtCategoryDesc.Size = New Size(379, 23)
		txtCategoryDesc.TabIndex = 2
		' 
		' btnSave
		' 
		btnSave.Font = New Font("Microsoft Sans Serif", 9.0F, FontStyle.Regular, GraphicsUnit.Point)
		btnSave.Location = New Point(318, 190)
		btnSave.Margin = New Padding(4, 3, 4, 3)
		btnSave.Name = "btnSave"
		btnSave.Size = New Size(98, 31)
		btnSave.TabIndex = 3
		btnSave.Text = "Save"
		btnSave.UseVisualStyleBackColor = True
		' 
		' lblWarning
		' 
		lblWarning.Font = New Font("Microsoft Sans Serif", 8.5F, FontStyle.Bold, GraphicsUnit.Point)
		lblWarning.ForeColor = Color.DarkOrange
		lblWarning.Location = New Point(37, 145)
		lblWarning.Margin = New Padding(4, 0, 4, 0)
		lblWarning.Name = "lblWarning"
		lblWarning.Size = New Size(379, 35)
		lblWarning.TabIndex = 4
		lblWarning.Text = "⚠ WARNING: Category is being used"
		lblWarning.TextAlign = ContentAlignment.MiddleLeft
		lblWarning.Visible = False
		' 
		' FormCategoryInput
		' 
		AutoScaleDimensions = New SizeF(7.0F, 15.0F)
		AutoScaleMode = AutoScaleMode.Font
		ClientSize = New Size(453, 239)
		Controls.Add(lblWarning)
		Controls.Add(btnSave)
		Controls.Add(txtCategoryDesc)
		Controls.Add(Label2)
		Controls.Add(Label1)
		FormBorderStyle = FormBorderStyle.FixedDialog
		Margin = New Padding(4, 3, 4, 3)
		MaximizeBox = False
		MinimizeBox = False
		Name = "FormCategoryInput"
		StartPosition = FormStartPosition.CenterParent
		Text = "Add - Edit Category Form"
		ResumeLayout(False)
		PerformLayout()

	End Sub
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents txtCategoryDesc As System.Windows.Forms.TextBox
	Friend WithEvents btnSave As System.Windows.Forms.Button
	Friend WithEvents lblWarning As System.Windows.Forms.Label
End Class
