<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class config
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.combbxif = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkbxbf = New System.Windows.Forms.CheckBox()
        Me.nudport = New System.Windows.Forms.NumericUpDown()
        Me.txtbxripaddress = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.nudrport = New System.Windows.Forms.NumericUpDown()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(388, 180)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(184, 29)
        Me.TableLayoutPanel1.TabIndex = 5
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(10, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(341, 26)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Configure UDP Communicator:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Port:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Network Interface:"
        '
        'combbxif
        '
        Me.combbxif.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combbxif.FormattingEnabled = True
        Me.combbxif.Location = New System.Drawing.Point(113, 52)
        Me.combbxif.Name = "combbxif"
        Me.combbxif.Size = New System.Drawing.Size(456, 21)
        Me.combbxif.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Enabled = False
        Me.Label4.Location = New System.Drawing.Point(13, 163)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Buffer Send:"
        '
        'chkbxbf
        '
        Me.chkbxbf.AutoSize = True
        Me.chkbxbf.Checked = True
        Me.chkbxbf.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkbxbf.Enabled = False
        Me.chkbxbf.Location = New System.Drawing.Point(113, 163)
        Me.chkbxbf.Name = "chkbxbf"
        Me.chkbxbf.Size = New System.Drawing.Size(15, 14)
        Me.chkbxbf.TabIndex = 4
        Me.chkbxbf.UseVisualStyleBackColor = True
        '
        'nudport
        '
        Me.nudport.Location = New System.Drawing.Point(113, 82)
        Me.nudport.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.nudport.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudport.Name = "nudport"
        Me.nudport.Size = New System.Drawing.Size(456, 20)
        Me.nudport.TabIndex = 1
        Me.nudport.Value = New Decimal(New Integer() {5432, 0, 0, 0})
        '
        'txtbxripaddress
        '
        Me.txtbxripaddress.Location = New System.Drawing.Point(113, 107)
        Me.txtbxripaddress.Name = "txtbxripaddress"
        Me.txtbxripaddress.Size = New System.Drawing.Size(456, 20)
        Me.txtbxripaddress.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 110)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 13)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "My IP Address:"
        '
        'nudrport
        '
        Me.nudrport.Location = New System.Drawing.Point(113, 130)
        Me.nudrport.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.nudrport.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudrport.Name = "nudrport"
        Me.nudrport.Size = New System.Drawing.Size(456, 20)
        Me.nudrport.TabIndex = 3
        Me.nudrport.Value = New Decimal(New Integer() {5432, 0, 0, 0})
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 137)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "My Port:"
        '
        'config
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(584, 211)
        Me.Controls.Add(Me.txtbxripaddress)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.nudrport)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.nudport)
        Me.Controls.Add(Me.chkbxbf)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.combbxif)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(600, 250)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(600, 250)
        Me.Name = "config"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Configure UDP Communicator"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.nudport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudrport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Private nudport As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents combbxif As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkbxbf As System.Windows.Forms.CheckBox
    Private WithEvents txtbxripaddress As System.Windows.Forms.TextBox
    Private WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents nudrport As System.Windows.Forms.NumericUpDown
    Private WithEvents Label6 As System.Windows.Forms.Label

End Class
