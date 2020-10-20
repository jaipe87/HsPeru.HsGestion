<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBsqArticulo
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DgArticulos = New System.Windows.Forms.DataGridView()
        Me.colcodart = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colcodfab = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescri = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCategoria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colsubcategoria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMarca = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colimagen = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblTipcam = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboSuc = New System.Windows.Forms.ComboBox()
        Me.lblReg = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCriterio = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dgDetallePrecios = New System.Windows.Forms.DataGridView()
        Me.colDessuc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDes_uni = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colprecio_publi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colpublicod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colprec_distri = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.coldistrid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colprecio_min = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colpmind = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEquivalente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSaldo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEsMin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgSaldos = New System.Windows.Forms.DataGridView()
        Me.colcodsuc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colubica = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        CType(Me.DgArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgDetallePrecios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgSaldos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DgArticulos
        '
        Me.DgArticulos.AllowUserToAddRows = False
        Me.DgArticulos.AllowUserToDeleteRows = False
        Me.DgArticulos.AllowUserToOrderColumns = True
        Me.DgArticulos.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DgArticulos.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgArticulos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DgArticulos.ColumnHeadersHeight = 30
        Me.DgArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgArticulos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colcodart, Me.colcodfab, Me.colDescri, Me.colCategoria, Me.colsubcategoria, Me.colMarca, Me.colimagen})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgArticulos.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgArticulos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgArticulos.EnableHeadersVisualStyles = False
        Me.DgArticulos.Location = New System.Drawing.Point(0, 51)
        Me.DgArticulos.MultiSelect = False
        Me.DgArticulos.Name = "DgArticulos"
        Me.DgArticulos.ReadOnly = True
        Me.DgArticulos.RowHeadersVisible = False
        Me.DgArticulos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgArticulos.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgArticulos.Size = New System.Drawing.Size(970, 250)
        Me.DgArticulos.TabIndex = 13
        '
        'colcodart
        '
        Me.colcodart.DataPropertyName = "CODART"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colcodart.DefaultCellStyle = DataGridViewCellStyle2
        Me.colcodart.HeaderText = "Cod.Artículo"
        Me.colcodart.Name = "colcodart"
        Me.colcodart.ReadOnly = True
        Me.colcodart.Width = 70
        '
        'colcodfab
        '
        Me.colcodfab.DataPropertyName = "CODFAB"
        Me.colcodfab.HeaderText = "Cod.Fábrica"
        Me.colcodfab.Name = "colcodfab"
        Me.colcodfab.ReadOnly = True
        Me.colcodfab.Width = 120
        '
        'colDescri
        '
        Me.colDescri.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colDescri.DataPropertyName = "DESCRI"
        Me.colDescri.HeaderText = "Descripción"
        Me.colDescri.Name = "colDescri"
        Me.colDescri.ReadOnly = True
        '
        'colCategoria
        '
        Me.colCategoria.DataPropertyName = "DESCAT"
        Me.colCategoria.HeaderText = "Categoría"
        Me.colCategoria.Name = "colCategoria"
        Me.colCategoria.ReadOnly = True
        '
        'colsubcategoria
        '
        Me.colsubcategoria.DataPropertyName = "DESSUBCAT"
        Me.colsubcategoria.HeaderText = "SubCategoría"
        Me.colsubcategoria.Name = "colsubcategoria"
        Me.colsubcategoria.ReadOnly = True
        '
        'colMarca
        '
        Me.colMarca.DataPropertyName = "DESMAR"
        Me.colMarca.HeaderText = "Marca"
        Me.colMarca.Name = "colMarca"
        Me.colMarca.ReadOnly = True
        '
        'colimagen
        '
        Me.colimagen.HeaderText = ""
        Me.colimagen.Image = Global.HsPeru.WIN.My.Resources.Resources.image_add
        Me.colimagen.Name = "colimagen"
        Me.colimagen.ReadOnly = True
        Me.colimagen.Width = 20
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lblTipcam)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.cboSuc)
        Me.Panel3.Controls.Add(Me.lblReg)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.txtCriterio)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.btnBuscar)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(970, 51)
        Me.Panel3.TabIndex = 15
        '
        'lblTipcam
        '
        Me.lblTipcam.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTipcam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipcam.Location = New System.Drawing.Point(599, 5)
        Me.lblTipcam.Name = "lblTipcam"
        Me.lblTipcam.Size = New System.Drawing.Size(63, 20)
        Me.lblTipcam.TabIndex = 82
        Me.lblTipcam.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(561, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 81
        Me.Label3.Text = "T/C :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(1, 32)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 13)
        Me.Label8.TabIndex = 80
        Me.Label8.Text = "Sucursal :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboSuc
        '
        Me.cboSuc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSuc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSuc.FormattingEnabled = True
        Me.cboSuc.Location = New System.Drawing.Point(59, 28)
        Me.cboSuc.Name = "cboSuc"
        Me.cboSuc.Size = New System.Drawing.Size(155, 21)
        Me.cboSuc.TabIndex = 79
        '
        'lblReg
        '
        Me.lblReg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblReg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReg.Location = New System.Drawing.Point(895, 27)
        Me.lblReg.Name = "lblReg"
        Me.lblReg.Size = New System.Drawing.Size(63, 20)
        Me.lblReg.TabIndex = 71
        Me.lblReg.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(850, 31)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(39, 13)
        Me.Label10.TabIndex = 70
        Me.Label10.Text = "Reg.  :"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCriterio
        '
        Me.txtCriterio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCriterio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCriterio.Location = New System.Drawing.Point(59, 6)
        Me.txtCriterio.Name = "txtCriterio"
        Me.txtCriterio.Size = New System.Drawing.Size(422, 20)
        Me.txtCriterio.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Criterio :"
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscar.Image = Global.HsPeru.WIN.My.Resources.Resources.zoom
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBuscar.Location = New System.Drawing.Point(487, 4)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(68, 44)
        Me.btnBuscar.TabIndex = 1
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.dgDetallePrecios)
        Me.Panel2.Controls.Add(Me.dgSaldos)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 301)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(970, 140)
        Me.Panel2.TabIndex = 14
        '
        'dgDetallePrecios
        '
        Me.dgDetallePrecios.AllowUserToAddRows = False
        Me.dgDetallePrecios.AllowUserToDeleteRows = False
        Me.dgDetallePrecios.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgDetallePrecios.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgDetallePrecios.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgDetallePrecios.ColumnHeadersHeight = 30
        Me.dgDetallePrecios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgDetallePrecios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDessuc, Me.colDes_uni, Me.colprecio_publi, Me.colpublicod, Me.colprec_distri, Me.coldistrid, Me.colprecio_min, Me.colpmind, Me.colEquivalente, Me.colSaldo, Me.colEsMin})
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgDetallePrecios.DefaultCellStyle = DataGridViewCellStyle14
        Me.dgDetallePrecios.Dock = System.Windows.Forms.DockStyle.Right
        Me.dgDetallePrecios.EnableHeadersVisualStyles = False
        Me.dgDetallePrecios.Location = New System.Drawing.Point(345, 0)
        Me.dgDetallePrecios.MultiSelect = False
        Me.dgDetallePrecios.Name = "dgDetallePrecios"
        Me.dgDetallePrecios.ReadOnly = True
        Me.dgDetallePrecios.RowHeadersVisible = False
        Me.dgDetallePrecios.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgDetallePrecios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgDetallePrecios.Size = New System.Drawing.Size(625, 140)
        Me.dgDetallePrecios.TabIndex = 71
        '
        'colDessuc
        '
        Me.colDessuc.HeaderText = "Sucursal"
        Me.colDessuc.Name = "colDessuc"
        Me.colDessuc.ReadOnly = True
        '
        'colDes_uni
        '
        Me.colDes_uni.DataPropertyName = "DESUNI"
        Me.colDes_uni.HeaderText = "UDM"
        Me.colDes_uni.Name = "colDes_uni"
        Me.colDes_uni.ReadOnly = True
        '
        'colprecio_publi
        '
        Me.colprecio_publi.DataPropertyName = "PRECIO_PUBLI"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.LightYellow
        Me.colprecio_publi.DefaultCellStyle = DataGridViewCellStyle5
        Me.colprecio_publi.HeaderText = "P.Publi S/"
        Me.colprecio_publi.Name = "colprecio_publi"
        Me.colprecio_publi.ReadOnly = True
        Me.colprecio_publi.Width = 70
        '
        'colpublicod
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Honeydew
        DataGridViewCellStyle6.Format = "0.00"
        Me.colpublicod.DefaultCellStyle = DataGridViewCellStyle6
        Me.colpublicod.HeaderText = "P.Publi US$"
        Me.colpublicod.Name = "colpublicod"
        Me.colpublicod.ReadOnly = True
        Me.colpublicod.Width = 70
        '
        'colprec_distri
        '
        Me.colprec_distri.DataPropertyName = "PRECIO_DISTRI"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.LightYellow
        Me.colprec_distri.DefaultCellStyle = DataGridViewCellStyle7
        Me.colprec_distri.HeaderText = "P.Distri S/"
        Me.colprec_distri.Name = "colprec_distri"
        Me.colprec_distri.ReadOnly = True
        Me.colprec_distri.Width = 70
        '
        'coldistrid
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.Honeydew
        DataGridViewCellStyle8.Format = "0.00"
        Me.coldistrid.DefaultCellStyle = DataGridViewCellStyle8
        Me.coldistrid.HeaderText = "P.Distri US$"
        Me.coldistrid.Name = "coldistrid"
        Me.coldistrid.ReadOnly = True
        Me.coldistrid.Width = 70
        '
        'colprecio_min
        '
        Me.colprecio_min.DataPropertyName = "PRECIO_MIN"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.LightYellow
        Me.colprecio_min.DefaultCellStyle = DataGridViewCellStyle9
        Me.colprecio_min.HeaderText = "P.Míni S/"
        Me.colprecio_min.Name = "colprecio_min"
        Me.colprecio_min.ReadOnly = True
        Me.colprecio_min.Width = 70
        '
        'colpmind
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.Honeydew
        DataGridViewCellStyle10.Format = "0.00"
        Me.colpmind.DefaultCellStyle = DataGridViewCellStyle10
        Me.colpmind.HeaderText = "P.Mini US$"
        Me.colpmind.Name = "colpmind"
        Me.colpmind.ReadOnly = True
        Me.colpmind.Width = 70
        '
        'colEquivalente
        '
        Me.colEquivalente.DataPropertyName = "EQUIVA"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colEquivalente.DefaultCellStyle = DataGridViewCellStyle11
        Me.colEquivalente.HeaderText = "Equiv."
        Me.colEquivalente.Name = "colEquivalente"
        Me.colEquivalente.ReadOnly = True
        Me.colEquivalente.Visible = False
        Me.colEquivalente.Width = 70
        '
        'colSaldo
        '
        Me.colSaldo.DataPropertyName = "SALDO"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colSaldo.DefaultCellStyle = DataGridViewCellStyle12
        Me.colSaldo.HeaderText = "Saldo"
        Me.colSaldo.Name = "colSaldo"
        Me.colSaldo.ReadOnly = True
        Me.colSaldo.Visible = False
        Me.colSaldo.Width = 70
        '
        'colEsMin
        '
        Me.colEsMin.DataPropertyName = "ESMIN"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colEsMin.DefaultCellStyle = DataGridViewCellStyle13
        Me.colEsMin.HeaderText = ""
        Me.colEsMin.MinimumWidth = 2
        Me.colEsMin.Name = "colEsMin"
        Me.colEsMin.ReadOnly = True
        Me.colEsMin.Width = 2
        '
        'dgSaldos
        '
        Me.dgSaldos.AllowUserToAddRows = False
        Me.dgSaldos.AllowUserToDeleteRows = False
        Me.dgSaldos.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgSaldos.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgSaldos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.dgSaldos.ColumnHeadersHeight = 30
        Me.dgSaldos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgSaldos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colcodsuc, Me.DataGridViewTextBoxColumn1, Me.colubica, Me.DataGridViewTextBoxColumn7})
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgSaldos.DefaultCellStyle = DataGridViewCellStyle18
        Me.dgSaldos.Dock = System.Windows.Forms.DockStyle.Left
        Me.dgSaldos.EnableHeadersVisualStyles = False
        Me.dgSaldos.Location = New System.Drawing.Point(0, 0)
        Me.dgSaldos.MultiSelect = False
        Me.dgSaldos.Name = "dgSaldos"
        Me.dgSaldos.ReadOnly = True
        Me.dgSaldos.RowHeadersVisible = False
        Me.dgSaldos.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgSaldos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgSaldos.Size = New System.Drawing.Size(310, 140)
        Me.dgSaldos.TabIndex = 70
        '
        'colcodsuc
        '
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colcodsuc.DefaultCellStyle = DataGridViewCellStyle16
        Me.colcodsuc.HeaderText = "Cod."
        Me.colcodsuc.Name = "colcodsuc"
        Me.colcodsuc.ReadOnly = True
        Me.colcodsuc.Visible = False
        Me.colcodsuc.Width = 30
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Sucursal"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'colubica
        '
        Me.colubica.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colubica.HeaderText = "Ubicación"
        Me.colubica.Name = "colubica"
        Me.colubica.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "SALDO"
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle17
        Me.DataGridViewTextBoxColumn7.HeaderText = "Saldo"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 70
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.HeaderText = ""
        Me.DataGridViewImageColumn1.Image = Global.HsPeru.WIN.My.Resources.Resources.image_add
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.Width = 20
        '
        'FrmBsqArticulo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(970, 441)
        Me.Controls.Add(Me.DgArticulos)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmBsqArticulo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Búsqueda de Artículo"
        CType(Me.DgArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgDetallePrecios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgSaldos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DgArticulos As DataGridView
    Friend WithEvents Panel3 As Panel
    Friend WithEvents txtCriterio As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnBuscar As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents dgSaldos As DataGridView
    Friend WithEvents DataGridViewImageColumn1 As DataGridViewImageColumn
    Friend WithEvents lblReg As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents colcodsuc As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents colubica As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents colcodart As DataGridViewTextBoxColumn
    Friend WithEvents colcodfab As DataGridViewTextBoxColumn
    Friend WithEvents colDescri As DataGridViewTextBoxColumn
    Friend WithEvents colCategoria As DataGridViewTextBoxColumn
    Friend WithEvents colsubcategoria As DataGridViewTextBoxColumn
    Friend WithEvents colMarca As DataGridViewTextBoxColumn
    Friend WithEvents colimagen As DataGridViewImageColumn
    Friend WithEvents Label8 As Label
    Friend WithEvents cboSuc As ComboBox
    Friend WithEvents lblTipcam As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents dgDetallePrecios As DataGridView
    Friend WithEvents colDessuc As DataGridViewTextBoxColumn
    Friend WithEvents colDes_uni As DataGridViewTextBoxColumn
    Friend WithEvents colprecio_publi As DataGridViewTextBoxColumn
    Friend WithEvents colpublicod As DataGridViewTextBoxColumn
    Friend WithEvents colprec_distri As DataGridViewTextBoxColumn
    Friend WithEvents coldistrid As DataGridViewTextBoxColumn
    Friend WithEvents colprecio_min As DataGridViewTextBoxColumn
    Friend WithEvents colpmind As DataGridViewTextBoxColumn
    Friend WithEvents colEquivalente As DataGridViewTextBoxColumn
    Friend WithEvents colSaldo As DataGridViewTextBoxColumn
    Friend WithEvents colEsMin As DataGridViewTextBoxColumn
End Class
