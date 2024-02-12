Param(
    [Parameter(Mandatory=$True)]
    [String] $backend,
    [Parameter(Mandatory=$True)]
    [String] $file
)
$pattern = 'const backendPath=".+?"'
$replacement = 'const backendPath="'+$backend+'"'

$content = Get-Content -Path $file
$replacedContent = $content -replace $pattern, $replacement
Set-Content -Path $file -Value $replacedContent