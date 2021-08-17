Param (
    [string] $RUTA_ARCHIVO_ORIGEN,
    [string] $RUTA_ARCHIVO_DESTINO
)

try {

    if (($RUTA_ARCHIVO_ORIGEN -ne "" -or $RUTA_ARCHIVO_ORIGEN -ne $null) -and ($RUTA_ARCHIVO_DESTINO -ne "" -or $RUTA_ARCHIVO_DESTINO -ne $null)) {
        throw "Ingrese los parametros de origen y destino"
    }

    $archivoLeido = [IO.FILE]::ReadAllText($RUTA_ARCHIVO_ORIGEN);

    [System.Collections.ArrayList]$textoFiltrado = New-Object System.Collections.ArrayList;

    foreach ($linea in $archivoLeido.Split("`n")) {
        if (($linea.StartsWith("# ") -and $linea.EndsWith("`r")) -or ($linea.StartsWith("## ") -and $linea.EndsWith("`r")) -or ($linea.StartsWith("### ") -and $linea.EndsWith("`r")) -or ($linea.StartsWith("#### ") -and $linea.EndsWith("`r"))) {
            $textoFiltrado.Add($linea);
        }
    }
    

    $titulo = 1;
    $textoIndices = "";

    foreach ($texto in $textoFiltrado) {
        $indice = "";

        if ($texto.StartsWith("# ")) {
            $indice = "${titulo}. ";
        }
        elseif ($texto.StartsWith("## ")) {
            $indice = "`t ${titulo}. ";
        }
        elseif ($texto.StartsWith("### ")) {
            $indice = "`t`t ${titulo}. ";
        }
        elseif ($texto.StartsWith("#### ")) {
            $indice = "`t`t`t ${titulo}. ";
        }
        
        $textoIndices += $indice + "[" + $texto.Replace("#", "") + "](#" + $texto.ToLower().Replace(' ', '-').Replace("#-", "") + ")`n`n";
    }
    
    [IO.FILE]::WriteAllText($RUTA_ARCHIVO_DESTINO, $textoIndices);
}
finally {
    # Se borran todas las variables usadas en el script
    Remove-Variable * -ErrorAction SilentlyContinue
}