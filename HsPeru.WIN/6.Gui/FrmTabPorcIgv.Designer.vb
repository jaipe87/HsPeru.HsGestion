<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmTabPorcIgv
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.DgvPorcIgv = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.rbdInactivo = New System.Windows.Forms.RadioButton()
        Me.rbdActivo = New System.Windows.Forms.RadioButton()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.txtPorc = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.utbPorcIgv = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtFecha = New HsPeru.WIN.DateTimeEditingControl()
        Me.colid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVig = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UltraTabPageControl1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.DgvPorcIgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.UltraTabPageControl2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.utbPorcIgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.utbPorcIgv.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.Panel5)
        Me.UltraTabPageControl1.Controls.Add(Me.Panel2)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(1, 20)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(382, 240)
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.DgvPorcIgv)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(300, 240)
        Me.Panel5.TabIndex = 2
        '
        'DgvPorcIgv
        '
        Me.DgvPorcIgv.AllowUserToAddRows = False
        Me.DgvPorcIgv.AllowUserToDeleteRows = False
        Me.DgvPorcIgv.AllowUserToOrderColumns = True
        Me.DgvPorcIgv.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DgvPorcIgv.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvPorcIgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvPorcIgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvPorcIgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colid, Me.colVig, Me.colEstado})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvPorcIgv.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgvPorcIgv.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DgvPorcIgv.Location = New System.Drawing.Point(0, 0)
        Me.DgvPorcIgv.Name = "DgvPorcIgv"
        Me.DgvPorcIgv.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvPorcIgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DgvPorcIgv.RowHeadersVisible = False
        Me.DgvPorcIgv.RowHeadersWidth = 15
        Me.DgvPorcIgv.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvPorcIgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvPorcIgv.Size = New System.Drawing.Size(300, 240)
        Me.DgvPorcIgv.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnSalir)
        Me.Panel2.Controls.Add(Me.btnModificar)
        Me.Panel2.Controls.Add(Me.btnNuevo)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(300, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(82, 240)
        Me.Panel2.TabIndex = 1
        '
        'btnSalir
        '
        Me.btnSalir.Image = Global.HsPeru.WIN.My.Resources.Resources.door_in
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSalir.Location = New System.Drawing.Point(6, 118)
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
        Me.btnModificar.Location = New System.Drawing.Point(6, 76)
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
        Me.btnNuevo.Location = New System.Drawing.Point(6, 34)
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
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(382, 240)
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.dtFecha)
        Me.Panel4.Controls.Add(Me.rbdInactivo)
        Me.Panel4.Controls.Add(Me.rbdActivo)
        Me.Panel4.Controls.Add(Me.btnCancelar)
        Me.Panel4.Controls.Add(Me.btnGuardar)
        Me.Panel4.Controls.Add(Me.txtPorc)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(382, 240)
        Me.Panel4.TabIndex = 12
        '
        'rbdInactivo
        '
        Me.rbdInactivo.AutoSize = True
        Me.rbdInactivo.Location = New System.Drawing.Point(143, 131)
        Me.rbdInactivo.Name = "rbdInactivo"
        Me.rbdInactivo.Size = New System.Drawing.Size(63, 17)
        Me.rbdInactivo.TabIndex = 20
        Me.rbdInactivo.TabStop = True
        Me.rbdInactivo.Text = "Inactivo"
        Me.rbdInactivo.UseVisualStyleBackColor = True
        '
        'rbdActivo
        '
        Me.rbdActivo.AutoSize = True
        Me.rbdActivo.Location = New System.Drawing.Point(73, 131)
        Me.rbdActivo.Name = "rbdActivo"
        Me.rbdActivo.Size = New System.Drawing.Size(55, 17)
        Me.rbdActivo.TabIndex = 19
        Me.rbdActivo.TabStop = True
        Me.rbdActivo.Text = "Activo"
        Me.rbdActivo.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.HsPeru.WIN.My.Resources.Resources.door_in
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCancelar.Location = New System.Drawing.Point(192, 167)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(86, 43)
        Me.btnCancelar.TabIndex = 14
        Me.btnCancelar.Text = "Salir"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.HsPeru.WIN.My.Resources.Resources.disk
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGuardar.Location = New System.Drawing.Point(111, 167)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(86, 43)
        Me.btnGuardar.TabIndex = 5
        Me.btnGuardar.Text = "Grabar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'txtPorc
        '
        Me.txtPorc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPorc.Location = New System.Drawing.Point(71, 96)
        Me.txtPorc.Name = "txtPorc"
        Me.txtPorc.Size = New System.Drawing.Size(235, 20)
        Me.txtPorc.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(68, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Porcentaje"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(68, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Desde"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utbPorcIgv
        '
        Me.utbPorcIgv.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.utbPorcIgv.Controls.Add(Me.UltraTabPageControl1)
        Me.utbPorcIgv.Controls.Add(Me.UltraTabPageControl2)
        Me.utbPorcIgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.utbPorcIgv.Location = New System.Drawing.Point(0, 0)
        Me.utbPorcIgv.Name = "utbPorcIgv"
        Me.utbPorcIgv.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.utbPorcIgv.Size = New System.Drawing.Size(384, 261)
        Me.utbPorcIgv.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Excel
        Me.utbPorcIgv.TabIndex = 2
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "Registros"
        UltraTab2.TabPage = Me.UltraTabPageControl2
        UltraTab2.Text = "Detalle"
        Me.utbPorcIgv.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1, UltraTab2})
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(382, 240)
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "COD"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Cod"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "VIGENCIA"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn2.HeaderText = "Vigencia"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "ESTADO"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewTextBoxColumn3.HeaderText = "Estado"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 90
        '
        'dtFecha
        '
        Me.dtFecha.EditingControlDataGridView = Nothing
        Me.dtFecha.EditingControlFormattedValue = "20/02/2025 16:03:23"
        Me.dtFecha.EditingControlRowIndex = 0
        Me.dtFecha.EditingControlValueChanged = False
        Me.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtFecha.Location = New System.Drawing.Point(71, 53)
        Me.dtFecha.Name = "dtFecha"
        Me.dtFecha.Size = New System.Drawing.Size(235, 20)
        Me.dtFecha.TabIndex = 21
        Me.dtFecha.Value = New Date(2025, 2, 20, 16, 3, 23, 0)
        '
        'colid
        '
        Me.colid.DataPropertyName = "COD"
        Me.colid.HeaderText = "Cod."
        Me.colid.Name = "colid"
        Me.colid.ReadOnly = True
        Me.colid.Visible = False
        '
        'colVig
        '
        Me.colVig.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colVig.DataPropertyName = "VIGENCIA"
        Me.colVig.HeaderText = "Vigencia"
        Me.colVig.Name = "colVig"
        Me.colVig.ReadOnly = True
        '
        'colEstado
        '
        Me.colEstado.DataPropertyName = "PORC"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colEstado.DefaultCellStyle = DataGridViewCellStyle2
        Me.colEstado.HeaderText = "Porcentaje"
        Me.colEstado.Name = "colEstado"
        Me.colEstado.ReadOnly = True
        Me.colEstado.Width = 90
        '
        'FrmTabPorcIgv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 261)
        Me.Controls.Add(Me.utbPorcIgv)
        Me.Name = "FrmTabPorcIgv"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmTabPorcIgv"
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        CType(Me.DgvPorcIgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.UltraTabPageControl2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.utbPorcIgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.utbPorcIgv.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents utbPorcIgv As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Panel5 As Panel
    Friend WithEvents DgvPorcIgv As DataGridView
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnModificar As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Panel4 As Panel
    Friend WithEvents rbdInactivo As RadioButton
    Friend WithEvents rbdActivo As RadioButton
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents txtPorc As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dtFecha As DateTimeEditingControl
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents colCod As DataGridViewTextBoxColumn
    Friend WithEvents colid As DataGridViewTextBoxColumn
    Friend WithEvents colVig As DataGridViewTextBoxColumn
    Friend WithEvents colEstado As DataGridViewTextBoxColumn
End Class
