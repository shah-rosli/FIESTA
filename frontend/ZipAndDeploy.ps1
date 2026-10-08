param (
  [Parameter(Mandatory = $true)]
  [string]$envName
)

Write-Output ""
Write-Output "Deployment script started..."

if ($envName -eq 'local') {
  # for development/debugging purpose
  $endpointUrl = 'https://localhost:7245/api/'
  Write-Output "Environment: $envName"
}
elseif ($envName -eq 'dev') {
  $endpointUrl = 'https://fiesta-dev.eapp.renesas.com/FIESTA_BACKEND/api/'
  Write-Output "Environment: $envName"
}
elseif ($envName -eq 'dev2') {
  $endpointUrl = 'https://mdm-dev1.eapp.renesas.com/FIESTA_BACKEND/api/'
  Write-Output "Environment: $envName"
}
elseif ($envName -eq 'qa') {
  $endpointUrl = 'https://fiesta-qas.eapp.renesas.com/FIESTA_BACKEND/api/'
  Write-Output "Environment: $envName"
}
elseif ($envName -eq 'qa2') {
  $endpointUrl = 'https://mdm-qas2.eapp.renesas.com/FIESTA_BACKEND/api/'
  Write-Output "Environment: $envName"
}
elseif ($envName -eq 'qa3') {
  $endpointUrl = 'https://fiesta-qas3.eapp.renesas.com/FIESTA_BACKEND/api/'
  Write-Output "Environment: $envName"
}
elseif ($envName -eq 'qa4') {
  $endpointUrl = 'https://fiesta-qas4.eapp.renesas.com/FIESTA_BACKEND/api/'
  Write-Output "Environment: $envName"
}
elseif ($envName -eq 'qa5') {
  $endpointUrl = 'https://mdm-qas5.eapp.renesas.com/FIESTA_BACKEND/api/'
  Write-Output "Environment: $envName"
}
elseif ($envName -eq 'prod') {
  $endpointUrl = 'https://fiesta.eapp.renesas.com/FIESTA_BACKEND/api/'
  Write-Output "Environment: $envName"
}
else {
  Write-Output "Invalid environment name provided. Terminating script."
  exit 1
}

$frontendDeployUrl = "${endpointUrl}frontendDeploy"
$jwtKeyUrl = "${endpointUrl}jwt/key"

$currentDir = Get-Location
Write-Output "Current working directory: $currentDir"

$distPath = Join-Path -Path $currentDir -ChildPath "dist\fiesta\browser\"
$zipPath = Join-Path -Path $currentDir -ChildPath "dist\FIESTA.zip"
# Write-Output "Bundle location: $distPath"
# Write-Output "Zip location   : $zipPath"

# Check if index.html exists in dist
$indexFilePath = Join-Path -Path $distPath -ChildPath "index.html"
if (-Not (Test-Path $indexFilePath)) {
  Write-Output "index.html not found in dist, Terminating script."
  exit 1
}

try {
  Write-Output "Zipping..."
  Compress-Archive -Path "$distPath\*" -DestinationPath $zipPath -Update
}
catch {
  Write-Output "Failed to create archive. Terminating script."
  exit 1
}

Write-Output "Getting bearer token..."
$jsonPayload = '{
  "key":"MfvMs0V5RLRFBBIkxtag8k/Ts19H5r83XXK/UE3xkO8Y7lcZ/rtpsAwtqHGl7yZbQwaeXoGBwIin15dh6ALuFw==",
  "delegateid":"0"
}'

$jwtresponse = Invoke-RestMethod -Uri $jwtKeyUrl -Method Post -Body $jsonPayload -ContentType "application/json"

$bearerToken = $jwtresponse.data

# Ensure the token is valid
if (-not $bearerToken) {
  Write-Output "Failed to get a bearer token, will terminate script. Are you connected to company network?"
  exit 1
}

# Create headers with Bearer token
$headers = @{
  'Content-Type'  = 'application/zip'
  'Authorization' = "Bearer $bearerToken"
}

# Read the file content as bytes
$fileBytes = [System.IO.File]::ReadAllBytes($zipPath)

# Send POST request to the endpoint with the file bytes as the body
Write-Output "Waiting Agent reply..."
$response = Invoke-RestMethod -Uri $frontendDeployUrl -Method 'POST' -Headers $headers -Body $fileBytes

Write-Output ""
Write-Output "Agent Log:"
Write-Output $response.Log
Write-Output "Agent Message:"
Write-Output $response.Message

# Remove the zip file after sending
Remove-Item -Path $zipPath

$date = Get-Date -Format "MM/dd/yyyy h:mmtt"
Write-Output ""
Write-Output "[$envName] Deployment script finished on $date ..."

if ($response.Success -eq $false) {
  exit 1
}