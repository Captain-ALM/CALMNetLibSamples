'
' Created by SharpDevelop.
' User: Alfred
' Date: 24/05/2019
' Time: 11:47
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Partial Class MainForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.splitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.tableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.tableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.butcmci = New System.Windows.Forms.Button()
        Me.butcmsm = New System.Windows.Forms.Button()
        Me.butcmcls = New System.Windows.Forms.Button()
        Me.butcmadd = New System.Windows.Forms.Button()
        Me.butcmrem = New System.Windows.Forms.Button()
        Me.lstvcm = New System.Windows.Forms.ListView()
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.columnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.columnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.columnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.splitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.tableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.tableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel()
        Me.butmmdel = New System.Windows.Forms.Button()
        Me.butmmcls = New System.Windows.Forms.Button()
        Me.butmmprev = New System.Windows.Forms.Button()
        Me.butmmnew = New System.Windows.Forms.Button()
        Me.lstvmm = New System.Windows.Forms.ListView()
        Me.columnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.columnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.columnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.columnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.groupBox3 = New System.Windows.Forms.GroupBox()
        Me.tableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.tableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel()
        Me.butmpdel = New System.Windows.Forms.Button()
        Me.butmpclo = New System.Windows.Forms.Button()
        Me.butmpv = New System.Windows.Forms.Button()
        Me.butmpech = New System.Windows.Forms.Button()
        Me.txtbxmpv = New System.Windows.Forms.TextBox()
        Me.groupBox4 = New System.Windows.Forms.GroupBox()
        Me.tableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.butscls = New System.Windows.Forms.Button()
        Me.butrset = New System.Windows.Forms.Button()
        Me.lblstatus = New System.Windows.Forms.Label()
        Me.progb1 = New System.Windows.Forms.ProgressBar()
        Me.dudla = New System.Windows.Forms.DomainUpDown()
        Me.txtbxlp = New System.Windows.Forms.TextBox()
        Me.butabout = New System.Windows.Forms.Button()
        Me.tableLayoutPanel1.SuspendLayout()
        CType(Me.splitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitContainer1.Panel1.SuspendLayout()
        Me.splitContainer1.Panel2.SuspendLayout()
        Me.splitContainer1.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.tableLayoutPanel3.SuspendLayout()
        Me.tableLayoutPanel4.SuspendLayout()
        CType(Me.splitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitContainer2.Panel1.SuspendLayout()
        Me.splitContainer2.Panel2.SuspendLayout()
        Me.splitContainer2.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        Me.tableLayoutPanel5.SuspendLayout()
        Me.tableLayoutPanel8.SuspendLayout()
        Me.groupBox3.SuspendLayout()
        Me.tableLayoutPanel6.SuspendLayout()
        Me.tableLayoutPanel7.SuspendLayout()
        Me.groupBox4.SuspendLayout()
        Me.tableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'tableLayoutPanel1
        '
        Me.tableLayoutPanel1.ColumnCount = 2
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.0!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.tableLayoutPanel1.Controls.Add(Me.Label2, 0, 0)
        Me.tableLayoutPanel1.Controls.Add(Me.splitContainer1, 0, 1)
        Me.tableLayoutPanel1.Controls.Add(Me.groupBox4, 0, 2)
        Me.tableLayoutPanel1.Controls.Add(Me.butabout, 1, 0)
        Me.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.tableLayoutPanel1.Margin = New System.Windows.Forms.Padding(5)
        Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
        Me.tableLayoutPanel1.RowCount = 3
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tableLayoutPanel1.Size = New System.Drawing.Size(584, 361)
        Me.tableLayoutPanel1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(490, 36)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "UDP Communicator:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'splitContainer1
        '
        Me.tableLayoutPanel1.SetColumnSpan(Me.splitContainer1, 2)
        Me.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitContainer1.Location = New System.Drawing.Point(0, 36)
        Me.splitContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.splitContainer1.Name = "splitContainer1"
        Me.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitContainer1.Panel1
        '
        Me.splitContainer1.Panel1.Controls.Add(Me.groupBox1)
        Me.splitContainer1.Panel1MinSize = 100
        '
        'splitContainer1.Panel2
        '
        Me.splitContainer1.Panel2.Controls.Add(Me.splitContainer2)
        Me.splitContainer1.Panel2MinSize = 100
        Me.splitContainer1.Size = New System.Drawing.Size(584, 252)
        Me.splitContainer1.SplitterDistance = 124
        Me.splitContainer1.TabIndex = 4
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.tableLayoutPanel3)
        Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.groupBox1.Location = New System.Drawing.Point(0, 0)
        Me.groupBox1.Margin = New System.Windows.Forms.Padding(1)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(584, 124)
        Me.groupBox1.TabIndex = 0
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Client Manager"
        '
        'tableLayoutPanel3
        '
        Me.tableLayoutPanel3.ColumnCount = 1
        Me.tableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tableLayoutPanel3.Controls.Add(Me.tableLayoutPanel4, 0, 0)
        Me.tableLayoutPanel3.Controls.Add(Me.lstvcm, 0, 1)
        Me.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tableLayoutPanel3.Location = New System.Drawing.Point(3, 16)
        Me.tableLayoutPanel3.Margin = New System.Windows.Forms.Padding(0)
        Me.tableLayoutPanel3.Name = "tableLayoutPanel3"
        Me.tableLayoutPanel3.RowCount = 2
        Me.tableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.0!))
        Me.tableLayoutPanel3.Size = New System.Drawing.Size(578, 105)
        Me.tableLayoutPanel3.TabIndex = 0
        '
        'tableLayoutPanel4
        '
        Me.tableLayoutPanel4.ColumnCount = 5
        Me.tableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tableLayoutPanel4.Controls.Add(Me.butcmci, 2, 0)
        Me.tableLayoutPanel4.Controls.Add(Me.butcmsm, 3, 0)
        Me.tableLayoutPanel4.Controls.Add(Me.butcmcls, 4, 0)
        Me.tableLayoutPanel4.Controls.Add(Me.butcmadd, 0, 0)
        Me.tableLayoutPanel4.Controls.Add(Me.butcmrem, 1, 0)
        Me.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tableLayoutPanel4.Location = New System.Drawing.Point(0, 0)
        Me.tableLayoutPanel4.Margin = New System.Windows.Forms.Padding(0)
        Me.tableLayoutPanel4.Name = "tableLayoutPanel4"
        Me.tableLayoutPanel4.RowCount = 1
        Me.tableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tableLayoutPanel4.Size = New System.Drawing.Size(578, 21)
        Me.tableLayoutPanel4.TabIndex = 0
        '
        'butcmci
        '
        Me.butcmci.Dock = System.Windows.Forms.DockStyle.Fill
        Me.butcmci.Location = New System.Drawing.Point(230, 0)
        Me.butcmci.Margin = New System.Windows.Forms.Padding(0)
        Me.butcmci.Name = "butcmci"
        Me.butcmci.Size = New System.Drawing.Size(115, 21)
        Me.butcmci.TabIndex = 2
        Me.butcmci.Text = "Client Information"
        Me.butcmci.UseVisualStyleBackColor = True
        '
        'butcmsm
        '
        Me.butcmsm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.butcmsm.Location = New System.Drawing.Point(345, 0)
        Me.butcmsm.Margin = New System.Windows.Forms.Padding(0)
        Me.butcmsm.Name = "butcmsm"
        Me.butcmsm.Size = New System.Drawing.Size(115, 21)
        Me.butcmsm.TabIndex = 3
        Me.butcmsm.Text = "Send Message"
        Me.butcmsm.UseVisualStyleBackColor = True
        '
        'butcmcls
        '
        Me.butcmcls.Dock = System.Windows.Forms.DockStyle.Fill
        Me.butcmcls.Location = New System.Drawing.Point(460, 0)
        Me.butcmcls.Margin = New System.Windows.Forms.Padding(0)
        Me.butcmcls.Name = "butcmcls"
        Me.butcmcls.Size = New System.Drawing.Size(118, 21)
        Me.butcmcls.TabIndex = 4
        Me.butcmcls.Text = "Clear Clients"
        Me.butcmcls.UseVisualStyleBackColor = True
        '
        'butcmadd
        '
        Me.butcmadd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.butcmadd.Location = New System.Drawing.Point(0, 0)
        Me.butcmadd.Margin = New System.Windows.Forms.Padding(0)
        Me.butcmadd.Name = "butcmadd"
        Me.butcmadd.Size = New System.Drawing.Size(115, 21)
        Me.butcmadd.TabIndex = 0
        Me.butcmadd.Text = "Add Client"
        Me.butcmadd.UseVisualStyleBackColor = True
        '
        'butcmrem
        '
        Me.butcmrem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.butcmrem.Location = New System.Drawing.Point(115, 0)
        Me.butcmrem.Margin = New System.Windows.Forms.Padding(0)
        Me.butcmrem.Name = "butcmrem"
        Me.butcmrem.Size = New System.Drawing.Size(115, 21)
        Me.butcmrem.TabIndex = 1
        Me.butcmrem.Text = "Remove Client"
        Me.butcmrem.UseVisualStyleBackColor = True
        '
        'lstvcm
        '
        Me.lstvcm.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader10, Me.columnHeader1, Me.columnHeader2, Me.columnHeader3, Me.ColumnHeader8, Me.ColumnHeader9})
        Me.lstvcm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstvcm.FullRowSelect = True
        Me.lstvcm.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lstvcm.Location = New System.Drawing.Point(3, 24)
        Me.lstvcm.Name = "lstvcm"
        Me.lstvcm.ShowGroups = False
        Me.lstvcm.Size = New System.Drawing.Size(572, 78)
        Me.lstvcm.TabIndex = 1
        Me.lstvcm.UseCompatibleStateImageBehavior = False
        Me.lstvcm.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Client ID"
        Me.ColumnHeader10.Width = 0
        '
        'columnHeader1
        '
        Me.columnHeader1.Text = "Client Name"
        Me.columnHeader1.Width = 210
        '
        'columnHeader2
        '
        Me.columnHeader2.Text = "Client IP Address"
        Me.columnHeader2.Width = 120
        '
        'columnHeader3
        '
        Me.columnHeader3.Text = "Client Port"
        Me.columnHeader3.Width = 90
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "My IP Address"
        Me.ColumnHeader8.Width = 120
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "My Port"
        Me.ColumnHeader9.Width = 90
        '
        'splitContainer2
        '
        Me.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.splitContainer2.Margin = New System.Windows.Forms.Padding(0)
        Me.splitContainer2.Name = "splitContainer2"
        '
        'splitContainer2.Panel1
        '
        Me.splitContainer2.Panel1.Controls.Add(Me.groupBox2)
        Me.splitContainer2.Panel1MinSize = 150
        '
        'splitContainer2.Panel2
        '
        Me.splitContainer2.Panel2.Controls.Add(Me.groupBox3)
        Me.splitContainer2.Panel2Collapsed = True
        Me.splitContainer2.Panel2MinSize = 150
        Me.splitContainer2.Size = New System.Drawing.Size(584, 124)
        Me.splitContainer2.SplitterDistance = 150
        Me.splitContainer2.TabIndex = 0
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.tableLayoutPanel5)
        Me.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.groupBox2.Location = New System.Drawing.Point(0, 0)
        Me.groupBox2.Margin = New System.Windows.Forms.Padding(0)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(584, 124)
        Me.groupBox2.TabIndex = 0
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Message Manager"
        '
        'tableLayoutPanel5
        '
        Me.tableLayoutPanel5.ColumnCount = 1
        Me.tableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tableLayoutPanel5.Controls.Add(Me.tableLayoutPanel8, 0, 1)
        Me.tableLayoutPanel5.Controls.Add(Me.lstvmm, 0, 0)
        Me.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tableLayoutPanel5.Location = New System.Drawing.Point(3, 16)
        Me.tableLayoutPanel5.Name = "tableLayoutPanel5"
        Me.tableLayoutPanel5.RowCount = 2
        Me.tableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.0!))
        Me.tableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tableLayoutPanel5.Size = New System.Drawing.Size(578, 105)
        Me.tableLayoutPanel5.TabIndex = 0
        '
        'tableLayoutPanel8
        '
        Me.tableLayoutPanel8.ColumnCount = 4
        Me.tableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tableLayoutPanel8.Controls.Add(Me.butmmdel, 0, 0)
        Me.tableLayoutPanel8.Controls.Add(Me.butmmcls, 0, 0)
        Me.tableLayoutPanel8.Controls.Add(Me.butmmprev, 0, 0)
        Me.tableLayoutPanel8.Controls.Add(Me.butmmnew, 0, 0)
        Me.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tableLayoutPanel8.Location = New System.Drawing.Point(0, 84)
        Me.tableLayoutPanel8.Margin = New System.Windows.Forms.Padding(0)
        Me.tableLayoutPanel8.Name = "tableLayoutPanel8"
        Me.tableLayoutPanel8.RowCount = 1
        Me.tableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.tableLayoutPanel8.Size = New System.Drawing.Size(578, 21)
        Me.tableLayoutPanel8.TabIndex = 4
        '
        'butmmdel
        '
        Me.butmmdel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.butmmdel.Location = New System.Drawing.Point(288, 0)
        Me.butmmdel.Margin = New System.Windows.Forms.Padding(0)
        Me.butmmdel.Name = "butmmdel"
        Me.butmmdel.Size = New System.Drawing.Size(144, 21)
        Me.butmmdel.TabIndex = 2
        Me.butmmdel.Text = "Delete"
        Me.butmmdel.UseVisualStyleBackColor = True
        '
        'butmmcls
        '
        Me.butmmcls.Dock = System.Windows.Forms.DockStyle.Fill
        Me.butmmcls.Location = New System.Drawing.Point(432, 0)
        Me.butmmcls.Margin = New System.Windows.Forms.Padding(0)
        Me.butmmcls.Name = "butmmcls"
        Me.butmmcls.Size = New System.Drawing.Size(146, 21)
        Me.butmmcls.TabIndex = 3
        Me.butmmcls.Text = "Clear"
        Me.butmmcls.UseVisualStyleBackColor = True
        '
        'butmmprev
        '
        Me.butmmprev.Dock = System.Windows.Forms.DockStyle.Fill
        Me.butmmprev.Location = New System.Drawing.Point(0, 0)
        Me.butmmprev.Margin = New System.Windows.Forms.Padding(0)
        Me.butmmprev.Name = "butmmprev"
        Me.butmmprev.Size = New System.Drawing.Size(144, 21)
        Me.butmmprev.TabIndex = 0
        Me.butmmprev.Text = "Preview"
        Me.butmmprev.UseVisualStyleBackColor = True
        '
        'butmmnew
        '
        Me.butmmnew.Dock = System.Windows.Forms.DockStyle.Fill
        Me.butmmnew.Location = New System.Drawing.Point(144, 0)
        Me.butmmnew.Margin = New System.Windows.Forms.Padding(0)
        Me.butmmnew.Name = "butmmnew"
        Me.butmmnew.Size = New System.Drawing.Size(144, 21)
        Me.butmmnew.TabIndex = 1
        Me.butmmnew.Text = "New [from]"
        Me.butmmnew.UseVisualStyleBackColor = True
        '
        'lstvmm
        '
        Me.lstvmm.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader4, Me.columnHeader6, Me.columnHeader7, Me.columnHeader5})
        Me.lstvmm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstvmm.FullRowSelect = True
        Me.lstvmm.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lstvmm.Location = New System.Drawing.Point(3, 3)
        Me.lstvmm.Name = "lstvmm"
        Me.lstvmm.ShowGroups = False
        Me.lstvmm.Size = New System.Drawing.Size(572, 78)
        Me.lstvmm.TabIndex = 1
        Me.lstvmm.UseCompatibleStateImageBehavior = False
        Me.lstvmm.View = System.Windows.Forms.View.Details
        '
        'columnHeader4
        '
        Me.columnHeader4.Text = "Client Name"
        Me.columnHeader4.Width = 210
        '
        'columnHeader6
        '
        Me.columnHeader6.Text = "Targeted IP Address"
        Me.columnHeader6.Width = 120
        '
        'columnHeader7
        '
        Me.columnHeader7.Text = "Targeted Port"
        Me.columnHeader7.Width = 90
        '
        'columnHeader5
        '
        Me.columnHeader5.Text = "Message Header"
        Me.columnHeader5.Width = 300
        '
        'groupBox3
        '
        Me.groupBox3.Controls.Add(Me.tableLayoutPanel6)
        Me.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.groupBox3.Location = New System.Drawing.Point(0, 0)
        Me.groupBox3.Margin = New System.Windows.Forms.Padding(0)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Size = New System.Drawing.Size(96, 100)
        Me.groupBox3.TabIndex = 0
        Me.groupBox3.TabStop = False
        Me.groupBox3.Text = "Message Previewer"
        '
        'tableLayoutPanel6
        '
        Me.tableLayoutPanel6.ColumnCount = 1
        Me.tableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tableLayoutPanel6.Controls.Add(Me.tableLayoutPanel7, 0, 1)
        Me.tableLayoutPanel6.Controls.Add(Me.txtbxmpv, 0, 0)
        Me.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tableLayoutPanel6.Location = New System.Drawing.Point(3, 16)
        Me.tableLayoutPanel6.Name = "tableLayoutPanel6"
        Me.tableLayoutPanel6.RowCount = 2
        Me.tableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.0!))
        Me.tableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tableLayoutPanel6.Size = New System.Drawing.Size(90, 81)
        Me.tableLayoutPanel6.TabIndex = 0
        '
        'tableLayoutPanel7
        '
        Me.tableLayoutPanel7.ColumnCount = 4
        Me.tableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tableLayoutPanel7.Controls.Add(Me.butmpdel, 0, 0)
        Me.tableLayoutPanel7.Controls.Add(Me.butmpclo, 0, 0)
        Me.tableLayoutPanel7.Controls.Add(Me.butmpv, 0, 0)
        Me.tableLayoutPanel7.Controls.Add(Me.butmpech, 0, 0)
        Me.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tableLayoutPanel7.Location = New System.Drawing.Point(0, 64)
        Me.tableLayoutPanel7.Margin = New System.Windows.Forms.Padding(0)
        Me.tableLayoutPanel7.Name = "tableLayoutPanel7"
        Me.tableLayoutPanel7.RowCount = 1
        Me.tableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17.0!))
        Me.tableLayoutPanel7.Size = New System.Drawing.Size(90, 17)
        Me.tableLayoutPanel7.TabIndex = 3
        '
        'butmpdel
        '
        Me.butmpdel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.butmpdel.Location = New System.Drawing.Point(44, 0)
        Me.butmpdel.Margin = New System.Windows.Forms.Padding(0)
        Me.butmpdel.Name = "butmpdel"
        Me.butmpdel.Size = New System.Drawing.Size(22, 17)
        Me.butmpdel.TabIndex = 2
        Me.butmpdel.Text = "Delete"
        Me.butmpdel.UseVisualStyleBackColor = True
        '
        'butmpclo
        '
        Me.butmpclo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.butmpclo.Location = New System.Drawing.Point(66, 0)
        Me.butmpclo.Margin = New System.Windows.Forms.Padding(0)
        Me.butmpclo.Name = "butmpclo"
        Me.butmpclo.Size = New System.Drawing.Size(24, 17)
        Me.butmpclo.TabIndex = 3
        Me.butmpclo.Text = "Close"
        Me.butmpclo.UseVisualStyleBackColor = True
        '
        'butmpv
        '
        Me.butmpv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.butmpv.Location = New System.Drawing.Point(0, 0)
        Me.butmpv.Margin = New System.Windows.Forms.Padding(0)
        Me.butmpv.Name = "butmpv"
        Me.butmpv.Size = New System.Drawing.Size(22, 17)
        Me.butmpv.TabIndex = 0
        Me.butmpv.Text = "View"
        Me.butmpv.UseVisualStyleBackColor = True
        '
        'butmpech
        '
        Me.butmpech.Dock = System.Windows.Forms.DockStyle.Fill
        Me.butmpech.Location = New System.Drawing.Point(22, 0)
        Me.butmpech.Margin = New System.Windows.Forms.Padding(0)
        Me.butmpech.Name = "butmpech"
        Me.butmpech.Size = New System.Drawing.Size(22, 17)
        Me.butmpech.TabIndex = 1
        Me.butmpech.Text = "Echo"
        Me.butmpech.UseVisualStyleBackColor = True
        '
        'txtbxmpv
        '
        Me.txtbxmpv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtbxmpv.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbxmpv.Location = New System.Drawing.Point(3, 3)
        Me.txtbxmpv.Multiline = True
        Me.txtbxmpv.Name = "txtbxmpv"
        Me.txtbxmpv.ReadOnly = True
        Me.txtbxmpv.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtbxmpv.Size = New System.Drawing.Size(84, 58)
        Me.txtbxmpv.TabIndex = 4
        Me.txtbxmpv.WordWrap = False
        '
        'groupBox4
        '
        Me.tableLayoutPanel1.SetColumnSpan(Me.groupBox4, 2)
        Me.groupBox4.Controls.Add(Me.tableLayoutPanel2)
        Me.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.groupBox4.Location = New System.Drawing.Point(0, 288)
        Me.groupBox4.Margin = New System.Windows.Forms.Padding(0)
        Me.groupBox4.Name = "groupBox4"
        Me.groupBox4.Size = New System.Drawing.Size(584, 73)
        Me.groupBox4.TabIndex = 5
        Me.groupBox4.TabStop = False
        Me.groupBox4.Text = "Program Manager"
        '
        'tableLayoutPanel2
        '
        Me.tableLayoutPanel2.ColumnCount = 3
        Me.tableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tableLayoutPanel2.Controls.Add(Me.butscls, 2, 1)
        Me.tableLayoutPanel2.Controls.Add(Me.butrset, 2, 0)
        Me.tableLayoutPanel2.Controls.Add(Me.lblstatus, 0, 1)
        Me.tableLayoutPanel2.Controls.Add(Me.progb1, 1, 1)
        Me.tableLayoutPanel2.Controls.Add(Me.dudla, 0, 0)
        Me.tableLayoutPanel2.Controls.Add(Me.txtbxlp, 1, 0)
        Me.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tableLayoutPanel2.Location = New System.Drawing.Point(3, 16)
        Me.tableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.tableLayoutPanel2.Name = "tableLayoutPanel2"
        Me.tableLayoutPanel2.RowCount = 2
        Me.tableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tableLayoutPanel2.Size = New System.Drawing.Size(578, 54)
        Me.tableLayoutPanel2.TabIndex = 0
        '
        'butscls
        '
        Me.butscls.Dock = System.Windows.Forms.DockStyle.Fill
        Me.butscls.Location = New System.Drawing.Point(384, 27)
        Me.butscls.Margin = New System.Windows.Forms.Padding(0)
        Me.butscls.Name = "butscls"
        Me.butscls.Size = New System.Drawing.Size(194, 27)
        Me.butscls.TabIndex = 4
        Me.butscls.Text = "Close Communicator"
        Me.butscls.UseVisualStyleBackColor = True
        '
        'butrset
        '
        Me.butrset.Dock = System.Windows.Forms.DockStyle.Fill
        Me.butrset.Location = New System.Drawing.Point(384, 0)
        Me.butrset.Margin = New System.Windows.Forms.Padding(0)
        Me.butrset.Name = "butrset"
        Me.butrset.Size = New System.Drawing.Size(194, 27)
        Me.butrset.TabIndex = 3
        Me.butrset.Text = "Reset Communicator"
        Me.butrset.UseVisualStyleBackColor = True
        '
        'lblstatus
        '
        Me.lblstatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblstatus.Location = New System.Drawing.Point(1, 27)
        Me.lblstatus.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.lblstatus.Name = "lblstatus"
        Me.lblstatus.Size = New System.Drawing.Size(190, 27)
        Me.lblstatus.TabIndex = 5
        Me.lblstatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'progb1
        '
        Me.progb1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.progb1.Location = New System.Drawing.Point(193, 27)
        Me.progb1.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.progb1.Name = "progb1"
        Me.progb1.Size = New System.Drawing.Size(190, 27)
        Me.progb1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.progb1.TabIndex = 5
        '
        'dudla
        '
        Me.dudla.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dudla.Location = New System.Drawing.Point(1, 3)
        Me.dudla.Margin = New System.Windows.Forms.Padding(1)
        Me.dudla.Name = "dudla"
        Me.dudla.ReadOnly = True
        Me.dudla.Size = New System.Drawing.Size(190, 20)
        Me.dudla.TabIndex = 0
        '
        'txtbxlp
        '
        Me.txtbxlp.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtbxlp.Location = New System.Drawing.Point(193, 3)
        Me.txtbxlp.Margin = New System.Windows.Forms.Padding(1)
        Me.txtbxlp.Name = "txtbxlp"
        Me.txtbxlp.ReadOnly = True
        Me.txtbxlp.Size = New System.Drawing.Size(190, 20)
        Me.txtbxlp.TabIndex = 1
        '
        'butabout
        '
        Me.butabout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.butabout.Location = New System.Drawing.Point(496, 0)
        Me.butabout.Margin = New System.Windows.Forms.Padding(0)
        Me.butabout.Name = "butabout"
        Me.butabout.Size = New System.Drawing.Size(88, 36)
        Me.butabout.TabIndex = 0
        Me.butabout.Text = "About"
        Me.butabout.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 361)
        Me.Controls.Add(Me.tableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(300, 200)
        Me.Name = "MainForm"
        Me.Text = "UDP Communicator"
        Me.tableLayoutPanel1.ResumeLayout(False)
        Me.splitContainer1.Panel1.ResumeLayout(False)
        Me.splitContainer1.Panel2.ResumeLayout(False)
        CType(Me.splitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitContainer1.ResumeLayout(False)
        Me.groupBox1.ResumeLayout(False)
        Me.tableLayoutPanel3.ResumeLayout(False)
        Me.tableLayoutPanel4.ResumeLayout(False)
        Me.splitContainer2.Panel1.ResumeLayout(False)
        Me.splitContainer2.Panel2.ResumeLayout(False)
        CType(Me.splitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitContainer2.ResumeLayout(False)
        Me.groupBox2.ResumeLayout(False)
        Me.tableLayoutPanel5.ResumeLayout(False)
        Me.tableLayoutPanel8.ResumeLayout(False)
        Me.groupBox3.ResumeLayout(False)
        Me.tableLayoutPanel6.ResumeLayout(False)
        Me.tableLayoutPanel6.PerformLayout()
        Me.tableLayoutPanel7.ResumeLayout(False)
        Me.groupBox4.ResumeLayout(False)
        Me.tableLayoutPanel2.ResumeLayout(False)
        Me.tableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
	Private withevents columnHeader5 As System.Windows.Forms.ColumnHeader
	Private withevents columnHeader7 As System.Windows.Forms.ColumnHeader
	Private withevents columnHeader6 As System.Windows.Forms.ColumnHeader
	Private withevents columnHeader4 As System.Windows.Forms.ColumnHeader
	Private withevents columnHeader3 As System.Windows.Forms.ColumnHeader
	Private withevents columnHeader2 As System.Windows.Forms.ColumnHeader
	Private withevents columnHeader1 As System.Windows.Forms.ColumnHeader
	Private withevents txtbxmpv As System.Windows.Forms.TextBox
	Private withevents butmpech As System.Windows.Forms.Button
	Private withevents butmpv As System.Windows.Forms.Button
	Private withevents butmpclo As System.Windows.Forms.Button
	Private withevents butmpdel As System.Windows.Forms.Button
	Private withevents tableLayoutPanel7 As System.Windows.Forms.TableLayoutPanel
	Private withevents butmmnew As System.Windows.Forms.Button
	Private withevents butmmprev As System.Windows.Forms.Button
	Private withevents butmmcls As System.Windows.Forms.Button
	Private withevents butmmdel As System.Windows.Forms.Button
	Private withevents tableLayoutPanel8 As System.Windows.Forms.TableLayoutPanel
	Private withevents butcmrem As System.Windows.Forms.Button
	Private withevents butcmadd As System.Windows.Forms.Button
	Private withevents butcmcls As System.Windows.Forms.Button
	Private withevents butcmsm As System.Windows.Forms.Button
	Private withevents tableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
	Private withevents lstvmm As System.Windows.Forms.ListView
	Private withevents tableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
	Private withevents lstvcm As System.Windows.Forms.ListView
	Private withevents tableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
	Private withevents tableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
	Private withevents txtbxlp As System.Windows.Forms.TextBox
	Private withevents dudla As System.Windows.Forms.DomainUpDown
	Private withevents progb1 As System.Windows.Forms.ProgressBar
	Private withevents lblstatus As System.Windows.Forms.Label
	Private withevents butscls As System.Windows.Forms.Button
	Private withevents butrset As System.Windows.Forms.Button
	Private withevents tableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
	Private withevents groupBox4 As System.Windows.Forms.GroupBox
	Private withevents groupBox3 As System.Windows.Forms.GroupBox
	Private withevents groupBox2 As System.Windows.Forms.GroupBox
	Private withevents groupBox1 As System.Windows.Forms.GroupBox
	Private withevents splitContainer2 As System.Windows.Forms.SplitContainer
	Private withevents splitContainer1 As System.Windows.Forms.SplitContainer
	Private withevents Label2 As System.Windows.Forms.Label
    Private WithEvents tableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Private WithEvents butcmci As System.Windows.Forms.Button
    Friend WithEvents butabout As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
End Class
