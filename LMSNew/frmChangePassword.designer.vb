<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChangePassword
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChangePassword))
        Me.txtChPassUserID = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnChangePassword = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtChPassConfirm = New System.Windows.Forms.TextBox()
        Me.txtChPassNewPass = New System.Windows.Forms.TextBox()
        Me.txtChPassOldPass = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtChPassUserID
        '
        Me.txtChPassUserID.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtChPassUserID.Location = New System.Drawing.Point(164, 35)
        Me.txtChPassUserID.Name = "txtChPassUserID"
        Me.txtChPassUserID.Size = New System.Drawing.Size(122, 20)
        Me.txtChPassUserID.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(25, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 15)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "User ID :"
        '
        'btnChangePassword
        '
        Me.btnChangePassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChangePassword.Location = New System.Drawing.Point(90, 164)
        Me.btnChangePassword.Name = "btnChangePassword"
        Me.btnChangePassword.Size = New System.Drawing.Size(115, 38)
        Me.btnChangePassword.TabIndex = 4
        Me.btnChangePassword.Text = "&Change Password"
        Me.btnChangePassword.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(25, 113)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 15)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Confirm Password :"
        '
        'txtChPassConfirm
        '
        Me.txtChPassConfirm.Location = New System.Drawing.Point(164, 113)
        Me.txtChPassConfirm.Name = "txtChPassConfirm"
        Me.txtChPassConfirm.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9824)
        Me.txtChPassConfirm.Size = New System.Drawing.Size(122, 20)
        Me.txtChPassConfirm.TabIndex = 3
        '
        'txtChPassNewPass
        '
        Me.txtChPassNewPass.Location = New System.Drawing.Point(164, 87)
        Me.txtChPassNewPass.Name = "txtChPassNewPass"
        Me.txtChPassNewPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9824)
        Me.txtChPassNewPass.Size = New System.Drawing.Size(122, 20)
        Me.txtChPassNewPass.TabIndex = 2
        '
        'txtChPassOldPass
        '
        Me.txtChPassOldPass.Location = New System.Drawing.Point(164, 61)
        Me.txtChPassOldPass.Name = "txtChPassOldPass"
        Me.txtChPassOldPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9824)
        Me.txtChPassOldPass.Size = New System.Drawing.Size(122, 20)
        Me.txtChPassOldPass.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(25, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 15)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "New Password :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(25, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 15)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Old Password :"
        '
        'frmChangePassword
        '
        Me.AcceptButton = Me.btnChangePassword
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(302, 224)
        Me.Controls.Add(Me.txtChPassUserID)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnChangePassword)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtChPassConfirm)
        Me.Controls.Add(Me.txtChPassNewPass)
        Me.Controls.Add(Me.txtChPassOldPass)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmChangePassword"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Change Password"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtChPassUserID As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnChangePassword As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtChPassConfirm As System.Windows.Forms.TextBox
    Friend WithEvents txtChPassNewPass As System.Windows.Forms.TextBox
    Friend WithEvents txtChPassOldPass As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
