Param (
    [string] $RUTA_ARCHIVO_ORIGEN = "C:\Users\garci\Documents\AplicacionesGit\ApuntesProgramacion\ApuntesCsharp\EstudioCsharp\EstudioCsharp.md",
    [string] $RUTA_ARCHIVO_DESTINO = "C:\Users\garci\Documents\AplicacionesGit\ApuntesProgramacion\ApuntesCsharp\EstudioCsharp\Indices_EstudioCsharp.md"
)

try {

    if (($RUTA_ARCHIVO_ORIGEN -eq "" -or $RUTA_ARCHIVO_ORIGEN -eq $null) -and ($RUTA_ARCHIVO_DESTINO -eq "" -or $RUTA_ARCHIVO_DESTINO -eq $null)) {
        throw "Ingrese los parametros de origen y destino"
    }

    $caracteresEspeciales = [Linq.Enumerable]::ToArray("[$&+,:;=?@|'<>.-^*()%!]/");
    
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
        
        # Reemplaza todos los espacios en blanco superiores a 2 en uno solo
        $texto = $texto -replace "\s{2,}", " ";
        $textoLink = $texto;
        
        foreach ($caracter in $caracteresEspeciales) {
            # Reemplazamos el caracter especial por un -
            $textoLink = $textoLink.Replace("\b${caracter}\b", "-");
            $textoLink = $textoLink.Replace("${caracter}", "");
        }
        # se pasa el contenido a minusculas, se reemplazan los simbolos # y luego se quitan los espacios en blanco por -
        $textoLink = $textoLink.ToLower().Replace("#", "").Trim().Replace(' ', '-')
        # Reemplazamos en los textos que tengan mas de 2 - en solo 2, porque significaria que uno es para el espacio en blanco y el otro para el caracter especial
        $textoLink = $textoLink -replace "-{2,}", "--";

        $texto = $texto.Replace("#", "").Trim();

        $textoIndices += $indice + "[" + $texto + "](#" + $textoLink + ")`n`n";
    }
    
    [IO.FILE]::WriteAllText($RUTA_ARCHIVO_DESTINO, $textoIndices);
}
finally {
    # Se borran todas las variables usadas en el script
    Remove-Variable * -ErrorAction SilentlyContinue
}