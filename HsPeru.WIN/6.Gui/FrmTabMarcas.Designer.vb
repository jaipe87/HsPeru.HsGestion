<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmTabMarcas
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.DgvMarca = New System.Windows.Forms.DataGridView()
        Me.colcod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.chkInactivo = New System.Windows.Forms.RadioButton()
        Me.chkActivo = New System.Windows.Forms.RadioButton()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.txtDes = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.utbMarca = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.btnPdf = New System.Windows.Forms.Button()
        Me.UltraTabPageControl1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.DgvMarca, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.UltraTabPageControl2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.utbMarca, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.utbMarca.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.Panel5)
        Me.UltraTabPageControl1.Controls.Add(Me.Panel2)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(1, 20)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(470, 240)
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.DgvMarca)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(388, 240)
        Me.Panel5.TabIndex = 2
        '
        'DgvMarca
        '
        Me.DgvMarca.AllowUserToAddRows = False
        Me.DgvMarca.AllowUserToDeleteRows = False
        Me.DgvMarca.AllowUserToOrderColumns = True
        Me.DgvMarca.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DgvMarca.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvMarca.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvMarca.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvMarca.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colcod, Me.colDes, Me.colEstado})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvMarca.DefaultCellStyle = DataGridViewCellStyle4
        Me.DgvMarca.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DgvMarca.Location = New System.Drawing.Point(0, 0)
        Me.DgvMarca.Name = "DgvMarca"
        Me.DgvMarca.ReadOnly = True
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvMarca.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DgvMarca.RowHeadersVisible = False
        Me.DgvMarca.RowHeadersWidth = 15
        Me.DgvMarca.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvMarca.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvMarca.Size = New System.Drawing.Size(388, 240)
        Me.DgvMarca.TabIndex = 0
        '
        'colcod
        '
        Me.colcod.DataPropertyName = "COD"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colcod.DefaultCellStyle = DataGridViewCellStyle2
        Me.colcod.HeaderText = "Cód."
        Me.colcod.Name = "colcod"
        Me.colcod.ReadOnly = True
        Me.colcod.Width = 45
        '
        'colDes
        '
        Me.colDes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colDes.DataPropertyName = "DES"
        Me.colDes.HeaderText = "Descripción"
        Me.colDes.Name = "colDes"
        Me.colDes.ReadOnly = True
        '
        'colEstado
        '
        Me.colEstado.DataPropertyName = "ESTADO"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colEstado.DefaultCellStyle = DataGridViewCellStyle3
        Me.colEstado.HeaderText = "Estado"
        Me.colEstado.Name = "colEstado"
        Me.colEstado.ReadOnly = True
        Me.colEstado.Width = 80
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnPdf)
        Me.Panel2.Controls.Add(Me.btnExcel)
        Me.Panel2.Controls.Add(Me.btnSalir)
        Me.Panel2.Controls.Add(Me.btnModificar)
        Me.Panel2.Controls.Add(Me.btnNuevo)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(388, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(82, 240)
        Me.Panel2.TabIndex = 1
        '
        'btnSalir
        '
        Me.btnSalir.Image = Global.HsPeru.WIN.My.Resources.Resources.door_in
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSalir.Location = New System.Drawing.Point(6, 89)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(68, 43)
        Me.btnSalir.TabIndex = 2
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.Image = Global.HsPeru.WIN.My.Resources.Resources.page_edit
        Me.btnModificar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnModificar.Location = New System.Drawing.Point(6, 47)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(68, 43)
        Me.btnModificar.TabIndex = 1
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Image = Global.HsPeru.WIN.My.Resources.Resources.page_add
        Me.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnNuevo.Location = New System.Drawing.Point(6, 5)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(68, 43)
        Me.btnNuevo.TabIndex = 0
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.Panel4)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(470, 240)
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.chkInactivo)
        Me.Panel4.Controls.Add(Me.chkActivo)
        Me.Panel4.Controls.Add(Me.lblCodigo)
        Me.Panel4.Controls.Add(Me.btnCancelar)
        Me.Panel4.Controls.Add(Me.btnGuardar)
        Me.Panel4.Controls.Add(Me.txtDes)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(470, 240)
        Me.Panel4.TabIndex = 12
        '
        'chkInactivo
        '
        Me.chkInactivo.AutoSize = True
        Me.chkInactivo.Location = New System.Drawing.Point(145, 142)
        Me.chkInactivo.Name = "chkInactivo"
        Me.chkInactivo.Size = New System.Drawing.Size(63, 17)
        Me.chkInactivo.TabIndex = 20
        Me.chkInactivo.TabStop = True
        Me.chkInactivo.Text = "Inactivo"
        Me.chkInactivo.UseVisualStyleBackColor = True
        '
        'chkActivo
        '
        Me.chkActivo.AutoSize = True
        Me.chkActivo.Location = New System.Drawing.Point(75, 142)
        Me.chkActivo.Name = "chkActivo"
        Me.chkActivo.Size = New System.Drawing.Size(55, 17)
        Me.chkActivo.TabIndex = 19
        Me.chkActivo.TabStop = True
        Me.chkActivo.Text = "Activo"
        Me.chkActivo.UseVisualStyleBackColor = True
        '
        'lblCodigo
        '
        Me.lblCodigo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.Location = New System.Drawing.Point(73, 62)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(57, 20)
        Me.lblCodigo.TabIndex = 15
        Me.lblCodigo.Text = "?"
        Me.lblCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.HsPeru.WIN.My.Resources.Resources.door_in
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCancelar.Location = New System.Drawing.Point(238, 176)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(79, 43)
        Me.btnCancelar.TabIndex = 14
        Me.btnCancelar.Text = "Salir"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.HsPeru.WIN.My.Resources.Resources.disk
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGuardar.Location = New System.Drawing.Point(157, 176)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(79, 43)
        Me.btnGuardar.TabIndex = 5
        Me.btnGuardar.Text = "Grabar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'txtDes
        '
        Me.txtDes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDes.Location = New System.Drawing.Point(73, 107)
        Me.txtDes.Name = "txtDes"
        Me.txtDes.Size = New System.Drawing.Size(323, 20)
        Me.txtDes.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(70, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Descripción"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(70, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Código"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utbMarca
        '
        Me.utbMarca.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.utbMarca.Controls.Add(Me.UltraTabPageControl1)
        Me.utbMarca.Controls.Add(Me.UltraTabPageControl2)
        Me.utbMarca.Dock = System.Windows.Forms.DockStyle.Fill
        Me.utbMarca.Location = New System.Drawing.Point(0, 0)
        Me.utbMarca.Name = "utbMarca"
        Me.utbMarca.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.utbMarca.Size = New System.Drawing.Size(472, 261)
        Me.utbMarca.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Excel
        Me.utbMarca.TabIndex = 1
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "Registros"
        UltraTab2.TabPage = Me.UltraTabPageControl2
        UltraTab2.Text = "Detalle"
        Me.utbMarca.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1, UltraTab2})
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(470, 240)
        '
        'btnExcel
        '
        Me.btnExcel.Image = Global.HsPeru.WIN.My.Resources.Resources.export_excel1
        Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnExcel.Location = New System.Drawing.Point(6, 138)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(68, 43)
        Me.btnExcel.TabIndex = 3
        Me.btnExcel.Text = "Excel"
        Me.btnExcel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'btnPdf
        '
        Me.btnPdf.Image = Global.HsPeru.WIN.My.Resources.Resources._new
        Me.btnPdf.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPdf.Location = New System.Drawing.Point(6, 187)
        Me.btnPdf.Name = "btnPdf"
        Me.btnPdf.Size = New System.Drawing.Size(68, 43)
        Me.btnPdf.TabIndex = 4
        Me.btnPdf.Text = "Pdf"
        Me.btnPdf.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPdf.UseVisualStyleBackColor = True
        '
        'FrmTabMarcas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(472, 261)
        Me.Controls.Add(Me.utbMarca)
        Me.MaximumSize = New System.Drawing.Size(488, 300)
        Me.MinimumSize = New System.Drawing.Size(488, 300)
        Me.Name = "FrmTabMarcas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantenimiento de Marca"
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        CType(Me.DgvMarca, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.UltraTabPageControl2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.utbMarca, System.ComponentModel.ISupportInitialize).EndInit()
        Me.utbMarca.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents utbMarca As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Panel5 As Panel
    Friend WithEvents DgvMarca As DataGridView
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnModificar As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Panel4 As Panel
    Friend WithEvents lblCodigo As Label
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents txtDes As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents chkInactivo As RadioButton
    Friend WithEvents chkActivo As RadioButton
    Friend WithEvents colcod As DataGridViewTextBoxColumn
    Friend WithEvents colDes As DataGridViewTextBoxColumn
    Friend WithEvents colEstado As DataGridViewTextBoxColumn
    Friend WithEvents btnPdf As Button
    Friend WithEvents btnExcel As Button
End Class
