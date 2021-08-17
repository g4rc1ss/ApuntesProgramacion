try {
    
    $RUTA_ARCHIVO_ORIGEN = "C:\Users\garci\Downloads\Csharp.md"

    if ($RUTA_ARCHIVO_ORIGEN.Contains('\')) {
        $RutaOrigenSplit = $RUTA_ARCHIVO_ORIGEN.Split('\')
    }
    elseif ($RUTA_ARCHIVO_ORIGEN.Contains('/')) {
        $RutaOrigenSplit = $RUTA_ARCHIVO_ORIGEN.Split('/')
    }

    $RUTA_ARCHIVO_INDICES = "Indices_" + $RutaOrigenSplit[$RutaOrigenSplit.Length - 1]


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
    
    [IO.FILE]::WriteAllText($RUTA_ARCHIVO_INDICES, $textoIndices);
}
finally {
    # Se borran todas las variables usadas en el script
    Remove-Variable * -ErrorAction SilentlyContinue
}