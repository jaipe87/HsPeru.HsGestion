Module sisEnum
    Public Enum DocRefFac
        PRO = 75
        NP = 40
    End Enum
    Public Enum TipElec
        NOESELEC = 0
        ESELEC = 1
        AMBOS = 2
    End Enum
    Public Enum TipDocCPE
        FAC = 1
        BOL = 3
        NC = 7
        ND = 8
        NP = 40
        NV = 41
        PRO = 70
    End Enum
    Public Enum TipoPrecio
        Todos = 0
        Publico = 1
        Distribuidor = 2
        Minimo = 3

    End Enum
    Public Enum TipReg
        PRO = 1
        CLI = 2
        AMB = 3
        OBR = 4
        EMP = 5
        OTR = 6
    End Enum
    Public Enum TipPago
        CONTADO = 1
        CREDITO = 2
        TARJETA = 3
        DEPOSITO = 4
    End Enum
    Public Enum TipMon
        SOLES = 1
        DOLARES = 2
    End Enum
    Public Enum TipCPE
        NORMAL = 0
        ELECTRO = 1
    End Enum

    Public Enum TipDocClie
        RUC = 1
        DNI = 2
        EXT = 3
        PAS = 4
        OTRO = 5
    End Enum
    Public Enum Pais
        PERU = 1
    End Enum

    Public Enum TipMensaje
        Informativo = 1
        Pregunta = 2
        Admiracion = 3
        [Error] = 4
    End Enum
End Module
