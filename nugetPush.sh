# !/bin/bash

rm -r src/YugiohPrices.Models/bin/Release/*.nupkg
rm -r src/YugiohPrices.Library/bin/Release/*.nupkg

dotnet build src/YugiohPrices.Models/YugiohPrices.Models.csproj -c Release
dotnet build src/YugiohPrices.Library/YugiohPrices.Library.csproj -c Release

dotnet pack src/YugiohPrices.Models/YugiohPrices.Models.csproj -c Release
dotnet pack src/YugiohPrices.Library/YugiohPrices.Library.csproj -c Release

dotnet nuget push src/YugiohPrices.Models/bin/Release/*.nupkg --source https://api.nuget.org/v3/index.json --api-key $1
dotnet nuget push src/YugiohPrices.Library/bin/Release/*.nupkg --source https://api.nuget.org/v3/index.json --api-key $1