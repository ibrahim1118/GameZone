namespace GameZone.PL.Hellper
{
    public static class ImageSetting
    {
        public static string UploadImage(IFormFile file , string FolderName)
        {
            string FileName = $"{Guid.NewGuid}{file.FileName}";
            string FullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Image", FolderName, FileName);

            var Fs = new  FileStream(FullPath, FileMode.Create);
            file.CopyTo(Fs);
            return FileName; 
            
        }

        public static void DeleteImage(string FolderName , string FileName) {
          var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Image", FolderName, FileName); 
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
