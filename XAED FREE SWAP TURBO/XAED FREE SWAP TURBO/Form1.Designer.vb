<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Me.USERNAME = New System.Windows.Forms.TextBox()
        Me.TARGET = New System.Windows.Forms.TextBox()
        Me.THREAD = New System.Windows.Forms.TextBox()
        Me.ATTEMPT = New System.Windows.Forms.TextBox()
        Me.PASSWORD = New System.Windows.Forms.TextBox()
        Me.STATUS = New System.Windows.Forms.Label()
        Me.Start = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'USERNAME
        '
        Me.USERNAME.Location = New System.Drawing.Point(12, 12)
        Me.USERNAME.Multiline = True
        Me.USERNAME.Name = "USERNAME"
        Me.USERNAME.Size = New System.Drawing.Size(145, 27)
        Me.USERNAME.TabIndex = 0
        Me.USERNAME.Text = "USERNAME"
        Me.USERNAME.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TARGET
        '
        Me.TARGET.BackColor = System.Drawing.Color.Red
        Me.TARGET.Location = New System.Drawing.Point(12, 78)
        Me.TARGET.Multiline = True
        Me.TARGET.Name = "TARGET"
        Me.TARGET.Size = New System.Drawing.Size(145, 27)
        Me.TARGET.TabIndex = 1
        Me.TARGET.Text = "TARGET"
        Me.TARGET.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'THREAD
        '
        Me.THREAD.BackColor = System.Drawing.Color.Fuchsia
        Me.THREAD.Location = New System.Drawing.Point(12, 111)
        Me.THREAD.Multiline = True
        Me.THREAD.Name = "THREAD"
        Me.THREAD.Size = New System.Drawing.Size(145, 27)
        Me.THREAD.TabIndex = 2
        Me.THREAD.Text = "10"
        Me.THREAD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ATTEMPT
        '
        Me.ATTEMPT.BackColor = System.Drawing.Color.Yellow
        Me.ATTEMPT.Location = New System.Drawing.Point(12, 144)
        Me.ATTEMPT.Multiline = True
        Me.ATTEMPT.Name = "ATTEMPT"
        Me.ATTEMPT.ReadOnly = True
        Me.ATTEMPT.Size = New System.Drawing.Size(145, 27)
        Me.ATTEMPT.TabIndex = 3
        Me.ATTEMPT.Text = "0"
        Me.ATTEMPT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PASSWORD
        '
        Me.PASSWORD.Location = New System.Drawing.Point(12, 45)
        Me.PASSWORD.Multiline = True
        Me.PASSWORD.Name = "PASSWORD"
        Me.PASSWORD.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.PASSWORD.Size = New System.Drawing.Size(145, 27)
        Me.PASSWORD.TabIndex = 4
        Me.PASSWORD.Text = "PASSWORD"
        Me.PASSWORD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'STATUS
        '
        Me.STATUS.AutoSize = True
        Me.STATUS.Location = New System.Drawing.Point(27, 225)
        Me.STATUS.Name = "STATUS"
        Me.STATUS.Size = New System.Drawing.Size(109, 13)
        Me.STATUS.TabIndex = 5
        Me.STATUS.Text = "STATUS : NOTHING"
        '
        'Start
        '
        Me.Start.BackColor = System.Drawing.Color.Lime
        Me.Start.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Start.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Start.Location = New System.Drawing.Point(12, 177)
        Me.Start.Name = "Start"
        Me.Start.Size = New System.Drawing.Size(145, 36)
        Me.Start.TabIndex = 6
        Me.Start.Text = "START"
        Me.Start.UseVisualStyleBackColor = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Blue
        Me.ClientSize = New System.Drawing.Size(169, 247)
        Me.Controls.Add(Me.Start)
        Me.Controls.Add(Me.STATUS)
        Me.Controls.Add(Me.PASSWORD)
        Me.Controls.Add(Me.ATTEMPT)
        Me.Controls.Add(Me.THREAD)
        Me.Controls.Add(Me.TARGET)
        Me.Controls.Add(Me.USERNAME)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.name = "Form1"
        Me.Text = "XAED FREE TURBO"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents USERNAME As TextBox
    Friend WithEvents TARGET As TextBox
    Friend WithEvents THREAD As TextBox
    Friend WithEvents ATTEMPT As TextBox
    Friend WithEvents PASSWORD As TextBox
    Friend WithEvents STATUS As Label
    Friend WithEvents Start As Button
End Class
