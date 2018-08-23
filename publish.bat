@echo off 
set publishdir=%cd%\publish

echo "pack IP2Region.Ex..."
dotnet pack src/IP2Region.Ex/IP2Region.Ex.csproj -c Release -o %publishdir%
echo "pack IP2Region.Ex success"

echo "pack IPTools.Core..."
dotnet pack src/IPTools.Core/IPTools.Core.csproj -c Release -o %publishdir%
echo "pack IPTools.Core success"

echo "pack IPTools.China..."
dotnet pack src/IPTools.China/IPTools.China.csproj -c Release -o %publishdir%
echo "pack IPTools.China success"

echo "pack IPTools.International..."
dotnet pack src/IPTools.International/IPTools.International.csproj -c Release -o %publishdir%
echo "pack IPTools.International success"
pause