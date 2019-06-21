'
' Created by SharpDevelop.
' User: Alfred
' Date: 29/05/2019
' Time: 10:15
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Partial Class addrec
	Inherits System.Windows.Forms.Form
	
	''' <summary>
	''' Designer variable used to keep track of non-visual components.
	''' </summary>
	Private components As System.ComponentModel.IContainer
	
	''' <summary>
	''' Disposes resources used by the form.
	''' </summary>
	''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing Then
			If components IsNot Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(disposing)
	End Sub
	
	''' <summary>
	''' This method is required for Windows Forms designer support.
	''' Do not change the method contents inside the source code editor. The Forms designer might
	''' not be able to load this method if it was changed manually.
	''' </summary>
	Private Sub InitializeComponent()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.combbxrs = New System.Windows.Forms.ComboBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
		Me.OK_Button = New System.Windows.Forms.Button()
		Me.Cancel_Button = New System.Windows.Forms.Button()
		Me.TableLayoutPanel1.SuspendLayout
		Me.SuspendLayout
		'
		'Label2
		'
		Me.Label2.AutoSize = true
		Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
		Me.Label2.Location = New System.Drawing.Point(12, 9)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(162, 26)
		Me.Label2.TabIndex = 13
		Me.Label2.Text = "Add Receiver:"
		'
		'combbxrs
		'
		Me.combbxrs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.combbxrs.FormattingEnabled = true
		Me.combbxrs.IntegralHeight = false
		Me.combbxrs.Location = New System.Drawing.Point(71, 55)
		Me.combbxrs.Name = "combbxrs"
		Me.combbxrs.Size = New System.Drawing.Size(211, 21)
		Me.combbxrs.TabIndex = 14
		'
		'Label1
		'
		Me.Label1.AutoSize = true
		Me.Label1.Location = New System.Drawing.Point(12, 58)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(53, 13)
		Me.Label1.TabIndex = 15
		Me.Label1.Text = "Reciever:"
		'
		'TableLayoutPanel1
		'
		Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.TableLayoutPanel1.ColumnCount = 2
		Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50!))
		Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50!))
		Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
		Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
		Me.TableLayoutPanel1.Location = New System.Drawing.Point(98, 105)
		Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
		Me.TableLayoutPanel1.RowCount = 1
		Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50!))
		Me.TableLayoutPanel1.Size = New System.Drawing.Size(184, 29)
		Me.TableLayoutPanel1.TabIndex = 16
		'
		'OK_Button
		'
		Me.OK_Button.Dock = System.Windows.Forms.DockStyle.Fill
		Me.OK_Button.Location = New System.Drawing.Point(3, 3)
		Me.OK_Button.Name = "OK_Button"
		Me.OK_Button.Size = New System.Drawing.Size(86, 23)
		Me.OK_Button.TabIndex = 0
		Me.OK_Button.Text = "Ok"
		'
		'Cancel_Button
		'
		Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.Cancel_Button.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Cancel_Button.Location = New System.Drawing.Point(95, 3)
		Me.Cancel_Button.Name = "Cancel_Button"
		Me.Cancel_Button.Size = New System.Drawing.Size(86, 23)
		Me.Cancel_Button.TabIndex = 1
		Me.Cancel_Button.Text = "Cancel"
		'
		'addrec
		'
		Me.AcceptButton = Me.OK_Button
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.Cancel_Button
		Me.ClientSize = New System.Drawing.Size(294, 146)
		Me.Controls.Add(Me.TableLayoutPanel1)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.combbxrs)
		Me.Controls.Add(Me.Label2)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.MaximizeBox = false
		Me.MaximumSize = New System.Drawing.Size(300, 175)
		Me.MinimizeBox = false
		Me.MinimumSize = New System.Drawing.Size(300, 175)
		Me.Name = "addrec"
		Me.ShowInTaskbar = false
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Add Receiver"
		Me.TableLayoutPanel1.ResumeLayout(false)
		Me.ResumeLayout(false)
		Me.PerformLayout
	End Sub
	friend withevents Cancel_Button As System.Windows.Forms.Button
	friend withevents OK_Button As System.Windows.Forms.Button
	friend withevents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
	friend withevents Label1 As System.Windows.Forms.Label
	friend withevents combbxrs As System.Windows.Forms.ComboBox
	friend withevents Label2 As System.Windows.Forms.Label
End Class
