$ErrorActionPreference = 'Stop'

$appExe = Join-Path $PSScriptRoot 'LumiZoom.exe'
$cert = Get-ChildItem Cert:\CurrentUser\My | Where-Object {
    $_.Subject -eq 'CN=LumiZoom Local UIAccess' -and $_.HasPrivateKey
} | Select-Object -First 1

if (-not $cert) {
    $cert = New-SelfSignedCertificate `
        -Type CodeSigningCert `
        -Subject 'CN=LumiZoom Local UIAccess' `
        -CertStoreLocation Cert:\CurrentUser\My `
        -HashAlgorithm SHA256 `
        -NotAfter (Get-Date).AddYears(3)
}

foreach ($storeName in @('Root', 'TrustedPublisher')) {
    $store = New-Object System.Security.Cryptography.X509Certificates.X509Store($storeName, 'CurrentUser')
    $store.Open([System.Security.Cryptography.X509Certificates.OpenFlags]::ReadWrite)
    if (-not ($store.Certificates | Where-Object Thumbprint -eq $cert.Thumbprint)) {
        $store.Add($cert)
    }
    $store.Close()
}

$signature = Set-AuthenticodeSignature -FilePath $appExe -Certificate $cert -HashAlgorithm SHA256
if ($signature.Status -ne 'Valid') {
    throw "Nie udało się podpisać LumiZoom.exe: $($signature.StatusMessage)"
}

