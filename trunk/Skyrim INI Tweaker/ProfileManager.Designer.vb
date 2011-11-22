<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProfileManager
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
        Me.cmb_ProfileList = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_NewProfile = New System.Windows.Forms.Button()
        Me.btn_DeleteProfile = New System.Windows.Forms.Button()
        Me.btn_RenameProfile = New System.Windows.Forms.Button()
        Me.btn_SelectProfile = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmb_ProfileList
        '
        Me.cmb_ProfileList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_ProfileList.FormattingEnabled = True
        Me.cmb_ProfileList.Location = New System.Drawing.Point(79, 14)
        Me.cmb_ProfileList.Name = "cmb_ProfileList"
        Me.cmb_ProfileList.Size = New System.Drawing.Size(116, 23)
        Me.cmb_ProfileList.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Profile:"
        '
        'btn_NewProfile
        '
        Me.btn_NewProfile.Location = New System.Drawing.Point(14, 60)
        Me.btn_NewProfile.Name = "btn_NewProfile"
        Me.btn_NewProfile.Size = New System.Drawing.Size(87, 27)
        Me.btn_NewProfile.TabIndex = 2
        Me.btn_NewProfile.Text = "New"
        Me.btn_NewProfile.UseVisualStyleBackColor = True
        '
        'btn_DeleteProfile
        '
        Me.btn_DeleteProfile.Location = New System.Drawing.Point(203, 60)
        Me.btn_DeleteProfile.Name = "btn_DeleteProfile"
        Me.btn_DeleteProfile.Size = New System.Drawing.Size(87, 27)
        Me.btn_DeleteProfile.TabIndex = 3
        Me.btn_DeleteProfile.Text = "Delete"
        Me.btn_DeleteProfile.UseVisualStyleBackColor = True
        '
        'btn_RenameProfile
        '
        Me.btn_RenameProfile.Location = New System.Drawing.Point(108, 60)
        Me.btn_RenameProfile.Name = "btn_RenameProfile"
        Me.btn_RenameProfile.Size = New System.Drawing.Size(87, 27)
        Me.btn_RenameProfile.TabIndex = 4
        Me.btn_RenameProfile.Text = "Rename"
        Me.btn_RenameProfile.UseVisualStyleBackColor = True
        '
        'btn_SelectProfile
        '
        Me.btn_SelectProfile.Location = New System.Drawing.Point(203, 12)
        Me.btn_SelectProfile.Name = "btn_SelectProfile"
        Me.btn_SelectProfile.Size = New System.Drawing.Size(87, 27)
        Me.btn_SelectProfile.TabIndex = 5
        Me.btn_SelectProfile.Text = "Select"
        Me.btn_SelectProfile.UseVisualStyleBackColor = True
        '
        'ProfileManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(303, 99)
        Me.Controls.Add(Me.btn_SelectProfile)
        Me.Controls.Add(Me.btn_RenameProfile)
        Me.Controls.Add(Me.btn_DeleteProfile)
        Me.Controls.Add(Me.btn_NewProfile)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmb_ProfileList)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ProfileManager"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Profile Manager"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmb_ProfileList As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_NewProfile As System.Windows.Forms.Button
    Friend WithEvents btn_DeleteProfile As System.Windows.Forms.Button
    Friend WithEvents btn_RenameProfile As System.Windows.Forms.Button
    Friend WithEvents btn_SelectProfile As System.Windows.Forms.Button
End Class
