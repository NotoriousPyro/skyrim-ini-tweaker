<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProfileManager_New
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
        Me.txt_ProfileName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_CreateProfile = New System.Windows.Forms.Button()
        Me.btn_CancelCreateProfile = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txt_ProfileName
        '
        Me.txt_ProfileName.Location = New System.Drawing.Point(83, 14)
        Me.txt_ProfileName.Name = "txt_ProfileName"
        Me.txt_ProfileName.Size = New System.Drawing.Size(116, 21)
        Me.txt_ProfileName.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Name:"
        '
        'btn_CreateProfile
        '
        Me.btn_CreateProfile.Location = New System.Drawing.Point(17, 44)
        Me.btn_CreateProfile.Name = "btn_CreateProfile"
        Me.btn_CreateProfile.Size = New System.Drawing.Size(87, 27)
        Me.btn_CreateProfile.TabIndex = 2
        Me.btn_CreateProfile.Text = "Create"
        Me.btn_CreateProfile.UseVisualStyleBackColor = True
        '
        'btn_CancelCreateProfile
        '
        Me.btn_CancelCreateProfile.Location = New System.Drawing.Point(112, 44)
        Me.btn_CancelCreateProfile.Name = "btn_CancelCreateProfile"
        Me.btn_CancelCreateProfile.Size = New System.Drawing.Size(87, 27)
        Me.btn_CancelCreateProfile.TabIndex = 3
        Me.btn_CancelCreateProfile.Text = "Cancel"
        Me.btn_CancelCreateProfile.UseVisualStyleBackColor = True
        '
        'ProfileManager_New
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(210, 81)
        Me.Controls.Add(Me.btn_CancelCreateProfile)
        Me.Controls.Add(Me.btn_CreateProfile)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_ProfileName)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ProfileManager_New"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "New profile"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_ProfileName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_CreateProfile As System.Windows.Forms.Button
    Friend WithEvents btn_CancelCreateProfile As System.Windows.Forms.Button
End Class
