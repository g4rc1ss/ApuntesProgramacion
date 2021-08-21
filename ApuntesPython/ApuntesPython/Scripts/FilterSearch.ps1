function SearchWithFilter {
    param (
        [Parameter(Position = 1, Mandatory = $true)][string]$path,
        [Parameter(Position = 2, Mandatory = $true)][string]$wordToMatch
    )
    return Get-ChildItem $path -Recurse -File | Where-Object Name -match $wordToMatch 
}