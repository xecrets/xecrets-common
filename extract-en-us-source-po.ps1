# extract-en-us-source-po.ps1
#
# PowerShell 7+ script to extract English (US) source PO file from .resx resources.
# Cross-platform: works on Windows and macOS.
#
# Assumes POTools from https://github.com/xecrets/aspnetskeleton2 is installed as:
#   Windows: $env:AX_XFCLI/POTools.exe
#   macOS:   $env:AX_XFCLI/POTools
#
# Usage:
#   pwsh ./extract-en-us-source-po.ps1
#
# Import Translations/xecrets-ez.po, created by this script, to localise.biz using:
#
# Source / keys: msgid strings are IDs
# Target / translations: English (USA)
#
# Translate...
#
# Remove tags "new", "updated", "removed" in the tab Manage.
# No items should be tagged with anything after translation is complete.
#
# Export translations using:
#
# All (9)
# Filter: All tags /  Any state
# File format: Gettext, Gettext PO
# Settings: 
#   Index: Asset ID
#   Order: Asset ID
#

$potoolsExe = $IsWindows ? 'POTools.exe' : 'POTools'
$potoolsPath = Join-Path $env:AX_XFCLI $potoolsExe

Push-Location "src/Xecrets.Texts"
try {
    & $potoolsPath extract -p Properties -i Properties/Resources.resx --use-resx-name --no-backup -o Translations/xecrets-ez.po
} finally {
    Pop-Location
}
