dotnet publish -c Release  ..\App\Halaqat\ -r win-x64 -o .\publish

$version = "0.0.2"
$pack_id = "Halaqat"
$main_exe = "Halaqat.exe"
$icon_path = ".\quran.ico"
$splash_image = ".\quran.png"
$framework = "net8.0-x64-desktop"
$pack_title = "Halaqat"
vpk pack -u $pack_id -v $version -p .\publish -e $main_exe --icon $icon_path --splashImage $splash_image --framework $framework --packTitle $pack_title
