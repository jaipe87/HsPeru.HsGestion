<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmConsultaCliPro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConsultaCliPro))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnSunat = New System.Windows.Forms.Button()
        Me.btnReniec = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.rbdDentroRazsoc = New System.Windows.Forms.RadioButton()
        Me.rbdInicioRazon = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCriterio = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DgCliente = New System.Windows.Forms.DataGridView()
        Me.colTipReg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colcodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDesdoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNroDoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRazsoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.coDirecc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.lblTotreg = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DgCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnSunat)
        Me.Panel1.Controls.Add(Me.btnReniec)
        Me.Panel1.Controls.Add(Me.btnBuscar)
        Me.Panel1.Controls.Add(Me.rbdDentroRazsoc)
        Me.Panel1.Controls.Add(Me.rbdInicioRazon)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtCriterio)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(822, 56)
        Me.Panel1.TabIndex = 0
        '
        'btnSunat
        '
        Me.btnSunat.Image = Global.HsPeru.WIN.My.Resources.Resources.sunat
        Me.btnSunat.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSunat.Location = New System.Drawing.Point(680, 11)
        Me.btnSunat.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSunat.Name = "btnSunat"
        Me.btnSunat.Size = New System.Drawing.Size(68, 43)
        Me.btnSunat.TabIndex = 118
        Me.btnSunat.Text = "Sunat"
        Me.btnSunat.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSunat.UseVisualStyleBackColor = True
        '
        'btnReniec
        '
        Me.btnReniec.Image = CType(resources.GetObject("btnReniec.Image"), System.Drawing.Image)
        Me.btnReniec.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnReniec.Location = New System.Drawing.Point(748, 11)
        Me.btnReniec.Margin = New System.Windows.Forms.Padding(2)
        Me.btnReniec.Name = "btnReniec"
        Me.btnReniec.Size = New System.Drawing.Size(68, 43)
        Me.btnReniec.TabIndex = 117
        Me.btnReniec.Text = "Reniec"
        Me.btnReniec.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnReniec.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.HsPeru.WIN.My.Resources.Resources.zoom
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBuscar.Location = New System.Drawing.Point(613, 10)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(68, 43)
        Me.btnBuscar.TabIndex = 1
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'rbdDentroRazsoc
        '
        Me.rbdDentroRazsoc.AutoSize = True
        Me.rbdDentroRazsoc.Checked = True
        Me.rbdDentroRazsoc.Location = New System.Drawing.Point(191, 7)
        Me.rbdDentroRazsoc.Name = "rbdDentroRazsoc"
        Me.rbdDentroRazsoc.Size = New System.Drawing.Size(126, 17)
        Me.rbdDentroRazsoc.TabIndex = 0
        Me.rbdDentroRazsoc.TabStop = True
        Me.rbdDentroRazsoc.Text = "Dentro de Raz.Social"
        Me.rbdDentroRazsoc.UseVisualStyleBackColor = True
        '
        'rbdInicioRazon
        '
        Me.rbdInicioRazon.AutoSize = True
        Me.rbdInicioRazon.Location = New System.Drawing.Point(79, 7)
        Me.rbdInicioRazon.Name = "rbdInicioRazon"
        Me.rbdInicioRazon.Size = New System.Drawing.Size(104, 17)
        Me.rbdInicioRazon.TabIndex = 7
        Me.rbdInicioRazon.Text = "Inicio Raz.Social"
        Me.rbdInicioRazon.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Buscar por :"
        '
        'txtCriterio
        '
        Me.txtCriterio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCriterio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCriterio.Location = New System.Drawing.Point(79, 30)
        Me.txtCriterio.Name = "txtCriterio"
        Me.txtCriterio.Size = New System.Drawing.Size(528, 20)
        Me.txtCriterio.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.DgCliente)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 56)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(822, 330)
        Me.Panel2.TabIndex = 1
        '
        'DgCliente
        '
        Me.DgCliente.AllowUserToAddRows = False
        Me.DgCliente.AllowUserToDeleteRows = False
        Me.DgCliente.AllowUserToOrderColumns = True
        Me.DgCliente.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DgCliente.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgCliente.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DgCliente.ColumnHeadersHeight = 30
        Me.DgCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgCliente.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colTipReg, Me.colcodigo, Me.colDesdoc, Me.colNroDoc, Me.colRazsoc, Me.coDirecc, Me.colEstado})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgCliente.DefaultCellStyle = DataGridViewCellStyle5
        Me.DgCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgCliente.EnableHeadersVisualStyles = False
        Me.DgCliente.Location = New System.Drawing.Point(0, 0)
        Me.DgCliente.MultiSelect = False
        Me.DgCliente.Name = "DgCliente"
        Me.DgCliente.ReadOnly = True
        Me.DgCliente.RowHeadersVisible = False
        Me.DgCliente.RowHeadersWidth = 10
        Me.DgCliente.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgCliente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgCliente.Size = New System.Drawing.Size(822, 330)
        Me.DgCliente.TabIndex = 0
        '
        'colTipReg
        '
        Me.colTipReg.DataPropertyName = "DESTIPREG"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colTipReg.DefaultCellStyle = DataGridViewCellStyle2
        Me.colTipReg.HeaderText = "T/R"
        Me.colTipReg.Name = "colTipReg"
        Me.colTipReg.ReadOnly = True
        Me.colTipReg.Width = 40
        '
        'colcodigo
        '
        Me.colcodigo.DataPropertyName = "CODIGO"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colcodigo.DefaultCellStyle = DataGridViewCellStyle3
        Me.colcodigo.HeaderText = "Código"
        Me.colcodigo.Name = "colcodigo"
        Me.colcodigo.ReadOnly = True
        Me.colcodigo.Width = 50
        '
        'colDesdoc
        '
        Me.colDesdoc.DataPropertyName = "DESTIPDOC"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colDesdoc.DefaultCellStyle = DataGridViewCellStyle4
        Me.colDesdoc.HeaderText = "T/D"
        Me.colDesdoc.Name = "colDesdoc"
        Me.colDesdoc.ReadOnly = True
        Me.colDesdoc.Width = 40
        '
        'colNroDoc
        '
        Me.colNroDoc.DataPropertyName = "NRODOC"
        Me.colNroDoc.HeaderText = "Nro.Doc"
        Me.colNroDoc.Name = "colNroDoc"
        Me.colNroDoc.ReadOnly = True
        '
        'colRazsoc
        '
        Me.colRazsoc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colRazsoc.DataPropertyName = "TRAZSOC"
        Me.colRazsoc.HeaderText = "Razón Social (Nombre)"
        Me.colRazsoc.MinimumWidth = 200
        Me.colRazsoc.Name = "colRazsoc"
        Me.colRazsoc.ReadOnly = True
        '
        'coDirecc
        '
        Me.coDirecc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.coDirecc.DataPropertyName = "DIRECC"
        Me.coDirecc.HeaderText = "Dirección"
        Me.coDirecc.Name = "coDirecc"
        Me.coDirecc.ReadOnly = True
        '
        'colEstado
        '
        Me.colEstado.DataPropertyName = "ESTADO"
        Me.colEstado.HeaderText = "Estado"
        Me.colEstado.Name = "colEstado"
        Me.colEstado.ReadOnly = True
        Me.colEstado.Width = 50
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnSalir)
        Me.Panel3.Controls.Add(Me.btnModificar)
        Me.Panel3.Controls.Add(Me.btnNuevo)
        Me.Panel3.Controls.Add(Me.lblTotreg)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 386)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(822, 52)
        Me.Panel3.TabIndex = 2
        '
        'btnSalir
        '
        Me.btnSalir.Image = Global.HsPeru.WIN.My.Resources.Resources.door_in
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSalir.Location = New System.Drawing.Point(444, 4)
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
        Me.btnModificar.Location = New System.Drawing.Point(377, 4)
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
        Me.btnNuevo.Location = New System.Drawing.Point(310, 4)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(68, 43)
        Me.btnNuevo.TabIndex = 0
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'lblTotreg
        '
        Me.lblTotreg.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotreg.AutoSize = True
        Me.lblTotreg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotreg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotreg.Location = New System.Drawing.Point(765, 16)
        Me.lblTotreg.MinimumSize = New System.Drawing.Size(45, 18)
        Me.lblTotreg.Name = "lblTotreg"
        Me.lblTotreg.Size = New System.Drawing.Size(45, 18)
        Me.lblTotreg.TabIndex = 10
        Me.lblTotreg.Text = "0"
        Me.lblTotreg.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(709, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "N° Reg. :"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "DESTIPREG"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewTextBoxColumn1.HeaderText = "T/R"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 40
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "CODIGO"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewTextBoxColumn2.HeaderText = "Código"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 50
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "DESTIPDOC"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridViewTextBoxColumn3.HeaderText = "T/D"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 40
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "NRODOC"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Nro.Doc"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "TRAZSOC"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Razón Social (Nombre)"
        Me.DataGridViewTextBoxColumn5.MinimumWidth = 200
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "DIRECC"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Dirección"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "ESTADO"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Estado"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 50
        '
        'FrmConsultaCliPro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(822, 438)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(717, 477)
        Me.Name = "FrmConsultaCliPro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de Clientes / Proveedores"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.DgCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents DgCliente As DataGridView
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents txtCriterio As TextBox
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnModificar As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents lblTotreg As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnBuscar As Button
    Friend WithEvents rbdDentroRazsoc As RadioButton
    Friend WithEvents rbdInicioRazon As RadioButton
    Friend WithEvents colTipReg As DataGridViewTextBoxColumn
    Friend WithEvents colcodigo As DataGridViewTextBoxColumn
    Friend WithEvents colDesdoc As DataGridViewTextBoxColumn
    Friend WithEvents colNroDoc As DataGridViewTextBoxColumn
    Friend WithEvents colRazsoc As DataGridViewTextBoxColumn
    Friend WithEvents coDirecc As DataGridViewTextBoxColumn
    Friend WithEvents colEstado As DataGridViewTextBoxColumn
    Friend WithEvents btnSunat As Button
    Friend WithEvents btnReniec As Button
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
End Class
