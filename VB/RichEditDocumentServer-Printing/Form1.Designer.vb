Imports Microsoft.VisualBasic
Imports System
Namespace RichEditDocumentServer_Printing
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.btn_Print = New System.Windows.Forms.Button()
			Me.SuspendLayout()
			' 
			' btn_Print
			' 
			Me.btn_Print.Location = New System.Drawing.Point(84, 38)
			Me.btn_Print.Name = "btn_Print"
			Me.btn_Print.Size = New System.Drawing.Size(117, 23)
			Me.btn_Print.TabIndex = 0
			Me.btn_Print.Text = "Show Print Preview"
			Me.btn_Print.UseVisualStyleBackColor = True
'			Me.btn_Print.Click += New System.EventHandler(Me.btn_Print_Click);
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(284, 125)
			Me.Controls.Add(Me.btn_Print)
			Me.Name = "Form1"
			Me.Text = "Form1"
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private WithEvents btn_Print As System.Windows.Forms.Button
	End Class
End Namespace

