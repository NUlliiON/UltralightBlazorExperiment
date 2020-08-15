# UltralightBlazorExperiment

# Step 1
git clone https://github.com/NUlliiON/UltralightBlazorExperiment

# Step 2
build & run BlazorServerForUltralight

# Step 3
for SuperBrowser project run cmd: dotnet publish -r win-x64

# Step 4
in your SuperBrowser project publish folder create a folder named <b>assets</b>, in this folder create a file named <b>index.html</b> and write the following html code:
```html
<html>
    <head>
        <meta http-equiv="refresh" content="0; url=http://localhost:5000" />
    </head> 
</html>
```

# Step 5
in your SuperBrowser publish folder run <b>SuperBrowser.exe</b>

# DONE
After completing stepp you will see your <b>Ultralight</b> browser with a fully functional blazor server app :)
![](https://i.imgur.com/FXeTRYL.png)
