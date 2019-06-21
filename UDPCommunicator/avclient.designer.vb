'
' Created by SharpDevelop.
' User: Alfred
' Date: 29/05/2019
' Time: 07:02
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Partial Class avclient
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
        Me.nudport = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtbxipaddress = New System.Windows.Forms.TextBox()
        Me.txtbxripaddress = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.nudrport = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtbxnom = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.nudport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudrport, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(198, 155)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(184, 29)
        Me.TableLayoutPanel1.TabIndex = 2
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
        'nudport
        '
        Me.nudport.Location = New System.Drawing.Point(108, 80)
        Me.nudport.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.nudport.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudport.Name = "nudport"
        Me.nudport.Size = New System.Drawing.Size(271, 20)
        Me.nudport.TabIndex = 1
        Me.nudport.Value = New Decimal(New Integer() {5432, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Port:"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(14, 57)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(61, 13)
        Me.label1.TabIndex = 11
        Me.label1.Text = "IP Address:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(140, 20)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Add/View Client:"
        '
        'txtbxipaddress
        '
        Me.txtbxipaddress.Location = New System.Drawing.Point(108, 54)
        Me.txtbxipaddress.Name = "txtbxipaddress"
        Me.txtbxipaddress.Size = New System.Drawing.Size(271, 20)
        Me.txtbxipaddress.TabIndex = 0
        '
        'txtbxripaddress
        '
        Me.txtbxripaddress.Location = New System.Drawing.Point(108, 106)
        Me.txtbxripaddress.Name = "txtbxripaddress"
        Me.txtbxripaddress.Size = New System.Drawing.Size(271, 20)
        Me.txtbxripaddress.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 109)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "My IP Address:"
        '
        'nudrport
        '
        Me.nudrport.Location = New System.Drawing.Point(108, 132)
        Me.nudrport.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.nudrport.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudrport.Name = "nudrport"
        Me.nudrport.Size = New System.Drawing.Size(271, 20)
        Me.nudrport.TabIndex = 14
        Me.nudrport.Value = New Decimal(New Integer() {5432, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 134)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "My Port:"
        '
        'txtbxnom
        '
        Me.txtbxnom.Location = New System.Drawing.Point(108, 28)
        Me.txtbxnom.Name = "txtbxnom"
        Me.txtbxnom.Size = New System.Drawing.Size(271, 20)
        Me.txtbxnom.TabIndex = 17
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 31)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Name:"
        '
        'avclient
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(384, 186)
        Me.Controls.Add(Me.txtbxnom)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtbxripaddress)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.nudrport)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtbxipaddress)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.nudport)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(400, 225)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(400, 225)
        Me.Name = "avclient"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add/View UDP Client"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.nudport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudrport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents txtbxipaddress As System.Windows.Forms.TextBox
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents nudport As System.Windows.Forms.NumericUpDown
    Private WithEvents Cancel_Button As System.Windows.Forms.Button
    Private WithEvents OK_Button As System.Windows.Forms.Button
    Private WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Private WithEvents txtbxripaddress As System.Windows.Forms.TextBox
    Private WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents nudrport As System.Windows.Forms.NumericUpDown
    Private WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents txtbxnom As System.Windows.Forms.TextBox
    Private WithEvents Label6 As System.Windows.Forms.Label
End Class
