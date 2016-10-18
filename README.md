# Mulenizer

App to organize in subdirs my files in download directory.
App.config contains de BaseDirectory and subdirs with file extensions.

Ex:```xml 
<appSettings>
   <add key="BaseDirectory" value="d:\notebook\downloads" />
   <add key="videos" value="mp4;avi;mpeg" />
   <add key="office" value="xls;xlsx;doc;docx" />
   <add key="pdf" value="pdf" />
   <add key="books" value="mobi;epub" />
   <add key="iso" value="iso" />
   <add key="images" value="jpg;png;jpeg;gif"/>
</appSettings>

The app scans my basedirectory and for every file get the extension and try to move the file to subdir if extension is configured.
Ex.
My basedirectory before app run:

Downloads
 - image.jpg
 - xxx.png
 - kitty.mp4
 - C#-mastery.epub
 - wallet.xlsx
 - my-download-app.zip
 

After app run:
Downloads
 - my-download-app.zip
 - videos
    - kitty.mp4
 - office
    - wallet.xlsx
 - books
   - C#-mastery.epub
 - images
   - image.jpg
   - xxx.png

   
 
