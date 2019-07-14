'
' Created by SharpDevelop.
' User: Alfred
' Date: 29/05/2019
' Time: 07:37
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Partial Class msgve
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.lblt = New System.Windows.Forms.Label()
        Me.txtbxheader = New System.Windows.Forms.TextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.lblhl = New System.Windows.Forms.Label()
        Me.lblnoms = New System.Windows.Forms.Label()
        Me.dudrap = New System.Windows.Forms.DomainUpDown()
        Me.butrecadd = New System.Windows.Forms.Button()
        Me.butrecrem = New System.Windows.Forms.Button()
        Me.butbrw = New System.Windows.Forms.Button()
        Me.txtbxfp = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(298, 180)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(184, 29)
        Me.TableLayoutPanel1.TabIndex = 6
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
        'lblt
        '
        Me.lblt.AutoSize = True
        Me.lblt.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblt.Location = New System.Drawing.Point(12, 9)
        Me.lblt.Name = "lblt"
        Me.lblt.Size = New System.Drawing.Size(378, 26)
        Me.lblt.TabIndex = 13
        Me.lblt.Text = "Message Viewer / Editor / Creator:"
        '
        'txtbxheader
        '
        Me.txtbxheader.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbxheader.Location = New System.Drawing.Point(63, 83)
        Me.txtbxheader.MaxLength = 1024
        Me.txtbxheader.Name = "txtbxheader"
        Me.txtbxheader.Size = New System.Drawing.Size(324, 20)
        Me.txtbxheader.TabIndex = 3
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(8, 85)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(45, 13)
        Me.label1.TabIndex = 14
        Me.label1.Text = "Header:"
        '
        'lblhl
        '
        Me.lblhl.AutoSize = True
        Me.lblhl.Font = New System.Drawing.Font("Consolas", 8.25!)
        Me.lblhl.Location = New System.Drawing.Point(399, 85)
        Me.lblhl.Name = "lblhl"
        Me.lblhl.Size = New System.Drawing.Size(73, 13)
        Me.lblhl.TabIndex = 16
        Me.lblhl.Text = "   0 / 1024"
        '
        'lblnoms
        '
        Me.lblnoms.AutoSize = True
        Me.lblnoms.Location = New System.Drawing.Point(8, 50)
        Me.lblnoms.Name = "lblnoms"
        Me.lblnoms.Size = New System.Drawing.Size(43, 13)
        Me.lblnoms.TabIndex = 20
        Me.lblnoms.Text = "Names:"
        '
        'dudrap
        '
        Me.dudrap.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dudrap.Location = New System.Drawing.Point(63, 48)
        Me.dudrap.Margin = New System.Windows.Forms.Padding(1)
        Me.dudrap.Name = "dudrap"
        Me.dudrap.ReadOnly = True
        Me.dudrap.Size = New System.Drawing.Size(323, 20)
        Me.dudrap.TabIndex = 0
        '
        'butrecadd
        '
        Me.butrecadd.Location = New System.Drawing.Point(391, 48)
        Me.butrecadd.Name = "butrecadd"
        Me.butrecadd.Size = New System.Drawing.Size(20, 20)
        Me.butrecadd.TabIndex = 1
        Me.butrecadd.Text = "+"
        Me.butrecadd.UseVisualStyleBackColor = True
        '
        'butrecrem
        '
        Me.butrecrem.Location = New System.Drawing.Point(417, 48)
        Me.butrecrem.Name = "butrecrem"
        Me.butrecrem.Size = New System.Drawing.Size(20, 20)
        Me.butrecrem.TabIndex = 2
        Me.butrecrem.Text = "-"
        Me.butrecrem.UseVisualStyleBackColor = True
        '
        'butbrw
        '
        Me.butbrw.Location = New System.Drawing.Point(393, 130)
        Me.butbrw.Name = "butbrw"
        Me.butbrw.Size = New System.Drawing.Size(86, 23)
        Me.butbrw.TabIndex = 5
        Me.butbrw.Text = "Browse..."
        Me.butbrw.UseVisualStyleBackColor = True
        '
        'txtbxfp
        '
        Me.txtbxfp.Location = New System.Drawing.Point(63, 132)
        Me.txtbxfp.Name = "txtbxfp"
        Me.txtbxfp.Size = New System.Drawing.Size(324, 20)
        Me.txtbxfp.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(2, 135)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 13)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "File Path:"
        '
        'msgve
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(484, 211)
        Me.Controls.Add(Me.butbrw)
        Me.Controls.Add(Me.txtbxfp)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.butrecrem)
        Me.Controls.Add(Me.butrecadd)
        Me.Controls.Add(Me.dudrap)
        Me.Controls.Add(Me.lblnoms)
        Me.Controls.Add(Me.lblhl)
        Me.Controls.Add(Me.txtbxheader)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.lblt)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(500, 250)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(500, 250)
        Me.Name = "msgve"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Message Viewer/Editor/Creator"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
	friend withevents butrecrem As System.Windows.Forms.Button
	friend withevents butrecadd As System.Windows.Forms.Button
    Friend WithEvents lblhl As System.Windows.Forms.Label
	friend withevents label1 As System.Windows.Forms.Label
	friend withevents txtbxheader As System.Windows.Forms.TextBox
	friend withevents lblt As System.Windows.Forms.Label
	friend withevents Cancel_Button As System.Windows.Forms.Button
	friend withevents OK_Button As System.Windows.Forms.Button
    friend withevents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblnoms As System.Windows.Forms.Label
    Private WithEvents dudrap As System.Windows.Forms.DomainUpDown
    Friend WithEvents butbrw As System.Windows.Forms.Button
    Private WithEvents txtbxfp As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
