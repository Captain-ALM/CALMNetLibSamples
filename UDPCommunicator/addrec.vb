'
' Created by SharpDevelop.
' User: Alfred
' Date: 29/05/2019
' Time: 10:15
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Public Partial Class addrec
    Public regs As List(Of Reg) = Nothing
    Public sreg As Reg = Nothing
	
	Public Sub New()
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
        regs = New List(Of Reg)
        regs.AddRange(lstreg.Values)
		'
		' TODO : Add constructor code after InitializeComponents
		'
	End Sub
	
	Sub Addrec_Load(sender As Object, e As EventArgs) Handles Me.Load
		combbxrs.Enabled = False
		OK_Button.Enabled = False
		Cancel_Button.Enabled = False
		combbxrs.Items.Clear()
		For i As Integer = 0 To regs.Count - 1 Step 1
            Dim reg As Reg = regs(i)
			combbxrs.Items.Add(reg.name)
		Next
		combbxrs.SelectedIndex = -1
		combbxrs.Enabled = True
		OK_Button.Enabled = False
		Cancel_Button.Enabled = True
	End Sub
	
	Sub Combbxrs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combbxrs.selectedindexchanged
		If combbxrs.SelectedIndex = -1 Then
			OK_Button.Enabled = False
		Else
			OK_Button.Enabled = True
		End If
	End Sub
	
	Sub Cancel_Button_Click(sender As Object, e As EventArgs) Handles Cancel_Button.Click
		Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.Close()
	End Sub
	
	Sub OK_Button_Click(sender As Object, e As EventArgs) Handles OK_Button.Click
		sreg = regs(combbxrs.SelectedIndex)
		Me.DialogResult = System.Windows.Forms.DialogResult.Ok
		Me.Close()
	End Sub
End Class
